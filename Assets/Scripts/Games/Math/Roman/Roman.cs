using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using static RomanUtils;

public class Roman : MonoBehaviour
{
    int gameId = 0;
    [SerializeField] TextMeshProUGUI num1;
    [SerializeField] TextMeshProUGUI num2;
    //[SerializeField] Button button;
    [SerializeField] TextMeshProUGUI answer;
    [SerializeField] Sprite[] drawings;
    [SerializeField] Image[] drawingsImage;
    [SerializeField] LivesCounter livesCounter;
    public bool leftRoman = false;
    int maxRange = 100;
    int range;
    int maxTimer = 20;
    Counter chances = new Counter(3);
    Counter maxPoints = new Counter(15);
    Counter difficulty = new Counter(1, .2f, .2f);
    public bool isWaiting = false;

    [SerializeField] Clock clockObject;
    [SerializeField] Typewritter typewritter;


    void Start()
    {
        Restart();
        clockObject.timer.max = maxTimer + maxTimer * difficulty.current * 0.3f;
        SetDifficulty();
        GetRandomNumber();
        clockObject.Start();

        typewritter.Start();
        typewritter.writtable.AddRange(Variables.numbers);

        foreach (char key in romanNumbersDictionary.Keys) typewritter.writtable.Add(key.ToString());

        GameManager.sharedInstance.currentGame = gameId;
    }

    void Update()
    {
        if (isWaiting) return;
        UpdateTimer();
        GetInput();
    }

    void GetInput()
    {
        switch (typewritter.Update())
        {
            case TypeWritterAction.Return:
                CheckValues();
                break;
            case TypeWritterAction.Sent:
                bool shouldSend = false;
                char key = typewritter.lastChar;
                if (!leftRoman && romanNumbersDictionary.ContainsKey(key)) shouldSend = true;
                if (leftRoman && Methods.isAny(key.ToString(), Variables.numbers)) shouldSend = true;
                if (shouldSend)
                {
                    typewritter.Type();
                    if (GetAnswer().Length == num2.text.Length) CheckValues();
                }
                break;
        }
    }

    void SetDrawings(){
        int quantity = Random.Range(5,drawingsImage.Length);
        for (int i = 0; i < drawingsImage.Length ; i++)
        {
            Image img = drawingsImage[i];
            if(i >= quantity){
                img.gameObject.SetActive(false);
                continue;
            }
            RectTransform rect = img.GetComponent<RectTransform>();
            img.gameObject.SetActive(true);
            img.sprite = drawings[Random.Range(0, drawings.Length)];
            
            SetInRandomPosition(rect);
            SetRandomRotation(rect);
        }
    }

    void SetInRandomPosition(RectTransform t){
        RectTransform canvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();
        Vector2 randomPosition = new Vector2(Random.Range(0, canvasRect.sizeDelta.x), Random.Range(0, canvasRect.sizeDelta.y));
        t.anchoredPosition = randomPosition;
    }

    void SetRandomRotation(RectTransform t){
        t.localRotation = Quaternion.Euler(0,0, Random.Range(0, 360));
    }

    IEnumerator ActionAfterTime(float time, System.Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }

    void UpdateTimer()
    {
        if (clockObject.Update() == 1)
        {
            clockObject.Reset();
            CheckValues(true);
        };
    }
    public bool AreEqual()
    {
        string result = leftRoman ? IntToRoman(num2.text) : RomanToInt(num2.text);
        return num1.text == result;
    }

    public void CheckValues(bool forceLose = false)
    {
        isWaiting = true;
        if (num2.text == "?" && !forceLose) return;
        if (!AreEqual() || forceLose)
        {
            Lose();
            return;
        }
        else if (GameManager.sharedInstance.MathGameWin(ref maxPoints, ref difficulty, SetDifficulty)) return;

        StartCoroutine(ActionAfterTime(1, () => NextRound()));
    }

    void Lose()
    {
        isWaiting = true;
        livesCounter.LoseLife();
        GameManager.sharedInstance.MathGameFail(answer, chances, GetAnswer());
        StartCoroutine(ActionAfterTime(2, () =>
        {
            isWaiting = false;
            NextRound();
        }));
    }

    public void NextRound()
    {
        isWaiting = false;
        Restart();
        GetRandomNumber();
        clockObject.Reset();
    }

    public string GetAnswer() => leftRoman ? RomanToInt(num1.text) : IntToRoman(num1.text);

    public void Restart()
    {
        num1.text = "?";
        num2.text = "?";
        SetDrawings();
    }

    public void GetRandomNumber()
    {
        leftRoman = Random.Range(0, 2) >= 0.5; // True o False random.
        string randomNum = Random.Range(1, range + 1).ToString(); // N�mero aleatorio entre 1 y el rango
        string value = GetNeededType(randomNum); // Se obtiene romano de ser necesario
        num1.text = value; // Se aplica
    }

    public void SetDifficulty()
    {
        range = Mathf.RoundToInt(maxRange * difficulty.current);

        clockObject.timer.max -= maxTimer * difficulty.current * .3f;
        if (clockObject.timer.max < 5) clockObject.timer.max = 5;
    }

    public string GetNeededType(string n) => leftRoman ? IntToRoman(n) : n;

}
