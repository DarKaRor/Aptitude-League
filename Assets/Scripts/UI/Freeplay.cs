using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Freeplay : MonoBehaviour
{
    [SerializeField] GameObject gamesPanel;
    [SerializeField] GameObject GridButton;
    [SerializeField] Button startBtn;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] Image gameImage;
    [SerializeField] TextMeshProUGUI gameNameText;
    [SerializeField] GameObject showcase;
    [SerializeField] Image icon;
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
        // TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
        // text.text = game.name;
        FreeplayBtn freeplayBtn = buttonObj.GetComponent<FreeplayBtn>();
        freeplayBtn.image.sprite = game.image;

        button.onClick.AddListener(() => SelectGame(game));
    }

    public void SelectGame(GameData game)
    {
        gameNameText.text = game.name;
        descriptionText.text = game.description;
        gameImage.sprite = game.image;
        icon.gameObject.SetActive(true);
        icon.sprite = Variables.IntelligenceSprites[game.intelligence];
        startBtn.interactable = true;
        startBtn.onClick.RemoveAllListeners();
        startBtn.onClick.AddListener(() => LoadGame(game.Id));
    }
}
