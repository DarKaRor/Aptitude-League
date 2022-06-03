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
    void Win() => StartCoroutine(WaitToAction(() => GameManager.sharedInstance.LoadCurrentOrRandom()));

    void CheckValues()
    {
        if (Methods.isAny(answer.text.ToLower(), current.names))
        {
            if (rounds.Raise())
            {
                GameManager.sharedInstance.PlayAudioWin(1);
                Win();
                return;
            }

            GameManager.sharedInstance.PlayAudioWin();
            Restart();
            return;
        }

        GameManager.sharedInstance.PlayAudioLose();
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
        if (current.image == null) return;
        image.sprite = current.image;
        if (Methods.isAny("gato", current.names) && Methods.Roll(5)) image.sprite = Methods.loadSprite("Identify/cat2");
        questionGroup.SetActive(!questionGroup.activeSelf);
        image.DOFade(0, 0);
        image.enabled = !image.enabled;
        if (image.enabled) image.DOFade(1, 2);
    }

    void Restart()
    {
        clock.Reset();
        StartCoroutine(WaitUntilLoad());
    }
}

