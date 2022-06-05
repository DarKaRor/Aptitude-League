using UnityEngine;
using DG.Tweening;

public static class TweenUtils
{   
    public static void InfiniteBounce(RectTransform rectTransform, float bounce = 1.1f, float duration = 0.5f)
    {
        rectTransform.DOKill();
        rectTransform.DOScaleY(bounce,duration).SetLoops(-1, LoopType.Yoyo);
    }

    public static void InfiniteScale(RectTransform rectTransform, float scale = 1.1f, float duration = 0.5f)
    {
        rectTransform.DOKill();
        rectTransform.DOScale(scale,duration).SetLoops(-1, LoopType.Yoyo);
    }
}
