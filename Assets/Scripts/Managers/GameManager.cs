using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using System;
using System.Linq;

public enum Sound
{
    Win,
    Lose,
    Hit,
    Win2
}

public class GameManager : MonoBehaviour
{
    [SerializeField] GameMessage gameMessage;
    public static GameManager sharedInstance;
    public Dictionary<Sound, AudioClip> sounds = new Dictionary<Sound, AudioClip>();
    public AudioSource effects;
    public AudioSource music;
    public int currentGame = -1;
    public int currentScore;

    public bool hasPlayed = false; // Borrar
    public bool inGame = false;

    public Sprite[] viviSprites;

    public bool inTransition = false;
    public float maxVolume = 0.8f;
    public bool isFreePlay = false;

    public List<GameData> gameDatas = new List<GameData>();
    private void Awake()
    {
        if (sharedInstance != null && sharedInstance != this) Destroy(gameObject);
        else
        {
            sharedInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        effects = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        music = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        music.volume = maxVolume;
        music.loop = true;
        sounds.Add(Sound.Win, Resources.Load<AudioClip>("Sound/win"));
        sounds.Add(Sound.Lose, Resources.Load<AudioClip>("Sound/lose"));
        sounds.Add(Sound.Hit, Resources.Load<AudioClip>("Sound/hit"));
        sounds.Add(Sound.Win2, Resources.Load<AudioClip>("Sound/win2"));
        GameDataLog.CreateGameDatas();
    }

    public void GameOver()
    {
        inGame = false;
        SceneManager.LoadScene("GameOver");
    }

    public void PlayAudioWin(int ver = 0) => effects.PlayOneShot(sounds[ver == 0 ? Sound.Win : Sound.Win2]);
    public void PlayAudioLose() => effects.PlayOneShot(sounds[Sound.Lose]);

    public void PlayAudioHit() => effects.PlayOneShot(sounds[Sound.Hit]);

    public void MathGameFail(TextMeshProUGUI answer, Counter chances, string correctAnswer)
    {
        PlayAudioLose();
        if (CheckChances(chances)) return;
        FadeAnswer(answer, correctAnswer);
    }

    public void FadeAnswer(TextMeshProUGUI answer, string correct)
    {
        answer.DOKill();
        answer.DOFade(1, 0);
        answer.text = $"La respuesta correcta era: {correct}";
        StartCoroutine(FadeTextAfterSeconds(2, answer));
    }

    public void LoadCurrentOrRandom()
    {
        if (isFreePlay) LoadGame(currentGame);
        else LoadRandomGame();
    }

    public bool CheckChances(Counter chances)
    {
        bool lost = chances.Raise();
        if (lost) GameOver();
        return lost;
    }

    public void MathGameWin(ref Counter maxPoints, ref Counter difficulty, Action SetDifficulty)
    {
        GameWin(ref maxPoints);
        if (maxPoints.current % 5 == 0)
        {
            difficulty.Raise();
            SetDifficulty();
        }
    }

    public void GameWin(ref Counter maxPoints)
    {
        PlayAudioWin();
        CheckMaxPoints(maxPoints);
    }

    public bool CheckMaxPoints(Counter maxPoints) {
        if (maxPoints.Raise())
        {
            LoadRandomGame();
        }
        return maxPoints.reached;
    }


    public IEnumerator FadeTextAfterSeconds(int seconds, TextMeshProUGUI text)
    {
        yield return new WaitForSeconds(seconds);
        text.DOFade(0, 1);
    }

    public void ToggleGameObject(GameObject gameObject) => gameObject.SetActive(!gameObject.activeSelf);

    public void LoadRandomGame()
    {
        GameData randomGame = Methods.GetRandomElement(gameDatas.Where(i => i.Id != currentGame).ToArray());
        LoadGameData(randomGame);
    }

    public void PlayEffect(AudioClip audio) => effects.PlayOneShot(audio);

    public void BackToMenu()
    {
        inGame = false;
        gameMessage.ResetMessage();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void FreePlay() => SceneManager.LoadScene("FreeplayMenu", LoadSceneMode.Single);

    public void LoadGame(int id)
    {
        List<GameData> gameData = gameDatas.Where(i => i.Id == id).ToList();
        if (gameData.Count < 0) return;
        LoadGameData(gameData[0]);
    }  

    public void LoadGameData(GameData scene)
    {
        inGame = true;
        if (scene.message != null) gameMessage.PlayAnimation(scene.message);
        if (scene.OSTName != null) PlayOST(Methods.LoadOST(scene.OSTName));
        else LowerVolume();
        SceneManager.LoadScene(scene.sceneName, LoadSceneMode.Single);
    }


    public void PlayOST(AudioClip audio)
    {
        if (inTransition)
        {
            Debug.Log("In transition");
            inTransition = false;
            ResetOST();
            music.DOKill();
            ForcePlayOST(audio);
        }
        if (music.isPlaying && music.clip == audio) return;
        else if (music.clip != audio)
        {
            Transition(audio);
            return;
        }
        ForcePlayOST(audio);
    }

    void ForcePlayOST(AudioClip audio)
    {
        music.clip = audio;
        music.Play();
    }

    public void LowerVolume(float time = .6f, Action onComplete = null)
    {
        music.DOFade(0, time).OnComplete(() =>
        {
            if (onComplete != null) onComplete();
            else ResetOST();
        });
    }

    public void ResetOST()
    {
        music.Stop();
        music.volume = maxVolume;
    }

    public void RaiseVolume(float time = .6f)
    {
        music.DOFade(maxVolume, time);
    }

    public void Transition(AudioClip audio)
    {
        inTransition = true;
        LowerVolume(.6f,() => {
            ForcePlayOST(audio);
            RaiseVolume();
            inTransition = false;
        });
    }
}
