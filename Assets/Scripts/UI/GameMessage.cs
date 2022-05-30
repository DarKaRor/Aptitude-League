using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameMessage : MonoBehaviour
{
    [SerializeField] GameObject textObj;
    RectTransform textTransform;
    TextMeshProUGUI text;

    private void Start()
    {
        textTransform = textObj.GetComponent<RectTransform>();
        text = textObj.GetComponent<TextMeshProUGUI>();
        textTransform.localScale = Vector3.zero;
        DontDestroyOnLoad(this);
    }
    
    public void ResetMessage()
    {
        text.text = "";
        textTransform.DOKill();
        textTransform.localScale = Vector3.zero;
    }

    public void PlayAnimation(string msg)
    {
        ResetMessage();
        text.text = msg;
        textTransform.DOScale(1,1.5f).OnComplete(() => {
            textTransform.DOScale(0, .5f).SetDelay(0.5f);
        });
    }
}   
