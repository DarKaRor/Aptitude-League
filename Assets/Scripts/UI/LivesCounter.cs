using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    [SerializeField] GameObject live;
    [SerializeField] Sprite sprite;
    [SerializeField] int lives = 3;
    List<GameObject> livesList = new List<GameObject>();

    void Start()
    {
        SetLives(lives);
    }

    public void LoseLife(){
        if(livesList.Count <= 0) return;
        livesList[livesList.Count - 1].SetActive(false);
        livesList.RemoveAt(livesList.Count - 1);
        lives--;
    }

    public void SetLives(int lives){
        this.lives = lives;
        foreach(GameObject l in livesList) Destroy(l);
        livesList.Clear();
        for (int i = 0; i < lives; i++)
        {
            GameObject go = Instantiate(live, transform);
            go.GetComponent<Image>().sprite = sprite;
            livesList.Add(go);
        }
    }
}
