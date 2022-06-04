using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMovement : MonoBehaviour
{

    [HideInInspector] public float speed = 5f;
    Vector2 dir;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    [SerializeField] WalkAnim downAnim;
    [SerializeField] WalkAnim leftAnim;
    [SerializeField] WalkAnim upAnim;
    WalkAnim current = null;
    WalkAnim lastCurrent = null;
    float x;
    float y;
    Coroutine anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        spriteRenderer = transform.Find("GFX").GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = downAnim.idle;
        lastCurrent = current;
    }

    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float generalMovement = Mathf.Abs(dir.x) + Mathf.Abs(dir.y);


        if (generalMovement != 0)
        {
            if (dir.x != 0) spriteRenderer.flipX = dir.x < 0;
            if (dir.y == 0 && dir.x != 0) current = leftAnim;
            else
            {
                spriteRenderer.flipX = false;
                current = dir.y > 0 ? upAnim : downAnim;
            }
        }



        dir = new Vector2(x, y).normalized;

        if ((generalMovement != 0 && anim == null) || current != lastCurrent)
        {
            if (anim != null) StopCoroutine(anim);
            anim = StartCoroutine(PlayAnimation());
            lastCurrent = current;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dir.x * speed, dir.y * speed);
    }

    IEnumerator PlayAnimation()
    {
        int i = 0;
        while (dir.x != 0 || dir.y != 0)
        {
            if (i == current.walk.Length) i = 0;
            spriteRenderer.sprite = current.walk[i];
            i++;
            yield return new WaitForSeconds(0.2f);
        }
        spriteRenderer.sprite = current.idle;
        anim = null;
    }
}
