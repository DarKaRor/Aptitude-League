using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] DialogueBubble dialogueBubble;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] GameObject gameOver;
    [SerializeField] TextMeshProUGUI record;

    private void Start(){
        GameManager.sharedInstance.LowerVolume();
        record.gameObject.SetActive(!GameManager.sharedInstance.isFreePlay);
        GameManager.sharedInstance.SaveScore();
        SetScore();
    }
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

    public void SetScore(){
        score.text = $"PUNTAJE: <color=blue>{GameManager.sharedInstance.score}</color>";
        record.text = $"RECORD: <color=blue>{PlayerPrefs.GetInt("Score")}</color>";
    }

}
