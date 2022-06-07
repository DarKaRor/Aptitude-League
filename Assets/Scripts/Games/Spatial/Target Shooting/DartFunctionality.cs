using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSettings
{
    public Color color;
    public float distance;
    public int number;

    public PointSettings(Color color, float distance, int number)
    {
        this.color = color;
        this.distance = distance;
        this.number = number;
    }
}
public class DartFunctionality : MonoBehaviour
{
    public bool isGrounded = false;
    Dart dart;
    PointSettings[] points = new PointSettings[]
    {
        new PointSettings(Color.yellow,0.37f,100),
        new PointSettings(Color.red,0.70f,80),
        new PointSettings(Color.cyan,1.08f,60),
        new PointSettings(Color.blue,1.42f,40),
        new PointSettings(Color.white,2,20)
    };


    private void Start()
    {
        dart = FindObjectOfType<Dart>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor")) isGrounded = true;
        else if (collision.CompareTag("Target"))
        {
            dart.dartRb.bodyType = RigidbodyType2D.Static;
            GetScore(collision.GetComponent<Target>());
            dart.StopAllCoroutines();
            dart.CallRespawn(1);
        }

    }

    private void GetScore(Target target)
    {

        if (dart.scored) return;
        TargetShoot.instance.pointText.gameObject.SetActive(false);
        dart.scored = true;
        GameManager.sharedInstance.effects.PlayOneShot(GameManager.sharedInstance.sounds[Sound.Score]);
        float distance = Vector2.Distance(dart.point.transform.position, target.center.transform.position);

        PointSettings point = null;
        for (int i = 0; i < points.Length; i++)
        {
            if (distance <= points[i].distance * (1 - target.zAxis))
            {
                point = points[i];
                break;
            }
        }

        if (point == null) point = points[points.Length - 1];

        TargetShoot.instance.SpawnText(target.transform.position, point.number, point.color, target.zAxis);
    }
}
