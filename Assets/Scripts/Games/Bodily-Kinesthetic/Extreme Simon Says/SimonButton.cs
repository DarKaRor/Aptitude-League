using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SimonButton : MonoBehaviour
{
    public SimonItem item;
    public Button btn;
    TextMeshProUGUI text;
    Image symbol;

    private void Start()
    {
        btn = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        symbol = transform.Find("Image").GetComponent<Image>();

        btn.onClick.AddListener(() =>
        {
            ExtremeSimonSays.instance.PressButton(item);
        });
        GetDataFromItem();
    }

    public void GetDataFromItem()
    {
        if(item.icon != null)
        {
            symbol.enabled = true;
            symbol.sprite = item.icon;
        }
        if(item.symbol != null)
        {
            text.enabled = true;
            text.text = item.symbol;
        }

        btn.image.color = item.color;
    }
}
