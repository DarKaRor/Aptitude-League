using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using System;
using System.Linq;
using UnityEngine.UI;

public enum Sound
{
    Win,
    Lose,
    Hit,
    Win2,
    Score
}

public class GameManager : MonoBehaviour
{
    [SerializeField] GameMessage gameMessage;
    [SerializeField] GameObject cursor;
    [SerializeField] GameObject canvas;
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

    public int score = 0;
    public bool isGameOver = false;

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
        sounds.Add(Sound.Score, Resources.Load<AudioClip>("Sound/point"));
        GameDataLog.CreateGameDatas();

        Cursor.visible = false;

        Camera.main.aspect = 16f / 9f;
    }

    private void Update() {
        // Cursor should follow the mouse
        if(cursor!=null) cursor.transform.position = Input.mousePosition;
    }

    public void ResizeCamera()
    {
        // Check the current resolution
        float currentAspectRatio = (float)Screen.width / (float)Screen.height;

        Debug.Log("Current aspect ratio: " + currentAspectRatio);
        float targetAspectRatio = 16f / 9f;
        Debug.Log("Target aspect ratio: " + targetAspectRatio);

        // If the aspect ratio is approximately correct, the ortographic size is 5. Else, resize the ortographic size accordingly
        if (Mathf.Abs(currentAspectRatio - targetAspectRatio) < 0.01f) Camera.main.orthographicSize = 5f;
        else
        {
            float differenceInSize = targetAspectRatio / currentAspectRatio;
            Camera.main.orthographicSize = Camera.main.orthographicSize * differenceInSize;
        }
    }

    public void GameOver()
    {
        inGame = false;
        isGameOver = true;
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
        if(isGameOver) RestoreScore();
        if (isFreePlay) LoadGame(currentGame);
        else{
            if(score % 5 == 0 && score!=0) SceneManager.LoadScene("Vivi");
            else LoadRandomGame();
        }
    }

    public bool CheckChances(Counter chances)
    {
        bool lost = chances.Raise();
        if (lost) GameOver();
        return lost;
    }

    public bool MathGameWin(ref Counter maxPoints, ref Counter difficulty, Action SetDifficulty)
    {
        if(GameWin(ref maxPoints)) return true;
        if (maxPoints.current % 5 == 0)
        {
            difficulty.Raise();
            SetDifficulty();
        }
        return false;
    }

    public bool GameWin(ref Counter maxPoints)
    {
        if(CheckMaxPoints(maxPoints)) return true;
        PlayAudioWin();
        return false;
    }

    IEnumerator WinCoroutine(float waitTime = 2){
        PlayAudioWin(1);
        score++;
        Debug.Log("Score: " + score);
        yield return new WaitForSeconds(waitTime);
        LoadCurrentOrRandom();
    }

    public void Win(float waitTime = 2){
        LowerVolume();
        StartCoroutine(WinCoroutine(waitTime));
    }

    public bool CheckMaxPoints(Counter maxPoints) {
        if (maxPoints.Raise()) Win();
        return maxPoints.reached;
    }


    public IEnumerator FadeTextAfterSeconds(int seconds, TextMeshProUGUI text)
    {
        yield return new WaitForSeconds(seconds);
        text.DOFade(0, 1);
    }

    public void RestoreScore(){
        SaveScore();
        score = 0;
        isGameOver = false;
    }

    public void SaveScore(){
        if(isFreePlay) return;
        if(PlayerPrefs.HasKey("Score")){
            if(score > PlayerPrefs.GetInt("Score")){
                PlayerPrefs.SetInt("Score", score);
            }
        } 
        else PlayerPrefs.SetInt("Score", score);
    }

    public void ToggleGameObject(GameObject gameObject) => gameObject.SetActive(!gameObject.activeSelf);

    public void LoadRandomGame()
    {
        GameData randomGame = GetRandomGame();
        LoadGameData(randomGame);
    }

    public GameData GetRandomGame() => Methods.GetRandomElement(gameDatas.Where(i => i.Id != currentGame).ToArray());

    public void PlayEffect(AudioClip audio) => effects.PlayOneShot(audio);

    public void SetCursor(bool active){
        cursor.SetActive(active);
        Cursor.visible = !active;
    }

    public void BackToMenu()
    {
        inGame = false;
        SetCursor(true);
        RestoreScore();
        StopAllCoroutines();
        if(gameMessage!=null) gameMessage.ResetMessage();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void FreePlay() => SceneManager.LoadScene("FreeplayMenu", LoadSceneMode.Single);

    public void LoadCredits() => SceneManager.LoadScene("Credits", LoadSceneMode.Single);

    public void LoadGame(int id)
    {
        List<GameData> gameData = gameDatas.Where(i => i.Id == id).ToList();
        if (gameData.Count < 0) return;
        LoadGameData(gameData[0]);
    }  

    public void LoadGameData(GameData scene)
    {
        if(scene == null) return;
        inGame = true;
        if (scene.message != null && gameMessage != null) gameMessage.PlayAnimation(scene.message);
        if (scene.OSTName != null) PlayOST(Methods.LoadOST(scene.OSTName));
        else LowerVolume();

        SetCursor(scene.cursor);

        // If scene is the same scene, reload it
        if (SceneManager.GetActiveScene().name == scene.sceneName)
        {
            SceneManager.LoadScene(scene.sceneName, LoadSceneMode.Single);
            return;
        }
        SceneManager.LoadScene(scene.sceneName, LoadSceneMode.Single);
    }


    public void PlayOST(AudioClip audio)
    {
        if (inTransition)
        {
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

    public void Restart(){
        RestoreScore();
        StopAllCoroutines();
        music.Stop();
        effects.Stop();
        LoadCurrentOrRandom();
    }
}
