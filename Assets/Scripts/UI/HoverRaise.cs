using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverRaise : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rectTransform;
    float defaultY;
    bool movingDown = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        defaultY = rectTransform.localPosition.y;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (movingDown) return;
        rectTransform.DOLocalMoveY(defaultY + 10, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        movingDown = true;
        rectTransform.DOLocalMoveY(defaultY, 0.2f).OnComplete(() => movingDown = false);
    }

}
