using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using DG.Tweening;

public enum PoseType
{
    Game,
    Lose,
    Win
}
public enum AnimationType
{
    Shake,
    Bounce,
    Static,
    Crouch,
    Jump
}
[System.Serializable]
public class Pose
{
    public string name;
    public Sprite sprite;
    public AnimationType animation;
    public PoseType type;

    public Pose(string name, Sprite sprite, AnimationType animation, PoseType type)
    {
        this.name = name;
        this.sprite = sprite;
        this.animation = animation;
        this.type = type;
    }
}
public class DoThePose : MonoBehaviour
{
    public static DoThePose instance;

    int gameId = 10;
    [SerializeField] Pose[] poses;
    [SerializeField] PoseAction[] actions;
    [SerializeField] GameObject poseMan;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] AudioClip waitClip;
    [SerializeField] AudioClip doClip;
    float reactionTime = 2;
    public int currentCorrect;
    Pose[] gamePoses;
    Pose[] winPoses;
    Pose[] losePoses;
    RectTransform poseManTransform;
    Image poseManImage;
    Coroutine answered;
    Counter rounds = new Counter(8);
    Counter chances = new Counter(3);
    bool canAnswer = false;
    float waitTime = 2f;
    AudioSource source;

    private void Awake() => instance = instance ? instance : this;
    
    void Start()
    {
        GameManager.sharedInstance.currentGame = gameId;
        source = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        source.volume = GameManager.sharedInstance.effects.volume;
        if (source.volume < 0.2f) source.volume = 0.2f;
        gamePoses = GetPosesByType(PoseType.Game);
        winPoses = GetPosesByType(PoseType.Win);
        losePoses = GetPosesByType(PoseType.Lose);

        poseManTransform = poseMan.GetComponent<RectTransform>();
        poseManImage = poseMan.GetComponent<Image>();
        GetPoses();
        SetAllEnable(false);
        StartCoroutine(PlayWait(waitTime));
    }

    void GetPoses()
    {
        List<int> indexes = Enumerable.Range(0, gamePoses.Length).ToList();
        List<int> gotten = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            int current = Methods.GetRandomElement(indexes.ToArray());
            indexes.Remove(current);
            gotten.Add(current);
            actions[i].image.sprite = gamePoses[current].sprite;
            actions[i].index = current;
            actions[i].SetIndex();
        }

        currentCorrect = Methods.GetRandomElement(gotten.ToArray());
    }

    void SetAllEnable(bool val = true)
    {
        foreach (PoseAction action in actions) action.SetEnable(val);
    }


    void InfiniteBounce(float speed = 1f)
    {
        ResetPose();
        poseManTransform.DOScaleY(1.1f, 0.3f / speed).SetLoops(-1, LoopType.Yoyo);
    }

    public void CheckValues(int index)
    {
        if(answered != null) StopCoroutine(answered);
        if (!canAnswer) return;
        text.text = "";
        canAnswer = false;
        ResetPose();
        if (index != currentCorrect)
        {
            Lose();
            return;
        }

        if (rounds.Raise())
        {

            Win();
            return;
        }

        RaiseDifficulty();
        GameManager.sharedInstance.PlayAudioWin();
        SetImage(Methods.GetRandomElement(winPoses));
        StartCoroutine(PlayWait(waitTime));
    }

    void Win(float waitTime = 2) => GameManager.sharedInstance.Win(waitTime);
    

    IEnumerator Lost(float waitTime = 2)
    {
        yield return new WaitForSeconds(waitTime);
        GameManager.sharedInstance.GameOver();
    }

    IEnumerator PlayWait(float waitTime = 0)
    {
        canAnswer = false;
        text.text = "";
        yield return new WaitForSeconds(waitTime);
        GetPoses();
        SetAllEnable();
        int loops = GetLoops();
        float speed = GetSpeed();
        InfiniteBounce(speed);
        source.pitch = speed;
        for (int i = 0; i < loops; i++)
        {
            source.PlayOneShot(waitClip);
            float time = 0;
            while (time < (waitClip.length + 0.2f) / speed)
            {
                time += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
        GameManager.sharedInstance.PlayEffect(doClip);
        poseManTransform.DOKill();
        SetImageIndex();
        answered = StartCoroutine(CheckAnswered());
        canAnswer = true;
    }

    IEnumerator CheckAnswered()
    {
        yield return new WaitForSeconds(reactionTime);
        Lose();
    }

    void Lose()
    {
        GameManager.sharedInstance.PlayAudioLose();
        SetImage(Methods.GetRandomElement(losePoses));
        answered = null;
        SetAllEnable(false);
        if (chances.Raise())
        {
            StartCoroutine(Lost());
            return;
        }

        StartCoroutine(PlayWait(3));
    }


    private void ResetPose()
    {
        poseManTransform.anchoredPosition = Vector2.zero;
        poseManTransform.DOKill();
    }
    void Shake()
    {
        ResetPose();
        poseManTransform.DOShakeAnchorPos(1f, 20, 0).SetLoops(-1, LoopType.Yoyo);
    }

    void Crouch()
    {
        ResetPose();
        poseManTransform.DOAnchorPosY(poseManTransform.anchoredPosition.y - 1f, 0.5f).SetLoops(2, LoopType.Yoyo);
    }

    void Jump()
    {
        ResetPose();
        poseManTransform.DOAnchorPosY(poseManTransform.anchoredPosition.y + 50f, 0.5f).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo);
    }

    void AnimateByPose(Pose pose)
    {
        switch (pose.animation)
        {
            case AnimationType.Shake:
                Shake();
                break;
            case AnimationType.Crouch:
                Crouch();
                break;
            case AnimationType.Jump:
                Jump();
                break;
        }
    }

    int GetLoops()
    {
        if (rounds.current <= 2) return 3;
        if (rounds.current <= 4) return Random.Range(2,4);
        return Random.Range(0,3);
    }

    float GetSpeed()
    {
        if (rounds.current <= 2) return 1;
        if (rounds.current <= 4) return FlipCoin() ? 1.3f : 1;
        return FlipCoin(2) ? Random.Range(1.3f, 1.8f) : 1;
    }

    bool FlipCoin(int x = 1) => Random.Range(0, x + 1) == 1;
    
    void SetImageIndex() => SetImage(gamePoses[currentCorrect]);

    void SetImage(Pose pose)
    {
        poseManImage.sprite = pose.sprite;
        text.text = pose.name;
        AnimateByPose(pose);
    }

    void RaiseDifficulty()
    {
        if (reactionTime <= .7)
        {
            reactionTime = .7f;
            return;
        }
        reactionTime -= reactionTime * 0.05f;
        waitTime -= waitTime * 0.1f;
    }
    
    

    Pose[] GetPosesByType(PoseType type) => poses.Where(i => i.type == type).ToArray();

    
}
