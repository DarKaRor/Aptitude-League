using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

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
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] TextMeshProUGUI answer;

    Counter maxPoints = new Counter(5);
    Counter chances = new Counter(3);
    GrammarQuestion currentQuestion;
    int gameID = 4;

    void Start()
    {
        GameManager.sharedInstance.currentGame = gameID;
        clock.Start();
        currentQuestion = new GrammarQuestion(null, null);
        GetRandomQuestion();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) CheckValues();
        UpdateTimer();
    }

    void UpdateTimer()
    {
        if(clock.Update() == 1) CheckValues();
    }

    void GetRandomQuestion()
    {
        currentQuestion = Methods.GetRandomElement(Variables.grammarQuestions.Where(i => i.question!=currentQuestion.question).ToArray());
        question.text = currentQuestion.question;
        inputField.text = question.text;
    }

    public void CheckValues()
    {
        bool equality = Methods.isAny(inputField.text, currentQuestion.answers);
        if (equality) GameManager.sharedInstance.GameWin(ref maxPoints);
        else GameManager.sharedInstance.MathGameFail(answer, chances, currentQuestion.answers[0]);
        Reset();
    }

    public void Reset()
    {
        GetRandomQuestion();
        clock.Reset();
    }

}
