using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class MathKing : MonoBehaviour
{
    int gameId = 1;
    [SerializeField] Clock clockObject;
    [SerializeField] Typewritter typewritter;
    [SerializeField] TextMeshProUGUI number;
    [SerializeField] TextMeshProUGUI operation;
    [SerializeField] TextMeshProUGUI answer;
    [SerializeField] Sprite[] drawings;
    [SerializeField] Image[] drawingsImage;
    [SerializeField] LivesCounter livesCounter;
    //[SerializeField] Button button;
    int maxRange = 100;
    int range;
    int maxTimer = 20;
    Counter chances = new Counter(3);
    Counter maxPoints = new Counter(15);
    Counter difficulty = new Counter(1, .1f, .1f);
    Operation currentOperation;

    public bool isWaiting = false;

    void Start()
    {
        //button.onClick.AddListener(() => CheckValues());
        clockObject.timer.max = maxTimer + maxTimer * difficulty.current * 0.3f;
        SetDifficulty();
        GetRandomOperation();

        clockObject.Start();
        typewritter.Start();

        typewritter.writtable.AddRange(Variables.numbers);
        typewritter.writtable.AddRange(new string[] { ".", ",", "-" });

        GameManager.sharedInstance.currentGame = gameId;
    }


    void Update()
    {
        if (isWaiting) return;
        GetInput();
        UpdateTimer();
    }

    void SetDrawings()
    {
        int quantity = Random.Range(5, drawingsImage.Length);
        for (int i = 0; i < drawingsImage.Length; i++)
        {
            Image img = drawingsImage[i];
            if (i >= quantity)
            {
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

    void SetInRandomPosition(RectTransform t)
    {
        RectTransform canvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();
        Vector2 randomPosition = new Vector2(Random.Range(0, canvasRect.sizeDelta.x), Random.Range(0, canvasRect.sizeDelta.y));

        randomPosition = new Vector2(randomPosition.x - t.sizeDelta.x / 2, randomPosition.y - t.sizeDelta.y / 2);
        t.anchoredPosition = randomPosition;
    }

    void SetRandomRotation(RectTransform t)
    {
        t.localRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    void CheckValues(bool forceLose = false)
    {
        isWaiting = true;
        if (number.text == typewritter.defaultString && !forceLose) return;
        if (!AreEqual() || forceLose)
        {
            Lose();
            return;
        }
        else if (GameManager.sharedInstance.MathGameWin(ref maxPoints, ref difficulty, SetDifficulty)) return;

        StartCoroutine(ActionAfterTime(1, () => NextRound()));
    }
    void NextRound()
    {
        isWaiting = false;
        Restart();
        GetRandomOperation();
        clockObject.Reset();
    }

    void Restart()
    {
        number.text = typewritter.defaultString;
        operation.text = typewritter.defaultString;
        
    }

    bool AreEqual() => number.text == currentOperation.Solve();


    void GetInput()
    {
        switch (typewritter.Update())
        {
            case TypeWritterAction.Return:
                CheckValues();
                break;
            case TypeWritterAction.Sent:
                typewritter.Type();
                if (currentOperation.Solve().Length == number.text.Length) CheckValues();
                break;
        }
    }

    IEnumerator ActionAfterTime(float time, System.Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }

    void Lose()
    {
        isWaiting = true;
        livesCounter.LoseLife();
        GameManager.sharedInstance.MathGameFail(answer, chances, currentOperation.Solve());
        StartCoroutine(ActionAfterTime(2, () =>
        {
            isWaiting = false;
            NextRound();
        }));
    }

    void UpdateTimer()
    {
        if (clockObject.Update() == 1)
        {
            clockObject.Reset();
            CheckValues(true);
        };
    }
    public void SetDifficulty() => range = Mathf.RoundToInt(maxRange * difficulty.current);


    public void GetRandomOperation()
    {
        char op = Methods.GetRandomElement(new char[] { '+', '*', '-', '/' });
        int num1 = GetRandomNumber();
        int num2 = GetRandomNumber();

        if (op == '*') num1 = Random.Range(0, 9);

        if (op == '/')
        {
            while (Methods.isPrime(num1)) num1 = GetRandomNumber();
            while (num1 % num2 != 0 && num2 != 1) num2 = Random.Range(2, num1);
        }

        currentOperation = new Operation(num1, num2, op);

        operation.text = currentOperation.ToStringStylized();
        
        SetDrawings();
    }

    public int GetRandomNumber() => Random.Range(1, range + 1);
}
