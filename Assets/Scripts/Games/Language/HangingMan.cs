using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class HangingMan : MonoBehaviour
{

    [SerializeField] Typewritter typewritter;
    [SerializeField] TextMeshProUGUI output;
    [SerializeField] Image manImage;
    [SerializeField] Sprite[] phases = new Sprite[6];
    [SerializeField] GameObject letterPrefab;
    [SerializeField] Transform lettersParent;
    [SerializeField] TextMeshProUGUI topic;

    Counter chances = new Counter(3);
    Counter maxPoints = new Counter(6);
    Counter phase = new Counter(6);


    int gameId = 3;
    string[] characters;
    List<string> usedCharacters = new();
    Phrase phraseObj;
    string phrase = "";
    string cleanedPhrase = "";
    string separated = "";
    string lower = "";
    bool isFilling = false;
    void Start()
    {
        GameManager.sharedInstance.currentGame = gameId;
        typewritter.Start();
        typewritter.writtable.AddRange(Variables.letters);
        typewritter.writtable.AddRange(Variables.numbers);
        GetRandomPhrase();

    }

    void Update() => GetInput();
    

    void GetInput()
    {
        if (isFilling) return;
        switch (typewritter.Update())
        {
            case TypeWritterAction.Return:
                break;
            case TypeWritterAction.Sent:
                CheckValues();
                break;
        }
    }

    string SeparateString(string str) => string.Join(' ', str.ToCharArray());

    string[] GetCharacters(string str) => DeleteWhiteSpace(str).Distinct().Select(i => i.ToString()).ToArray();

    string DeleteWhiteSpace(string str) => str.Replace(" ", string.Empty);

    string GetValidString(string str) => Methods.SinTildes(str.Trim().ToLower());

    string GetHiddenString(string str, char hider = '_')
    {
        string result = "";
        foreach (char c in str) result += c == ' ' ? ' ' : hider;
        return SeparateString(result);
    }

    void GetCurrentPhase()
    {
        manImage.sprite = phases[(int)phase.current];
    }
    void RestartPhase()
    {
        phase.Reset();
        manImage.sprite = phases[0];
    }

    IEnumerator ActionAfterTime(float time, System.Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }

    void CheckValues()
    {
        if(Methods.isAny(typewritter.last2String(), usedCharacters.ToArray())){
            GameManager.sharedInstance.PlayAudioHit();
            return;
        }
        if (Methods.isAny(typewritter.last2String(), characters))
        {
            char c = typewritter.lastChar;
            AddInput(c);
            if (output.text != separated) return;
            GameManager.sharedInstance.PlayAudioWin();
            if(GameManager.sharedInstance.CheckMaxPoints(maxPoints)){
                isFilling = true;
                return;
            }
            isFilling = true;
           
            StartCoroutine(ActionAfterTime(2, () => {
                isFilling = false;
                Restart();
            }));

            return;
        }

        typewritter.PlayHit();
        string str = typewritter.last2String();
        if (!Methods.isAny(str, usedCharacters.ToArray()))
        {
            usedCharacters.Add(str);
            GameObject letter = Instantiate(letterPrefab, lettersParent);
            letter.GetComponentInChildren<TextMeshProUGUI>().text = str;
        }

        if (phase.Raise())
        {
            GameManager.sharedInstance.PlayAudioLose();
            StartCoroutine(FillWord());
        }
        GetCurrentPhase();
    }

    IEnumerator FillWord(float waitTime = 2)
    {
        isFilling = true;
        yield return new WaitForSeconds(waitTime);
        char[] allChar = cleanedPhrase.Where(i=> !output.text.Contains(i)).Distinct().ToArray();
        foreach(char letter in allChar)
        {
            AddInput(letter);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(1f);
        isFilling = false;

        if(GameManager.sharedInstance.CheckChances(chances)) yield break;
        Restart();
    }

    void AddInput(char c)
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < lower.Length; i++) if (lower[i] == c) indexes.Add(i);
        StringBuilder builder = new StringBuilder(output.text);
        foreach (int i in indexes) builder[i] = separated[i];
        output.text = builder.ToString();
        typewritter.PlayType();
    }

    void Restart()
    {
        foreach (Transform child in lettersParent) Destroy(child.gameObject);
        GetRandomPhrase();
        RestartPhase();
    }

    void GetRandomPhrase()
    {
        phraseObj = Methods.GetRandomElement(Variables.phrases.Where(i=> i!=phraseObj ).ToArray());
        usedCharacters.Clear();
        topic.text = phraseObj.GetTopic();
        phrase = phraseObj.phrase;
        output.text = GetHiddenString(phrase);
        cleanedPhrase = GetValidString(phrase);
        separated = SeparateString(phrase);
        lower = SeparateString(cleanedPhrase);
        characters = GetCharacters(cleanedPhrase);
    }
}
