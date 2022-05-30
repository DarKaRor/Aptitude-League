using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BasketType
{
    Approach,
    Horizontal,
    Vertical,
    Static
}

public class Basket : MonoBehaviour
{
    [SerializeField] public float zAxis = 1;
    [SerializeField] GameObject shadow;
    [SerializeField] SpriteRenderer stopRenderer;
    [SerializeField] GameObject basket;
    [SerializeField] BasketType type;
    [SerializeField] List<Collider2D> colliders;
    SpriteRenderer spriteRenderer;
    SpriteRenderer shadowRenderer;
    Range xRange = new Range(8, -8);
    Range yRange = new Range(-0.43f, 2.14f);
    Range zRange = new Range(.6f, .1f);
    void Start()
    {
        spriteRenderer = basket.GetComponent<SpriteRenderer>();
        shadowRenderer = shadow.GetComponent<SpriteRenderer>();
        SetColliders(false);
        GetRandomPosition();
        GetRandomBehaviour();
        

        switch (type)
        {
            case BasketType.Horizontal:
                basket.transform.DOLocalMoveX(basket.transform.localPosition.x + 5, 2).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                break;
            case BasketType.Approach:
                DOTween.To(() => zAxis, (x) => zAxis = x, zAxis - 0.1f, 2).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                break;
            case BasketType.Vertical:
                basket.transform.DOLocalMoveY(basket.transform.localPosition.y + 5, 2).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Set shadow to follow the basket
        Vector2 newShadowPos = new Vector2(basket.transform.position.x, shadow.transform.position.y);
        shadow.transform.position = newShadowPos;

        UseZValue();
    }

    void UseZValue()
    {
        transform.DOScale(1 - zAxis, 0);
        spriteRenderer.sortingOrder = (int)(-zAxis / .05);
        shadowRenderer.sortingOrder = spriteRenderer.sortingOrder - 1;
        stopRenderer.sortingOrder = shadowRenderer.sortingOrder;
    }



    public void SetColliders(bool value)
    {
        foreach (Collider2D collider in colliders) collider.enabled = value;
    }

    public void GetRandomPosition()
    {
        float x = xRange.GetRandomNumber();
        float y = yRange.GetRandomNumber();
        float z = zRange.GetRandomNumber();

        basket.transform.position = new Vector3(x, y);
        zAxis = z;
    }

    public void GetRandomBehaviour()
    {
        if(DunkIt.instance.difficulty.current <= 1)
        {
            type = BasketType.Static;
            return;
        }

        BasketType[] types = new BasketType[] { BasketType.Approach, BasketType.Horizontal, BasketType.Static, BasketType.Vertical };
        type = Methods.GetRandomElement(types);

    }
}
