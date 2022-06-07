using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{

    [SerializeField] GameObject dart;
    [SerializeField] GameObject GFX;
    [SerializeField] GameObject shadow;
    [SerializeField] GameObject floor;
    [SerializeField] public AudioClip throwClip;
    [SerializeField] public float zAxis = 0;
    [SerializeField] GameObject arrow;

    DartFunctionality dartFunctionality;
    SpriteRenderer shadowRenderer;
    SpriteRenderer dartRenderer;
    public Rigidbody2D dartRb;
    float zSpeed = .6f;
    float acceleration = .05f;
    public float throwForceY = 3f;
    float throwForceX = 1.8f; 
    bool thrown = false;
    public bool scored = false;
    Vector3 initialPos;
    Vector3 initialPosParent;
    public GameObject point;

    bool FollowMouse = true;

    AimDir aimDir;

    [HideInInspector] public Coroutine decrease;
    [HideInInspector] public Coroutine respawn = null;

    [SerializeField] public List<Target> targets;

    Vector3 startPos, endPos;

    // Start is called before the first frame update
    void Start()
    {
        shadowRenderer = shadow.GetComponent<SpriteRenderer>();
        dartRenderer = dart.GetComponentInChildren<SpriteRenderer>();
        initialPos = dart.transform.localPosition;
        dartRb = dart.GetComponent<Rigidbody2D>();

        dartFunctionality = FindObjectOfType<DartFunctionality>();
        point = dart.transform.Find("Point").gameObject;

        initialPosParent = transform.position;

        aimDir = arrow.GetComponent<AimDir>();

    }

    // Update is called once per frame
    void Update()
    {
        // Set shadow to follow the dart
        Vector2 newShadowPos = new Vector2(dart.transform.position.x, shadow.transform.position.y);
        shadow.transform.position = newShadowPos;
        // Set floor to be in the axis of the shadow
        floor.transform.position = newShadowPos;

        if (FollowMouse)
        {
            // Follow mouse on x axis
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPos = new Vector3(mousePos.x, transform.position.y, 0);
            newPos.x = Mathf.Clamp(newPos.x, -8.7f, 8.7f);
            transform.position = newPos;
        }

        MouseMovement();
        AnimateShadow();
        UseZValue();


        foreach (Target target in targets)
        {
            float distance = (target.zAxis - zAxis);
            target.collider2d.enabled =  distance <= 0.05f && distance >= 0;
        }

    }

    void MouseMovement()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        aimDir.target = mousePosition;
        if (thrown) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            aimDir.position = mousePosition;
            FollowMouse = false;
            startPos = mousePosition;
            arrow.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            arrow.SetActive(false);
            endPos = mousePosition;
            Vector3 dir = startPos - endPos;
            if (dir.y < 0)
            {
                dartRb.bodyType = RigidbodyType2D.Dynamic;
                dartRb.AddForce(new Vector2(-dir.x * throwForceX, -dir.y * throwForceY), ForceMode2D.Impulse);
                Throw();
                return;
            }
            FollowMouse = true;
        }
    }

    void Throw()
    {
        thrown = true;
        FollowMouse = false;
        decrease = StartCoroutine(DecreaseSpeed());
    }

    // Animates shadow based on how far it is from the floor.
    void AnimateShadow()
    {
        float distanceFromFloor = Vector2.Distance(dart.transform.position, shadow.transform.position);
        shadowRenderer.DOFade(distanceFromFloor > 20 ? 0.2f : 1 - distanceFromFloor / 20, 0);
        shadow.transform.DOScaleX(1 + distanceFromFloor * .2f, 0);
    }

    void UseZValue()
    {
        //transform.DOScale(1 - zAxis, 0);
        transform.localScale = new Vector3(1 - zAxis, 1 - zAxis, 1 - zAxis);
        float y = -4.86f + zAxis / .14f;
        transform.position = new Vector2(transform.position.x, y);
        //transform.DOMoveY(-4.86f + zAxis / .14f , 0);
        dartRenderer.sortingOrder = (int)(-zAxis / .01);
        shadowRenderer.sortingOrder = dartRenderer.sortingOrder - 1;
    }

    IEnumerator DecreaseSpeed()
    {
        float speed = zSpeed;
        bool shouldExit = false;
        while (!shouldExit && !dartFunctionality.isGrounded)
        {
            zAxis += speed * Time.deltaTime;
            if (zAxis < 0) zAxis = 0;
            shouldExit = zAxis > 0.6;
            yield return new WaitForEndOfFrame();
            speed -= acceleration * Time.deltaTime;
        }
        CallRespawn(1);
    }


    public IEnumerator Respawn(float time)
    {
        if(TargetShoot.instance.isWaiting) yield break;
        yield return new WaitForSeconds(time);
        respawn = null;
        if (!scored ) TargetShoot.instance.LoseLive();
        TargetShoot.instance.SpawnTargets();
        zAxis = 0;
        dartRb.bodyType = RigidbodyType2D.Static;
        dartRb.velocity = Vector2.zero;
        dartFunctionality.isGrounded = false;
        thrown = false;
        scored = false;
        dart.transform.localPosition = initialPos;
        transform.position = initialPosParent;
        transform.localScale = Vector3.one;
        FollowMouse = true;
    }

    public void CallRespawn(float time)
    {
        respawn = StartCoroutine(Respawn(time));
    }
}
