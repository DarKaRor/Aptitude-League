using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViviButton
{
    public Button button;
    public DialogueOption option;
    TextMeshProUGUI text;

    public ViviButton(Button button, DialogueOption option)
    {
        this.button = button;
        this.option = option;
        text = button.GetComponentInChildren<TextMeshProUGUI>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            ViviListens.instance.SelectOption(this);
        });
    }

    public void SetText() => text.text = option.option;


}

public class DialogueOption
{
    public string option;
    public int index;

    public DialogueOption(string option, int index)
    {
        this.option = option;
        this.index = index;
    }
}

public class DialogueAnswer
{
    public DialogueOption[] options;
    public Dialogue dialogue;

    public DialogueAnswer(DialogueOption[] options, Dialogue dialogue)
    {
        this.options = options;
        this.dialogue = dialogue;
    }
}

public class Conversation
{

    public DialogueAnswer[] dialogues;

    public Conversation(DialogueAnswer[] dialogues)
    {
        this.dialogues = dialogues;
    }

    public DialogueAnswer GetDialogueByOption(DialogueOption option){
        DialogueAnswer dialogue;
        try
        {
            dialogue = dialogues[option.index];
        }
        catch
        {
            dialogue = null;
        }
        Debug.Log(dialogue);
        return dialogue;
    }
}


public class ViviListens : MonoBehaviour
{
    public static ViviListens instance;
    [SerializeField] DialogueBubble dialogueBubble;
    [SerializeField] Button[] buttons;
    Conversation conversation;
    [SerializeField] TextMeshProUGUI round;
    int currentIndex = 0;
    int nextGame = 0;
    GameData gameData;

    private void Awake() => instance = instance ? instance : this;

    void Start()
    {
        gameData = GameManager.sharedInstance.gameDatas.Find(i => i.Id == GameManager.sharedInstance.currentGame);
        round.text = "Ronda " + GameManager.sharedInstance.score;
        SetEnable(false);

        conversation = new Conversation(
            new DialogueAnswer[]{
                new DialogueAnswer(
                    new DialogueOption[]{
                        new DialogueOption("Bien", 1),
                        new DialogueOption("Mal", 2),
                        new DialogueOption("Tengo prisa", 3),
                    },
                    new Dialogue(
                        new Paragraph[]{
                            new Paragraph(GetRandomGreeting(), null)
                        }
                    )
                ),
                new DialogueAnswer(
                    new DialogueOption[]{
                        new DialogueOption("Excelente", 4),
                        new DialogueOption("Más o menos", 5),
                        new DialogueOption("Tengo prisa", 3),
                    },
                    new Dialogue(
                        new Paragraph[]{
                            new Paragraph("¡Me alegra mucho!", ViviSprites.Happy()),
                            new Paragraph("Cuéntame, ¿qué tan bien crees que lo hiciste?", ViviSprites.Default()),
                        }
                    )
                ),
                new DialogueAnswer(
                    null,
                    new Dialogue(
                        new Paragraph[]{
                            new Paragraph("No te preocupes, ¡siempre puedes volver a intentarlo!", ViviSprites.Default()),
                            new Paragraph("Trata de relajarte y divertirte un rato, ¿sí? Mereces distraerte un poco.", ViviSprites.Calm()),
                        }
                    )
                ),
                new DialogueAnswer(
                    null,
                    new Dialogue(
                        new Paragraph[]{
                            new Paragraph("Entiendo, entonces dejaré que continúes jugando.", ViviSprites.Happy()),
                            new Paragraph("Sabes que siempre estaré aquí para ti.", ViviSprites.Calm()),
                        }
                    )
                ),
                new DialogueAnswer(
                    null,
                    new Dialogue(
                        new Paragraph[]{
                            new Paragraph("Muy bien, me gusta tu iniciativa", ViviSprites.Happy()),
                            new Paragraph("Espero que puedas seguir disfrutando del juego", ViviSprites.Default()),
                            new Paragraph("Nos vemos.", ViviSprites.Happy()),
                        }
                    )
                ),
                new DialogueAnswer(
                    null,
                    new Dialogue(
                        new Paragraph[]{
                            new Paragraph("Descuida, ya has llegado hasta este punto", ViviSprites.Happy()),
                            new Paragraph("Puede que el último juego no se te dé muy bien...", ViviSprites.Explain1()),
                            new Paragraph("Pero no te preocupes, ¡siempre puedes volver a intentarlo! Yo siempre te apoyaré.", ViviSprites.Happy()),
                        }
                    )
                )
            }
        );

        List<Paragraph> helpParagraphNext = new List<Paragraph>();
        helpParagraphNext.AddRange(conversation.dialogues[2].dialogue.paragraphs);
        helpParagraphNext.AddRange(GetNextGame());

        List<Paragraph> helpCurrent = new List<Paragraph>();
        helpCurrent.AddRange(conversation.dialogues[5].dialogue.paragraphs);
        helpCurrent.AddRange(GetCurrentGame());


        conversation.dialogues[2].dialogue.paragraphs = helpParagraphNext.ToArray();
        conversation.dialogues[5].dialogue.paragraphs = helpCurrent.ToArray();

        dialogueBubble.dialogue = conversation.dialogues[currentIndex].dialogue;
        dialogueBubble.standPosition = dialogueBubble.viviTransform.anchoredPosition;

        StartSpeak();
    }

