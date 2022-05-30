using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Freeplay : MonoBehaviour
{
    [SerializeField] GameObject gamesPanel;
    [SerializeField] GameObject GridButton;
    void Start()
    {
        
        GameManager.sharedInstance.PlayOST(Methods.LoadOST("2. Freeplay Mode"));
        foreach(GameData game in GameManager.sharedInstance.gameDatas) CreateGridItem(game);
    }

    public void BackToMenu() => GameManager.sharedInstance.BackToMenu();

    public void LoadGame(int id)
    {
        GameManager.sharedInstance.isFreePlay = true;
        GameManager.sharedInstance.LoadGame(id);
    }

    public void CreateGridItem(GameData game)
    {
        GameObject buttonObj = Instantiate(GridButton,gamesPanel.transform);
        Button button = buttonObj.GetComponent<Button>();
        TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
        text.text = game.name;
        button.onClick.AddListener(() => LoadGame(game.Id));
    }
}
