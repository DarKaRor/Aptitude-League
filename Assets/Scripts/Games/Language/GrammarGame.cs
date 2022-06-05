using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class GrammarQuestion
{
    public string question;
    public string[] answers;
    public GrammarQuestion(string question, string[] answers)
    {
        this.question = question;
        this.answers = answers;
    }
}

public class GrammarGame : MonoBehaviour
{
    [SerializeField] Clock clock;
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] TextMeshProUGUI answer;
    [SerializeField] Button[] answers;
    Counter maxPoints = new Counter(10);
    Counter chances = new Counter(3);
    GrammarQuestion currentQuestion;
    int gameID = 4;

    string[] toLetter = new string[] {"A","B","C","D"};

    void Start()
    {
        GameManager.sharedInstance.currentGame = gameID;
        clock.Start();
        currentQuestion = new GrammarQuestion(null, null);
        GetRandomQuestion();
    }


    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        if(clock.Update() == 1){

        }
    }

    void GetRandomQuestion()
    {
        currentQuestion = Methods.GetRandomElement(Variables.grammarQuestions.Where(i => i.question!=currentQuestion.question).ToArray());
        question.text = currentQuestion.question;
        foreach(Button a in answers) a.gameObject.SetActive(false);
        string[] shuffled = Methods.Shuffle(currentQuestion.answers.Clone() as string[]);

        for(int i = 0; i < shuffled.Length; i++)
        {
            TextMeshProUGUI t = answers[i].GetComponentInChildren<TextMeshProUGUI>();
            answers[i].gameObject.SetActive(true);
            t.text = $"{toLetter[i]}) {shuffled[i]}";
        }
        
    }

    public void CheckValues(int index)
    {
        SetEnable(false);
        string a = currentQuestion.answers[0];
        string answered = cleanAnswer(answers[index].GetComponentInChildren<TextMeshProUGUI>().text);
        bool equality = answered == a.ToLower();
        if (equality) Win();
        else Lose();
    }

    string cleanAnswer(string answer)  => answer.Substring(2).ToLower().Trim();

    IEnumerator ActionAfterTime(float time, System.Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }

    void Win(){
        if(maxPoints.Raise()){
            clock.Stop();
            GameManager.sharedInstance.Win();
            return;
        }
        GameManager.sharedInstance.PlayAudioWin();
        Reset();
    }

    void Lose(){
        clock.Stop();
        GameManager.sharedInstance.PlayAudioLose();
        GameManager.sharedInstance.FadeAnswer(answer, currentQuestion.answers[0]);
        if(chances.Raise()){
            StartCoroutine(ActionAfterTime(2, () => GameManager.sharedInstance.GameOver()));
            return;
        }
        StartCoroutine(ActionAfterTime(2, Reset));
    }

    void SetEnable(bool enable){
        foreach(Button a in answers) a.enabled = enable;
    }
    public void Reset()
    {
        SetEnable(true);
        GetRandomQuestion();
        clock.Reset();
    }

}
