using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class WaterGlass : MonoBehaviour
{

    public static WaterGlass instance;
    public int gameId = 2;
    [HideInInspector] public float fillSpeed = 65f;
    public List<Glass> glasses = new List<Glass>();
    public GameObject prefab;
    public int branching = 4;
    public float spacing = 1;
    Counter chances = new Counter(3);
    Counter maxPoints = new Counter(5);
    Counter difficulty = new Counter(1.5f, 0.1f);
    [SerializeField] public Clock clock;
    [SerializeField] Typewritter typewritter;
    [SerializeField] public Transform glassParent;
    [SerializeField] TextMeshProUGUI number;
    [SerializeField] TextMeshProUGUI answer;
    [SerializeField] int lastToFill;
    [SerializeField] SpriteRenderer background;
    [SerializeField] LivesCounter livesCounter;
    Glass initialGlass;
    int maxGlasses = 2;

    public bool isWaiting = true;

    private void Awake() => instance = instance ? instance : this;

    void Start()
    {
        Camera.main.aspect = 16f / 9f;
        GameManager.sharedInstance.currentGame = gameId;
        clock.Start();
        typewritter.Start();
        typewritter.writtable.AddRange(Variables.numbers);
        CreateFirstGlass();
        ResizeBackground();
        livesCounter.SetLives((int)chances.max);
    }

    // Update is called once per frame
    void Update()
    {
        if(isWaiting) return;
        UpdateTimer();
        GetInput();
    }

    void UpdateTimer()
    {
        if (clock.Update() == 1)
        {
            clock.Reset();
            CheckValues();
        }
    }

    void GetInput()
    {
        if (clock.stop) return;
        switch (typewritter.Update())
        {

            case TypeWritterAction.Sent:
                if (number.text == "?" && typewritter.lastChar == '0') break;
                typewritter.Type();
                break;
            case TypeWritterAction.Return:
                StartFill();
                break;
        }
    }

    public void SetText(string text){
        number.text = text;
    }

    public void StartFill(){
        clock.Stop();
        initialGlass.isFilling = true;
    }

    void CreateFirstGlass()
    {
        isWaiting = false;
        branching = maxGlasses > 4 ? 4 : maxGlasses;
        ResizeReposition();
        StopAllCoroutines();
        foreach (Transform child in glassParent) Destroy(child.gameObject);
        glasses.Clear();
        GameObject first = Instantiate(prefab, glassParent);
        initialGlass = first.GetComponent<Glass>();
    }

    public void CheckValues()
    {
        isWaiting = true;
        bool equality = number.text == lastToFill.ToString();
        if (!equality){
            livesCounter.LoseLife();
            GameManager.sharedInstance.MathGameFail(answer, chances, lastToFill.ToString());
        }
        else
        {
            if (maxPoints.Raise())
            {
                GameManager.sharedInstance.Win();
                return;
            }
            maxGlasses++;
            GameManager.sharedInstance.PlayAudioWin();
        }
        clock.Reset();
        CreateFirstGlass();
        number.text = "?";
    }

    int GetLastFilled()
    {
        Glass currentGlass = initialGlass;
        Glass testGlass = currentGlass.GetFirstChildToFill();
        while (testGlass != null)
        {
            currentGlass = testGlass;
            testGlass = currentGlass.GetFirstChildToFill();
        }
        currentGlass.isLast = true;
        return currentGlass.number;
    }

    void NumberGlasses()
    {
        int number = 1;
        PassByBranch(i =>
        {
            List<Glass> branchOrdered = GetBranch(i).OrderBy(i => i.transform.position.x).ToList();
            for (int j = 0; j < branchOrdered.Count; j++)
            {
                branchOrdered[j].SetNumber(number);
                number++;
            }
        });
    }

    void ResizeReposition()
    {
        Camera.main.transform.position = new Vector3(0, 0, -10);
        Camera.main.orthographicSize = 5;
        Camera.main.transform.position += Vector3.down * spacing * (branching) / 2;
        if (branching > 2) Camera.main.orthographicSize = 3.7f * branching;
        ResizeBackground();
    }

    void ResizeBackground(){
        var width = background.sprite.bounds.size.x;
        var height = background.sprite.bounds.size.y;

        
        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        
        float x = worldScreenWidth / width;
        float y = worldScreenHeight / height;

        background.transform.localScale = new Vector3(x, y, 1);
        background.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
    }


    void PassByBranch(Action<int> action)
    {
        for (int i = 1; i <= branching; i++) action(i);
    }

    List<Glass> GetBranch(int branch) => glasses.Where(i => i.branchLevel == branch).ToList();

    public void OrderChildren()
    {
        NumberGlasses();
        lastToFill = GetLastFilled();
    }
}
