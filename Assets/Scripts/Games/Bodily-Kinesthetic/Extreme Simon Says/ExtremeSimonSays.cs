using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class ExtremeSimonSays : MonoBehaviour
{
    public static ExtremeSimonSays instance;
    int gameId = 9;
    [SerializeField] Clock clock;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform buttonsPanel;
    [SerializeField] Image TVImage;
    [SerializeField] Image TVDisplay;
    [SerializeField] TextMeshProUGUI TVtext;
    string copy = "";
    string pattern = "";
    float speed = .75f;
    Counter items = new Counter(4);
    Counter rounds = new Counter(6);
    List<SimonItem> currentItems = new List<SimonItem>();
    List<string> currentNames = new List<string>();
    public bool isPlaying = false;
    public bool force = false;
    bool lost = false;
    public string toForce = "";


    private void Awake() => instance = instance ? instance : this;    
    
    void Start()
    {
        GameManager.sharedInstance.currentGame = gameId;
        Invoke("ForceLowVolume", 1f);
        clock.Start();

        foreach(string name in new string[] { "Rojo", "Azul", "Verde", "Amarillo"})
        {
            SimonItem newItem = Variables.simonItems.First(i => i.name == name);
            currentItems.Add(newItem);
            currentNames.Add(name);
            AddButton(newItem);
        }

        AddRandomKeyPattern();
        StartCoroutine(Play(2));
    }

    void Update()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        if (lost) return;
        if (clock.Update() == 1)
        {
            clock.Stop();
            StopAllCoroutines();
            StartCoroutine(Lost());
        }
    }

    void ForceLowVolume()
    {
        GameManager.sharedInstance.music.volume = 0.2f;
    }

    public void PressButton(SimonItem item)
    {
        if (isPlaying) return;
        AddKeyCopy(item.name);
        if(CheckValues()) DisplayItem(item,false);
    }

    bool CheckValues()
    {
        string[] patternEach = pattern.Split("/");
        string[] copyEach = copy.Split("/");

        for (int i = 0; i < copyEach.Length - 1; i++)
        {
            if (copyEach[i] != patternEach[i])
            {

                GameManager.sharedInstance.PlayAudioLose();
                Reset();
                ResetDisplay();
                StartCoroutine(Play(2));
                return false;
            }
        }

        if (copy == pattern && !items.Raise())
        {
            GameManager.sharedInstance.PlayAudioWin();
            clock.AddTime(3);
            copy = "";
            AddRandomKeyPattern();
            StartCoroutine(Play(2));
            return true;
        }

        if (items.reached)
        {
            speed -= speed * 0.13f;
            ResetDisplay();
            GameManager.sharedInstance.PlayAudioWin(1);
            clock.AddTime(8);
            clock.Stop();
            if (rounds.Raise())  GameManager.sharedInstance.LoadRandomGame();
            if (rounds.current >= 2)
            {
                for(int i = 0; i < Random.Range(1,3);i++) AddRandomItem();
            }
            Reset();
            StartCoroutine(Play(4));
            return false;
        }

        return true;
    }


    void SetEnableButtons(bool enable = true)
    {
        SimonButton[] buttons = FindObjectsOfType<SimonButton>();
        foreach (SimonButton button in buttons)
        {
            button.GetComponentInChildren<Button>().interactable = enable;
        }
    }

    IEnumerator Play(float wait = 0)
    {
        if (lost) yield break;
        isPlaying = true;
        clock.Stop();
        SetEnableButtons(false);
        yield return new WaitForSeconds(wait);
        
        string[] patternEach = pattern.Split('/');

        if (patternEach.Length - 1 == items.max)
        {
            if (!pattern.Contains(toForce) && force)
            {
                AddKey(toForce, ref pattern);
                patternEach = pattern.Split('/');
            }
            force = false;
        }

        int i = 0;
        foreach(string itemName in patternEach)
        {
           
            if (itemName == "") continue;
            
            SimonItem item = GetItemByName(itemName);
            if (item == null)
            {
                item = Variables.simonItems.FirstOrDefault(i => i.name == itemName);
                AddItem(item);
            }
            DisplayItem(item);
            i++;

            if(i < patternEach.Length - 1) yield return new WaitForSeconds(speed);
;       }
        isPlaying = false;
        SetEnableButtons(true);
        clock.Resume();
    }

    IEnumerator Lost(float waitTime = 2)
    {
        isPlaying = true;
        ResetDisplay();
        lost = true;
        SetEnableButtons(false);
        TVtext.text = "Perdiste.";
        GameManager.sharedInstance.LowerVolume();
        GameManager.sharedInstance.PlayAudioLose();
        yield return new WaitForSeconds(waitTime);
        GameManager.sharedInstance.GameOver();
    }

    private void Reset()
    {
        ResetPattern();
        copy = "";
    }

    void ResetPattern()
    {
        pattern = "";
        items.Reset();
        AddRandomKeyPattern();
    }

    public void DisplayItem(SimonItem item, bool playAudio = true)
    {
        ResetDisplay();
        TVDisplay.color = item.color;
        if (item.symbol != null) TVtext.text = item.symbol;
        else if (item.icon)
        {
            TVImage.enabled = true;
            TVImage.sprite = item.icon;
        }
        else TVtext.text = item.name;
        if (item.clip && playAudio) GameManager.sharedInstance.PlayEffect(item.clip);
        else GameManager.sharedInstance.PlayAudioHit();
    }

    public void ResetDisplay()
    {
        TVtext.text = "";
        TVImage.enabled = false;
        TVDisplay.color = Color.white;
    }

    void AddButton(SimonItem item)
    {
        GameObject newButton = Instantiate(buttonPrefab, buttonsPanel);
        SimonButton simonButton = newButton.GetComponent<SimonButton>();
        simonButton.item = item;
    }

    SimonItem GetItemByName(string name) => currentItems.FirstOrDefault(i => i.name == name);


    void AddRandomItem()
    {
        List<SimonItem> possible = Variables.simonItems.Where(i => !Methods.isAny(i.name, currentNames.ToArray())).ToList();
        if (possible.Count <= 0) return;
        SimonItem randomItem = Methods.GetRandomElement(possible.ToArray());
        currentNames.Add(randomItem.name);
        force = true;
        toForce = randomItem.name;
    }

    void AddItem(SimonItem item)
    {
        currentItems.Add(item);
        AddButton(item);
    }
    void AddRandomKeyPattern() => AddRandomKey(ref pattern);
    void AddKeyCopy(string key) => AddKey(key, ref copy);
    void AddKey(string key, ref string to) => to += key + "/";
    void AddRandomKey(ref string to) => AddKey(GetRandomKey(), ref to);
    string GetRandomKey() => Methods.GetRandomElement(currentNames.ToArray());
}
