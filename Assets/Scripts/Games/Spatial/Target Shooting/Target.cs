using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] public float zAxis = .6f;
    [SerializeField] GameObject shadow;
    [SerializeField] GameObject target;
    [SerializeField] BasketType type;
    [SerializeField] public GameObject center;
    public Collider2D collider2d;
    SpriteRenderer spriteRenderer;
    SpriteRenderer shadowRenderer;
    Range xRange = new Range(5, -5);
    Range zRange = new Range(.5f, .1f);

    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<CircleCollider2D>();
        shadowRenderer = shadow.GetComponent<SpriteRenderer>();
        spriteRenderer = target.GetComponent<SpriteRenderer>();
        GetRandomBehaviour();
        GetRandomPosition();
        UseZValue();

    }

    // Update is called once per frame
    void Update()
    {
        // Set shadow to follow the target
        Vector2 newShadowPos = new Vector2(target.transform.position.x, shadow.transform.position.y);
        shadow.transform.position = newShadowPos;

        UseZValue();
        
    }

    void UseZValue()
    {
        transform.localScale = new Vector3(1 - zAxis, 1 - zAxis, 1 - zAxis);
        transform.position = new Vector2(transform.position.x, -3.7f + zAxis / .14f);
        spriteRenderer.sortingOrder = (int)(-zAxis / .01);
        shadowRenderer.sortingOrder = spriteRenderer.sortingOrder - 2;
    }

    public void GetRandomPosition()
    {
        float x = xRange.GetRandomNumber();
        float z = zRange.GetRandomNumber();

        transform.position = new Vector3(x,target.transform.position.y);
        zAxis = z;
    }

    public void GetRandomBehaviour()
    {
        if (TargetShoot.instance.round <= 5)
        {
            type = BasketType.Static;
            return;
        }

        BasketType[] types = new BasketType[] { BasketType.Approach, BasketType.Horizontal, BasketType.Static};
        type = Methods.GetRandomElement(types);
    }

}
