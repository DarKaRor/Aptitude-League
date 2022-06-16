using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] DialogueBubble dialogueBubble;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] GameObject gameOver;
    [SerializeField] TextMeshProUGUI record;
    [SerializeField] Image background;
    [SerializeField] Image vivi;
    [SerializeField] Sprite newRecordImage;
    [SerializeField] Sprite newRecordVivi;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] AudioClip newRecordSound;
    [SerializeField] AudioClip gameOverSound;
    string newRecordText = "¡Nuevo Récord!";
    

    private void Start(){
        SetScore();
        GameManager.sharedInstance.SaveScore();
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
        AudioClip clip = gameOverSound;
        score.text = $"PUNTAJE: <color=blue>{GameManager.sharedInstance.score}</color>";
        if(!GameManager.sharedInstance.isFreePlay){
            record.gameObject.SetActive(true);
            record.text = $"RECORD: <color=blue>{PlayerPrefs.GetInt("Score")}</color>";
            if(GameManager.sharedInstance.score > 0 && GameManager.sharedInstance.score > PlayerPrefs.GetInt("Score")){
                clip = newRecordSound;
                title.text = newRecordText;
                background.sprite = newRecordImage;
                vivi.sprite = newRecordVivi;
                record.text = record.text.Replace("<color=blue>", "<color=red>");
                score.text = score.text.Replace("<color=blue>", "<color=red>");
            }
        }

        GameManager.sharedInstance.ForcePlayOST(clip);
    }

}
