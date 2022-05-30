using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DunkIt : MonoBehaviour
{
    public static DunkIt instance;
    int gameId = 5;
    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] GameObject basketPrefab;
    [SerializeField] TextMeshProUGUI balls;
    Counter score = new Counter(10);
    public Counter difficulty = new Counter(5,1,1);
    public Counter chances = new Counter(7);
    Ball ball;
    private void Awake() => instance = instance ? instance : this;
    
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        GameManager.sharedInstance.currentGame = gameId;
        SpawnBaskets();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateChances();
    }

    public void UpdateScore() => scoreDisplay.text = score.current.ToString();

    public void UpdateChances() => balls.text = chances.GetReverseValue().ToString();

    public void AddScore(float distance)
    {
        if (distance > 0.5f) score.changer = 3;
        else if (distance > 0.3f) score.changer = 2;
        else if (distance <= 0.3f) score.changer = 1;

        if (score.Raise())
        {
            GameManager.sharedInstance.LoadRandomGame();
        }

        if(score.current > 5 * difficulty.current)
        {
            difficulty.Raise();
        }
    }

    public void SpawnBaskets()
    {
        float current = difficulty.current;
        int amount = current < 2 ? 1 : current <= 4 ? 2 : 3;
        if(ball.baskets.Count > 0) foreach (Basket basket in ball.baskets) Destroy(basket.gameObject);
        ball.baskets.Clear();
        for(int i = 0; i < amount; i++)
        {
            GameObject basketObj = Instantiate(basketPrefab, new Vector2(0,-0.43f), Quaternion.identity);
            ball.baskets.Add(basketObj.GetComponent<Basket>());
        }

    }

    public void LoseBall()
    {
        if (chances.Raise())
        {
            GameManager.sharedInstance.GameOver();
        };
    }
    
}
