using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class AnimalIdentify : MonoBehaviour
{
    int gameId = 12;
    [SerializeField] Clock clock;
    [SerializeField] Typewritter typewritter;
    [SerializeField] TextMeshProUGUI answer;
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] Button playButton;
    [SerializeField] GameObject questionGroup;
    [SerializeField] Image image;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] LivesCounter livesCounter;

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

        GetRandomAnimal();

        playButton.onClick.AddListener(PlayCurrentAudio);

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

    void GetRandomAnimal()
    {
      
        current = Methods.GetRandomElement(Variables.animalItems.Where(i => i!=current).ToArray());
        question.text = current.soundStr;
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
        ToggleQuestion();
        yield return new WaitForSeconds(2);
        ToggleQuestion();
        GetRandomAnimal();
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

    void ToggleQuestion()
    {
        if (current.images == null) return;
        image.sprite = Methods.GetRandomElement(current.images);
        questionGroup.SetActive(!questionGroup.activeSelf);
        canvasGroup.DOFade(0, 0);
        image.enabled = !image.enabled;
        if (image.enabled) canvasGroup.DOFade(1, 2);
    }

    void Restart()
    {
        clock.Reset();
        StartCoroutine(WaitUntilLoad());
    }
}

