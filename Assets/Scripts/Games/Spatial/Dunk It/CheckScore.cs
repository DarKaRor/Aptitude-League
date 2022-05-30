using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CheckScore : MonoBehaviour
{
    Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score") && !ball.scored && ball.ballRb.velocity.y < 0)
        {
            GameManager.sharedInstance.PlayAudioWin();
            DunkIt.instance.AddScore(collision.GetComponentInParent<Basket>().zAxis);
            ball.StopAllCoroutines();
            ball.StartCoroutine(ball.Respawn(1));
            ball.scored = true;
        }
        else if (collision.CompareTag("Stop"))
        {
            GameManager.sharedInstance.PlayAudioHit();
            if (ball.scored) return;
            ball.StopCoroutine(ball.decrease);
            if (ball.respawn == null) ball.CallRespawn(3);
            ball.postween.Kill();
            ball.postween = DOTween.To(() => ball.zAxis, x => ball.zAxis = x, collision.GetComponentInParent<Basket>().zAxis,0.2f);
        }
    }
}


