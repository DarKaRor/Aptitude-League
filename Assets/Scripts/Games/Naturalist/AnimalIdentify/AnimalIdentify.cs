using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;



public class AnimalIdentify : MonoBehaviour
{
    int gameId;
    [SerializeField] Clock clock;
    [SerializeField] Typewritter typewritter;
    [SerializeField] TextMeshProUGUI answer;
    [SerializeField] TextMeshProUGUI question;

    Counter chances = new Counter(3);
    Counter rounds = new Counter(6);
    Identify current;

    void Start()
    {
        GameManager.sharedInstance.currentGame = gameId;
        clock.Start();
        typewritter.Start();
        typewritter.writtable.AddRange(Variables.letters);

        GetRandomAnimal();
    }


    void Update()
    {
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
    }

    void CheckValues()
    {
        if (Methods.isAny(answer.text.ToLower(), current.names))
        {
            if (rounds.Raise())
            {
                GameManager.sharedInstance.PlayAudioWin(1);
                Debug.Log("Win");
                return;
            }

            GameManager.sharedInstance.PlayAudioWin();
            Restart();
            return;
        }

        GameManager.sharedInstance.PlayAudioLose();
        if (chances.Raise())
        {
            Debug.Log("Lost");
        }

        Restart();
    }

    void Restart()
    {
        answer.text = "?";
        GetRandomAnimal();
    }
}