    string GetRandomGreeting(){
        string[] grettings = new string[]{
            "Hola, parece que has llegado a la ronda [%], ¿cómo te va?",
            "Enhorabuena, has llegado a la ronda [%], ¿cómo te sientes?",
            "Ahora estás en la ronda [%], ¿qué tal estás?",
        };

        return Methods.GetRandomElement(grettings).Replace("[%]", GameManager.sharedInstance.score.ToString());
    }

    void StartSpeak()
    {
        TweenUtils.FadeInCanvasGroup(dialogueBubble.canvasGroup, 0.5f, () =>
        {
            dialogueBubble.StartSpeak(() =>
            {
                TweenUtils.FadeOutCanvasGroup(dialogueBubble.canvasGroup);
                DialogueOption[] options = conversation.dialogues[currentIndex].options;
                if (options == null){
                    StartCoroutine(WaitForSeconds());
                    return;
                }
                if (options.Length >= 0) SetButtons(options);
                else StartCoroutine(WaitForSeconds());
            });
        });
    }

    void SetButtons(DialogueOption[] options)
    {
        for (int i = 0; i < options.Length; i++)
        {
            ViviButton button = new ViviButton(buttons[i], options[i]);
            button.SetText();
            button.button.gameObject.SetActive(true);
        }
    }

    void SetEnable(bool enable, int quantity = 3)
    {
        for (int i = 0; i < quantity; i++)
        {
            if (i >= buttons.Length) break;
            buttons[i].gameObject.SetActive(enable);
        }
    }

    public void SelectOption(ViviButton button)
    {
        SetEnable(false);
        currentIndex = button.option.index;
        DialogueAnswer dialogueAnswer = conversation.GetDialogueByOption(button.option);
        if(dialogueAnswer == null){
            StartCoroutine(WaitForSeconds());
            return;
        }
        dialogueBubble.dialogue = dialogueAnswer.dialogue;
        StartSpeak();
    }

    IEnumerator WaitForSeconds(float seconds = 2)
    {
        yield return new WaitForSeconds(seconds);
        GameManager.sharedInstance.LoadGame(nextGame);
    }

    public Paragraph[] GetNextGame(){
        List<Paragraph> paragraphs = new List<Paragraph>();
        GameData randomGame = GameManager.sharedInstance.GetRandomGame();
        paragraphs.Add(new Paragraph("Ahora vas a jugar a " + randomGame.name, ViviSprites.Default()));
        paragraphs.Add(new Paragraph("Te daré un pequeño consejo...", ViviSprites.Happy()));
        Dialogue randomDialogue = Methods.GetRandomElement(randomGame.viviHelp);
        paragraphs.AddRange(randomDialogue.paragraphs);
        paragraphs.Add(new Paragraph("Eso es todo, ¡espero verte pronto!", ViviSprites.Happy()));
        nextGame = randomGame.Id;
        return paragraphs.ToArray();
    }

    public Paragraph[] GetCurrentGame(){
        List<Paragraph> paragraphs = new List<Paragraph>();
        GameData currentGame = GameManager.sharedInstance.gameDatas.Find(i => i.Id == GameManager.sharedInstance.currentGame);
        paragraphs.Add(new Paragraph($"Acabas de jugar {currentGame.name}, ¿no es así?", ViviSprites.Default()));
        paragraphs.Add(new Paragraph("Te daré un pequeño consejo...", ViviSprites.Happy()));
        Dialogue dialogue = Methods.GetRandomElement(currentGame.viviHelp);
        paragraphs.AddRange(dialogue.paragraphs);
        paragraphs.Add(new Paragraph("Eso es todo, ¡espero verte pronto!", ViviSprites.Happy()));
        return paragraphs.ToArray();
    }
}
