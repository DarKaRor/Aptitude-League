using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject basketBall;
    [SerializeField] GameObject GFX;
    [SerializeField] GameObject shadow;
    [SerializeField] GameObject floor;
    [SerializeField] GameObject arrow;
    BallFunctionality functionality;
    [SerializeField] public AudioClip dribble;
    SpriteRenderer shadowRenderer;
    SpriteRenderer ballRenderer;
    public Rigidbody2D ballRb;
    [SerializeField] public float zAxis = 0;
    float zSpeed = .4f;
    float acceleration = .08f;
    public float throwForceY = 2.8f;
    float throwForceX = 1.5f;
    bool thrown = false;
    public bool scored = false;
    [SerializeField] public List<Basket> baskets;
    Vector3 initialPos;
    [HideInInspector] public Tween postween;
    [HideInInspector] public Coroutine decrease;
    [HideInInspector] public Coroutine respawn = null;

    bool FollowMouse = true;
    bool dribbled = false;

    Vector3 startPos, endPos;

    AimDir aimDir;
    void Start()
    {
        //RotateConstant(GFX);
        shadowRenderer = shadow.GetComponent<SpriteRenderer>();
        ballRb = basketBall.GetComponent<Rigidbody2D>();
        functionality = basketBall.GetComponent<BallFunctionality>();
        ballRenderer = GFX.transform.GetComponentInChildren<SpriteRenderer>();
        initialPos = basketBall.transform.position;

        aimDir = arrow.GetComponent<AimDir>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set shadow to follow the ball
        Vector2 newShadowPos = new Vector2(basketBall.transform.position.x, shadow.transform.position.y);
        shadow.transform.position = newShadowPos;
        // Set floor to be in the axis of the shadow
        floor.transform.position = newShadowPos;

        if (FollowMouse)
        {
            // Follow mouse on x axis
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPos = new Vector3(mousePos.x, basketBall.transform.position.y, 0);
            newPos.x = Mathf.Clamp(newPos.x, -8f, 8f);
            basketBall.transform.position = newPos;
        }

        MouseMovement();
        AnimateShadow();
        UseZValue();

        foreach(Basket basket in baskets)
        {
            if (Mathf.Abs(zAxis - basket.zAxis) <= 0.15f) basket.SetColliders(true);
            else basket.SetColliders(false);
        }
       
    }

    void MouseMovement()
    {
        if (PauseMenu.instance.paused) return;
        if (thrown) return;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        aimDir.target = mousePosition;

        if (Input.GetMouseButtonDown(0) )
        {
            aimDir.position = mousePosition;
            arrow.SetActive(true);
            startPos = mousePosition;
            FollowMouse = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = mousePosition;
            Vector3 dir = startPos - endPos;
            arrow.SetActive(false);
            if (Vector2.Distance(startPos, endPos) < 1f){
                if(!dribbled) FollowMouse = true;
                return;
            }
            ballRb.AddForce(new Vector2(- dir.x * throwForceX, -dir.y * throwForceY), ForceMode2D.Impulse);
            if(dir.y < 0) Throw();
            else dribbled = true;
        }

        
    }

    void Throw()
    {
        FollowMouse = false;
        dribbled = false;
        thrown = true;
        functionality.isGrounded = false;
        decrease = StartCoroutine(DecreaseSpeed());
    }

    void UseZValue()
    {
        transform.DOScale(1 - zAxis, 0);
        ballRenderer.sortingOrder = (int)(-zAxis / .05);
        shadowRenderer.sortingOrder = ballRenderer.sortingOrder - 1;
    }

    // Animates shadow based on how far it is from the floor.
    void AnimateShadow()
    {
        float distanceFromFloor = Vector2.Distance(basketBall.transform.position, shadow.transform.position);
        shadowRenderer.DOFade(distanceFromFloor > 20 ? 0.2f : 1 - distanceFromFloor / 20, 0);
        shadow.transform.DOScaleX(1 + distanceFromFloor * .2f, 0);
    }

    public void RotateConstant(GameObject gameObject, float rotSpeed = 5f)
    {
        gameObject.transform.DORotate(new Vector3(0,0,360), rotSpeed, RotateMode.Fast).SetLoops(-1).SetEase(Ease.Linear).SetRelative();
    }

    public void StopRotation(GameObject gameObject)
    {
        gameObject.transform.DOKill();
    }

    IEnumerator DecreaseSpeed()
    {
        float speed = zSpeed;
        bool shouldExit = false;
        while(!functionality.isGrounded && !shouldExit)
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
        if(DunkIt.instance.isWaiting) yield break;
        yield return new WaitForSeconds(time);
        respawn = null;
        if (!scored) DunkIt.instance.LoseBall();
        DunkIt.instance.SpawnBaskets();
        zAxis = 0;
        postween.Kill();
        ballRb.velocity = Vector2.zero;
        thrown = false;
        scored = false;
        basketBall.transform.position = initialPos;
        FollowMouse = true;   
    }

    public void CallRespawn(float time)
    {
        respawn = StartCoroutine(Respawn(time));
    }
}
