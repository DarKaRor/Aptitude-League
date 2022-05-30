using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject dialogueBubble;
    DialogueBubble DialogueBubble;
    bool hasPlayed;

    private void Start()
    {
        GameManager.sharedInstance.isFreePlay = false;
        DialogueBubble = dialogueBubble.GetComponent<DialogueBubble>();
        CheckFirstTime();
    }
    public void CheckFirstTime()
    {
       
        if (PlayerPrefs.HasKey("hasPlayedBeta"))
            hasPlayed = PlayerPrefs.GetInt("hasPlayedBeta") == 1;

        if (!hasPlayed)
        {
            DialogueBubble.SpawnVivi(onEnd: () => {
                GameManager.sharedInstance.hasPlayed = true;
                PlayerPrefs.SetInt("hasPlayedBeta", 1);
                ToggleMenu();
            });
        }

        else ToggleMenu();
    }

    public void ToggleMenu()
    {
        GameManager.sharedInstance.PlayOST(Methods.LoadOST("1. Main Menu"));
        GameManager.sharedInstance.ToggleGameObject(mainMenu);
        dialogueBubble.SetActive(false);
    }

    public void Arcade() => GameManager.sharedInstance.LoadRandomGame();

    public void FreePlay() => GameManager.sharedInstance.FreePlay();

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
