using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoseAction : MonoBehaviour
{
    public Button btn;
    public Image image;
    public int index;

    public void SetIndex()
    {
        btn.onClick.AddListener(() =>
        {
            DoThePose.instance.CheckValues(index);
        });
    }
    public void SetEnable(bool val = true)
    {
        btn.interactable = val;
        image.enabled = val;
    }
}
