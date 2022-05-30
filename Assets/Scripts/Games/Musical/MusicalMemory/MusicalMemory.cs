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

        GenerateRandomPattern();
        StartCoroutine(Sing(2));
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
            GameManager.sharedInstance.PlayAudioWin(1);
            if (songs.Raise())
            {
                GameManager.sharedInstance.LoadRandomGame();
                return;
            }
            Reset();
            StartCoroutine(Sing(2));
        }
    }

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
    void AddRandomKey(ref string to) => AddKey(GetRandomKey(), ref to);
    string GetRandomKey() => Methods.GetRandomElement(codes);

}
