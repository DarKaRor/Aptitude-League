using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetShoot : MonoBehaviour
{
    public static TargetShoot instance;
    int gameID = 6;
    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] GameObject targetPrefab;
    [SerializeField] TextMeshProUGUI lives;
    [SerializeField] public Points pointText;
    Counter score = new Counter(2000);
    public Counter difficulty = new Counter(5, 1, 1);
    public Counter chances = new Counter(999);
    public int round = 0;
    Dart dart;
    public bool isWaiting = false;

    private void Awake() => instance = instance ? instance : this;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.sharedInstance.currentGame = gameID;
        dart = FindObjectOfType<Dart>();
        SpawnTargets();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateChances();
    }


    public void UpdateScore() => scoreDisplay.text = score.current.ToString();

    public void UpdateChances() => lives.text = chances.GetReverseValue().ToString();


    public void AddScore(float distance, int number)
    {
        if (distance > 0.45f) score.changer = 3;
        else if (distance > 0.3f) score.changer = 2;
        else if (distance <= 0.3f) score.changer = 1;

        score.changer *= number;

        if (score.Raise())
        {
            isWaiting = true;
            GameManager.sharedInstance.Win();
        }
        round++;
    }

    public void SpawnTargets()
    {
        int amount = round < 5 ? 1 : round <= 10 ? 2 : 3;
        if (dart.targets.Count > 0) foreach (Target target in dart.targets) Destroy(target.gameObject);
        dart.targets.Clear();
        for (int i = 0; i < amount; i++)
        {
            GameObject targetObj = Instantiate(targetPrefab, new Vector2(0, -0.43f), Quaternion.identity);
            dart.targets.Add(targetObj.GetComponent<Target>());
        }
    }


    public void LoseLive()
    {
        if (chances.Raise())
        {
            GameManager.sharedInstance.GameOver();
        };
    }

    public void SpawnText(Vector2 position, int number, Color color, float distance)
    {
        pointText.GetValues(number, position, color);
        pointText.gameObject.SetActive(true);
        AddScore(distance,number);
    }
}
