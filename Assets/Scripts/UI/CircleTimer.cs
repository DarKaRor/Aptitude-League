using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleTimer : MonoBehaviour
{
    public Counter time;
    [SerializeField] public Image fillImage;
    [SerializeField] public Image itemImage;

    void Start()
    {
        
    }
    void Update()
    {
        UpdateTime();
        UpdateFill();
    }

    void UpdateTime()
    {
        time.changer = Time.deltaTime;
        if(time.Raise()) gameObject.SetActive(false);
        
    }

    void UpdateFill()
    {
        fillImage.fillAmount = 1 - time.current / time.max;
    }

    public void ResetTimer()
    {
        time.current = 0;
        fillImage.fillAmount = 1;
    }
}
