using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverRaise : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rectTransform;
    float defaultY;
    bool movingDown = false;
    AudioClip hover;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        defaultY = rectTransform.localPosition.y;
        hover = Methods.loadAudio("select");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (movingDown) return;
        GameManager.sharedInstance.PlayEffect(hover);
        rectTransform.DOLocalMoveY(defaultY + 10, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        movingDown = true;
        rectTransform.DOLocalMoveY(defaultY, 0.2f).OnComplete(() => movingDown = false);
    }

}
