using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class EmotionIdentify : MonoBehaviour
{
    int gameId = 13;
    [SerializeField] Clock clock;
    [SerializeField] Typewritter typewritter;
    [SerializeField] TextMeshProUGUI answer;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] LivesCounter livesCounter;
    [SerializeField] Image image;

    Counter chances = new Counter(3);
    Counter rounds = new Counter(6);
    Identify current;

    bool isWaiting = false;
    void Start()
    {
        GameManager.sharedInstance.currentGame = gameId;
        clock.Start();
        typewritter.Start();
        typewritter.writtable.AddRange(Variables.letters);

        GetRandomEmotion();
        image.sprite = Methods.GetRandomElement(current.images);
        livesCounter.SetLives((int)chances.max);
    }


    void Update()
    {
        if (isWaiting) return;
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
        switch (typewritter.Update())
        {
            case TypeWritterAction.Sent:
                typewritter.Type();
                break;
            case TypeWritterAction.Return:
                if(answer.text == typewritter.defaultString) return;
                CheckValues();
                break;
        }
    }

    void GetRandomEmotion()
    {

        current = Methods.GetRandomElement(Variables.emotionItems.Where(i => i != current).ToArray());
        PlayCurrentAudio();
    }

    void PlayCurrentAudio()
    {
        GameManager.sharedInstance.effects.Stop();
        if (current.sounds != null) GameManager.sharedInstance.PlayEffect(Methods.GetRandomElement(current.sounds));
    }


    IEnumerator WaitUntilLoad()
    {
        isWaiting = true;
        canvasGroup.DOFade(0, 1).OnComplete(() => {
            GetRandomEmotion();
            image.sprite = Methods.GetRandomElement(current.images);
            canvasGroup.DOFade(1, 1);
        });
        yield return new WaitForSeconds(2);
        answer.text = "?";
        isWaiting = false;
    }

    IEnumerator WaitToAction(Action action)
    {
        isWaiting = true;
        yield return new WaitForSeconds(2);
        action();
    }

    void Lose() => StartCoroutine(WaitToAction(() => GameManager.sharedInstance.GameOver()));

    void CheckValues()
    {   
        isWaiting = true;
        if (Methods.isAny(answer.text.ToLower(), current.names))
        {
            if (rounds.Raise())
            {
                GameManager.sharedInstance.Win();
                return;
            }

            GameManager.sharedInstance.PlayAudioWin();
            Restart();
            return;
        }

        GameManager.sharedInstance.PlayAudioLose();
        livesCounter.LoseLife();
        answer.text = Methods.Capitalize(current.names[0]);
        if (chances.Raise())
        {
            Lose();
            return;
        }
        Restart();
    }

    void Restart()
    {
        clock.Reset();
        StartCoroutine(WaitUntilLoad());
    }
}

