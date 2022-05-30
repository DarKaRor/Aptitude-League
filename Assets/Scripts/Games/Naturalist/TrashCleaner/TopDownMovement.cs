using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMovement : MonoBehaviour
{

    float speed = 5f;
    Vector2 dir;
    Rigidbody2D rb;
    SpriteRenderer renderer;
    [SerializeField] Sprite[] walkSprites;
    [SerializeField] Sprite standing;
    float x;
    float y;
    Coroutine anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        renderer = transform.Find("GFX").GetComponent<SpriteRenderer>();
        StartCoroutine(PlayAnimation());
    }

    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");



        if(dir.x != 0) renderer.flipX = dir.x < 0;

        dir = new Vector2(x, y).normalized;

        if ((dir.x != 0 || dir.y !=0) && anim == null)
        {
            anim = StartCoroutine(PlayAnimation());
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dir.x * speed, dir.y * speed);
    }

    IEnumerator PlayAnimation()
    {
        int i = 0;
        while(dir.x != 0 || dir.y != 0)
        {
            renderer.sprite = walkSprites[i];
            i++;
            if (i == walkSprites.Length) i = 0;
            yield return new WaitForSeconds(0.2f);
        }
        renderer.sprite = standing;
        anim = null;
    }
}
