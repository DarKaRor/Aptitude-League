using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFunctionality : MonoBehaviour
{
    public bool isGrounded = false;
    int layerMask;
    Ball ball;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        layerMask = LayerMask.GetMask("Floor");
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.9f,layerMask) ;
        if(hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            isGrounded = (hit.collider.gameObject.CompareTag("Floor"));
        }
        Debug.DrawRay(transform.position, Vector3.down, Color.blue, 0.9f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))   GameManager.sharedInstance.effects.PlayOneShot(ball.dribble);
        
    }

}
