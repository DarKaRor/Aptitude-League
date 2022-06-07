using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject dialogueBubble;
    [SerializeField] GameObject logo;
    [SerializeField] RectTransform[] buttons;
    [SerializeField] GameObject settings;
    DialogueBubble DialogueBubble;
    bool hasPlayed;

    private void Start()
    {
        GameManager.sharedInstance.isFreePlay = false;
        DialogueBubble = dialogueBubble.GetComponent<DialogueBubble>();
        CheckFirstTime();
        GameManager.sharedInstance.RestoreScore();
        GameManager.sharedInstance.effects.Stop(); 
    }

    public void HoverRaise(int index){
        RectTransform transform = buttons[index];
        transform.DOLocalMoveY(transform.localPosition.y + 10, 0.2f);
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

        if(mainMenu.activeSelf) TweenUtils.InfiniteScale(logo.GetComponentInChildren<RectTransform>(), 1.1f, 0.4f);
    }

    public void ToggleSettings(){
        GameManager.sharedInstance.ToggleGameObject(settings);
        GameManager.sharedInstance.ToggleGameObject(mainMenu);

    }

    public void Arcade() => GameManager.sharedInstance.LoadRandomGame();

    public void FreePlay() => GameManager.sharedInstance.FreePlay();

    public void Credits() => GameManager.sharedInstance.LoadCredits();

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }
}
