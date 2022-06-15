using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;

public class DialogueBubble : MonoBehaviour
{
    bool isSpelling = false;
    float transitionTime = 1.5f;
    float speechSpeed = .07f;
    [SerializeField] GameObject container;
    [SerializeField] GameObject bubble;
    [SerializeField] TextMeshProUGUI bubbleText;
    [SerializeField] AudioClip voice;
    [SerializeField] TextMeshProUGUI anyKey;
    [SerializeField] public Dialogue dialogue;
    [SerializeField] GameObject viviUI;
    [HideInInspector] public RectTransform viviTransform;
    Image viviImage;
    public CanvasGroup canvasGroup;
    RectTransform rectTransform;

    Vector2 bubbleStartPos;
    Vector2 viviStartPos;
    bool skipped = false;
    bool isSpeaking = false;
    
    char[] waitChars = new char[] { '.', ',', ';', ':' };
    char[] muteChars = new char[] { ' ', '!', '?', '�', '(', ')', '=', '�' };

    AudioSource audioSource;
    public Vector2 standPosition;

    private void Start()
    {

        canvasGroup = bubble.GetComponent<CanvasGroup>();
        rectTransform = container.GetComponent<RectTransform>();
        viviTransform = viviUI.GetComponent<RectTransform>();
        audioSource = GameManager.sharedInstance.effects;
        viviImage = viviUI.GetComponent<Image>();

        bubbleStartPos = rectTransform.anchoredPosition;
        viviStartPos = viviTransform.anchoredPosition;

        standPosition = new Vector2(viviTransform.anchoredPosition.x, -397);
    }



    public void SpawnVivi(Action onEnd)
    {
        canvasGroup.DOFade(0, 0);
        canvasGroup.DOFade(1, transitionTime);
        var sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOAnchorPosY(0, transitionTime));
        sequence.Append(viviTransform.DOAnchorPosY(-397, transitionTime));
        sequence.OnComplete(() => StartCoroutine(Speak(dialogue, onEnd)));
    }

    void ResetBubble()
    {
        bubbleText.text = string.Empty;
        rectTransform.anchoredPosition = bubbleStartPos;
        viviTransform.anchoredPosition = viviStartPos;
    }

    public void Update()
    {
        if(isSpeaking && Input.anyKeyDown)
        {
            skipped = true;
        }

    }


    IEnumerator SpellMessage(string message)
    {
        string current = "";
        isSpeaking = true;
        while (current != message) // While the message isn't completed
        {
            if (skipped)
            {
                bubbleText.text = message;
                break;
            }
            char currentChar = message[current.Length];
            current += currentChar;
            bubbleText.text = current;

            if (!Methods.isAny(currentChar, muteChars))
            {
                audioSource.pitch = UnityEngine.Random.Range(.9f, 1.1f);
                audioSource.PlayOneShot(voice);
            }
            yield return new WaitForSeconds(Methods.isAny(currentChar, waitChars) ? .5f : speechSpeed);
        }
        audioSource.pitch = 1;
        anyKey.DOFade(1, 2).SetLoops(-1, LoopType.Yoyo);
        skipped = false;
        isSpeaking = false;
        yield return new WaitUntil(() => Input.anyKeyDown);
        anyKey.DOKill();
        anyKey.DOFade(0, 0);
        isSpelling = false;
    }

    public IEnumerator Speak(Dialogue dialogue, Action onEnd)
    {

        foreach (Paragraph line in dialogue.paragraphs)
        {
            StartCoroutine(SpellMessage(line.message));
            if (line.sprite)
            {
                viviTransform.DOKill();
                viviTransform.anchoredPosition = standPosition;
                viviImage.sprite = line.sprite;
                viviTransform.DOAnchorPosY(viviTransform.anchoredPosition.y + 30, .25f).SetLoops(2, LoopType.Yoyo); // Bounce effect when changing sprite
            }
            isSpelling = true;
            yield return new WaitUntil(() => !isSpelling); // Wait until spell coroutine finished
        }

        yield return new WaitUntil(() => Input.anyKey); // Wait until user presses a key
        onEnd();
        ResetBubble();
    }


    public void StartSpeak(Action onEnd = null){
        StartCoroutine(Speak(dialogue, onEnd));
    }

}
