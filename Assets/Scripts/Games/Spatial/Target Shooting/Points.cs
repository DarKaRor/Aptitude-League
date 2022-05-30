using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI text;
    RectTransform rectTransform;
    public int number = 0;
    public Vector2 position = Vector2.zero;
    public Color color = Color.white;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        text.DOKill();
        rectTransform.DOKill();
        SetValues();
        text.DOFade(1, 0);
        text.DOFade(0, 2).OnComplete(() => {
            gameObject.SetActive(false);
        });
        rectTransform.DOMoveY(rectTransform.position.y + 2, 2);
    }

    public void GetValues(int number, Vector2 position, Color color)
    {
        this.number = number;
        this.position = position;
        this.color = color;
    }

    public void SetValues()
    {
        rectTransform.position = position;
        text.text = number.ToString();
        text.color = color;
    }
}
