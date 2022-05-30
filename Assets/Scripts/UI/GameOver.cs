using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] DialogueBubble dialogueBubble;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] GameObject gameOver;

    private void Start() => GameManager.sharedInstance.LowerVolume();
    public void Help()
    {
        GameData gameData = GameManager.sharedInstance.gameDatas.Find(i => i.Id == GameManager.sharedInstance.currentGame);
        Dialogue dialogue = Methods.GetRandomElement(gameData.viviHelp);
        Toggle();
        dialogueBubble.dialogue = dialogue;
        dialogueBubble.SpawnVivi(onEnd:Toggle);
    }

    public void Restart() => GameManager.sharedInstance.LoadCurrentOrRandom();

    void Toggle() => GameManager.sharedInstance.ToggleGameObject(gameOver);

    public void BackToMenu() => GameManager.sharedInstance.BackToMenu();

}
