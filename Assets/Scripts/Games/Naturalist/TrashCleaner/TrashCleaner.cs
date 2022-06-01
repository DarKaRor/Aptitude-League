using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Collectables
{
    Trash,
    Speed,
    Magnet,
    Collision,
    None
}

public class TrashCleaner : MonoBehaviour
{
    public static TrashCleaner instance;

    int gameId = 11;
    [SerializeField] Sprite trash;
    [SerializeField] public Sprite magnet;
    [SerializeField] public Sprite collision;
    [SerializeField] public Sprite speed;
    [SerializeField] public GameObject collectablePrefab;
    [SerializeField] AudioClip powerUpAudio;
    [SerializeField] AudioClip trashAudio;
    [SerializeField] Clock clock;
    [SerializeField] public CircleTimer[] timers;
    public List<Collectable> collectables;
    public int collected = 0;
    bool isWinning = false;
    bool canCount = false;


    public Dictionary<Collectables, Sprite> collectableSprites;

    private void Awake() => instance = instance ? instance : this;
    
    void Start()
    {
        GameManager.sharedInstance.currentGame = gameId;
       collectableSprites = new()
       {
           { Collectables.Trash, trash },
           { Collectables.Magnet, magnet },
           { Collectables.Collision, collision },
           { Collectables.Speed, speed},
       };

        StartCoroutine(WaitABitForCounting());
        clock.Start();
    }

    void Update()
    {
        if(canCount) if(collectables.Count <= 0 && !isWinning) StartCoroutine(Win());
        UpdateTimer();
    }

    void UpdateTimer()
    {
        if(clock.Update() == 1)
        {
            clock.Stop();
            StartCoroutine(Lose());
        }
    }

    public Sprite GetCollectableSprite(Collectables type) => Methods.GetValue(collectableSprites, type);

    IEnumerator Lose()
    {
        GameManager.sharedInstance.PlayAudioLose();
        foreach (Collectable collectable in FindObjectsOfType<Collectable>()) collectable.gameObject.SetActive(false);
        FindObjectOfType<TCPlayer>().StopAllCoroutines();
        GameManager.sharedInstance.LowerVolume();
        yield return new WaitForSeconds(3);
        GameManager.sharedInstance.GameOver();

    }
    IEnumerator Win()
    {
        isWinning = true;
        GameManager.sharedInstance.PlayAudioWin(1);
        clock.Stop();
        GameManager.sharedInstance.LowerVolume();
        yield return new WaitForSeconds(3);
        GameManager.sharedInstance.LoadCurrentOrRandom();
    }

    IEnumerator WaitABitForCounting()
    {
        yield return new WaitForSeconds(1);
        canCount = true;
    }
    public void GetTrash()
    {
        GameManager.sharedInstance.PlayEffect(trashAudio);
        collected++;
        if(collected % 20 == 0) clock.AddTime(5);
    }

    public void GetPowerUp()
    {
        GameManager.sharedInstance.PlayEffect(powerUpAudio);
    }

    public int ActivateTimer(Sprite sprite, float time)
    {
        Debug.Log("Tried to activate timer");
        int index = -1;
        for(int i = 0; i < timers.Length; i++)
        {
            if (!timers[i].gameObject.activeSelf)
            {
                index = i;
                break;
            }
        }
        if (index == -1) return index;

        CircleTimer timer = timers[index];
        timer.gameObject.SetActive(true);
        timer.itemImage.sprite = sprite;
        timer.time.max = time;
        timer.ResetTimer();
        
        return index;
    }
}
