using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MusicalMemory : MonoBehaviour
{
    public static MusicalMemory instance;

    [SerializeField] Image enemy;
    [SerializeField] Image you;
    [SerializeField] Image background;
    [SerializeField] Sprite[] backgrounds;
    [SerializeField] LivesCounter livesCounter;

    int gameId = 7;
    public Dictionary<string, Note> NotesByCode;
    public Dictionary<KeyCode, Note> NoteByKey = new Dictionary<KeyCode, Note>();
    public string[] codes;
    string pattern = "";
    string copy = "";
    bool isPlaying = false;
    Counter rounds = new Counter(4);
    Counter songs = new Counter(2);
    Counter chances = new Counter(3);

    int lastCount = 0;
    string lastNote = "";

    private void Awake() => instance = instance ? instance : this;
    void Start()
    {
        GameManager.sharedInstance.currentGame = gameId;

        NotesByCode = Methods.NotesByCode();
        NoteByKey.Add(KeyCode.RightArrow, NotesByCode["FAm"]);
        NoteByKey.Add(KeyCode.LeftArrow, NotesByCode["FBm"]);
        NoteByKey.Add(KeyCode.Space, NotesByCode["FDm"]);
        NoteByKey.Add(KeyCode.UpArrow, NotesByCode["FD2m"]);
        NoteByKey.Add(KeyCode.DownArrow, NotesByCode["FFm"]);

        codes = NotesByCode.Select(i => i.Key).ToArray();

        SetRandomBackground();
        GenerateRandomPattern();
        StartCoroutine(Sing(2));
        StartCoroutine(ChangeBackground());
    }

    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (PauseMenu.instance.paused) return;
        if (isPlaying) return;

        foreach (KeyValuePair<KeyCode, Note> pair in NoteByKey)
        {
            if (Input.GetKeyDown(pair.Key))
            {
                you.enabled = true;
                DOTween.Kill(you.transform);
                you.transform.localScale = Vector3.one;
                GameManager.sharedInstance.PlayEffect(pair.Value.sound.normal);
                AddKeyCopy(pair.Value.code);
                Animate(you, pair.Key).OnComplete(() => you.enabled = false);
                CheckValues();
                break;
            }
        }
    }

    void CheckValues()
    {
        string[] patternEach = pattern.Split("/");
        string[] copyEach = copy.Split("/");

        for(int i = 0; i < copyEach.Length - 1; i++)
        {
            if(copyEach[i] != patternEach[i])
            {
                livesCounter.LoseLife();
                GameManager.sharedInstance.PlayAudioLose();
                if (chances.Raise()) GameManager.sharedInstance.GameOver();
                Reset();
                StartCoroutine(Sing(2));
                return;
            }
        }

        if(copy == pattern && !rounds.Raise())
        {
            GameManager.sharedInstance.PlayAudioWin();
            copy = "";
            AddRandomKeyPattern();
            StartCoroutine(Sing(2));
            return;
        }

        if (rounds.reached)
        {
            if (songs.Raise())
            {
                isPlaying = true;
                GameManager.sharedInstance.Win();
                return;
            }
            GameManager.sharedInstance.PlayAudioWin(1);
            Reset();
            StartCoroutine(Sing(2));
        }
    }

    Sprite GetRandomBackground() => Methods.GetRandomElement(backgrounds);
    void SetRandomBackground() => background.sprite = GetRandomBackground();
    

    void GenerateRandomPattern()
    {
        if(pattern.Length <= 0)
        {
            for (int i = 0; i < 3; i++) AddRandomKeyPattern();
            return;
        }
        AddRandomKeyPattern(); 
    }

    IEnumerator Sing(float waitTime = 0)
    {
        isPlaying = true;
        yield return new WaitForSeconds(waitTime);
        enemy.enabled = true;
        string[] patternEach = pattern.Split("/");

        foreach(string current in patternEach)
        {
            if (current == "") continue;
            GameManager.sharedInstance.PlayEffect(NotesByCode[current].sound.normal);
            Animate(enemy, NoteByKey.FirstOrDefault(x => x.Value.code == current).Key);
            yield return new WaitForSeconds(0.5f);
            DOTween.Kill(enemy.transform);
        }
        isPlaying = false;
        enemy.enabled = false;
    }

    IEnumerator ChangeBackground(float time = 15){
        float transitionTime = 1f;
        while(true){
            yield return new WaitForSeconds(time);
            Sprite newBG = GetRandomBackground();
            background.DOFade(0, transitionTime).OnComplete(() => {
                background.sprite = newBG;
                background.DOFade(1, transitionTime);
            });
        }
    }

    Tween Animate(Image image,  KeyCode key)
    {
        image.sprite = Variables.keySprites[key];
        return image.transform.DOScale(0.8f, 0.25f).SetLoops(2, LoopType.Yoyo);
    }

    private void Reset()
    {
        ResetPattern();
        copy = "";
    }

    void ResetPattern()
    {
        pattern = "";
        rounds.Reset();
        GenerateRandomPattern();
    }
    void AddRandomKeyPattern() => AddRandomKey(ref pattern);
    void AddKeyCopy(string key) => AddKey(key, ref copy);
    void AddKey(string key, ref string to) => to += key + "/";
    void AddRandomKey(ref string to)
    {
        // Revisando que la tecla no se haya repetido m�s de 2 veces.
        string newKey = GetRandomKey();
        bool equal = newKey == lastNote;
        if (!equal)
        {
            lastNote = newKey;
            lastCount = 0;
        }
        else lastCount++;
        if (lastCount > 1)
        {
            int index = 0;
            index = codes.ToList().FindIndex(0, i => i == newKey)+1;
            if (index == -1 || index >= codes.Length) index = 0;
            newKey = codes[index];
            lastNote = newKey;
            lastCount = 0;
        }
        AddKey(newKey, ref to);
    }
    string GetRandomKey() => Methods.GetRandomElement(codes);

}
