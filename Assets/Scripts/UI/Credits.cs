using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System.Linq;

public class Credits : MonoBehaviour
{
    [SerializeField] GameObject creditsPanel;
    [SerializeField] AudioClip creditsMusic;
    [SerializeField] Sprite[] poseManSprites;
    [SerializeField] Sprite[] flautistSprites;
    [SerializeField] Sprite[] avatarSprites;
    [SerializeField] Image avatar;
    [SerializeField] Image poseMan;
    [SerializeField] Image flautist;
    [SerializeField] TextMeshProUGUI ahorcadoText;

    float scrollSpeed = 10;
    Range scrollRange = new Range(50, 10);
    bool holdingDown = false;
    bool isChanging = false;
    bool isFilling = false;
    bool isChangingFlautist = false;
    bool isChangingAvatar = false;

    RectTransform creditsPos;
    void Start()
    {
        GameManager.sharedInstance.PlayOST(creditsMusic);
        creditsPos = creditsPanel.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            GameManager.sharedInstance.BackToMenu();
            return;
        }
        else if(Input.anyKeyDown && !holdingDown){
            scrollSpeed = scrollRange.max;
            holdingDown = true;
        }

        if(!Input.anyKey && holdingDown){
            scrollSpeed = scrollRange.min;
            holdingDown = false;
        }

        if(poseMan.transform.position.y >= 0 && !isChanging) StartCoroutine(ChangePoseMan());
        if(ahorcadoText.transform.position.y >= 0 && !isFilling) StartCoroutine(FillWord());
        if(flautist.transform.position.y >= 0 && !isChangingFlautist) StartCoroutine(ChangeFlautist());
        if(avatar.transform.position.y >= 0 && !isChangingAvatar) StartCoroutine(ChangeAvatar());
        

        creditsPanel.transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime * Screen.height / 100); 

        if(creditsPos.anchoredPosition.y >= 16457){
            GameManager.sharedInstance.BackToMenu();
        }
    }

    IEnumerator ChangeAvatar(){
        isChangingAvatar = true;
        while(true){
            yield return new WaitForSeconds(1);
            avatar.sprite = Methods.GetRandomElement(avatarSprites);
        }
    }

    IEnumerator ChangeFlautist(){
        isChangingFlautist = true;
        TweenUtils.InfiniteScale(flautist.GetComponent<RectTransform>());
        while(true){
            yield return new WaitForSeconds(0.5f);
            flautist.sprite = Methods.GetRandomElement(flautistSprites);
        }
    }

    IEnumerator ChangePoseMan()
    {
        isChanging = true;
        TweenUtils.InfiniteBounce(poseMan.gameObject.GetComponentInChildren<RectTransform>(),1.1f, 0.5f / 2);
        while(true){
            yield return new WaitForSeconds(0.5f);
            poseMan.sprite = Methods.GetRandomElement(poseManSprites);
        }
    }

    IEnumerator FillWord(float waitTime = 2)
    {
        isFilling = true;
        yield return new WaitForSeconds(waitTime);
        char[] allChar = "ahorcado".ToCharArray().Where(i=> !ahorcadoText.text.Contains(i)).Distinct().ToArray();
        foreach(char letter in allChar)
        {
            AddInput(letter);
            yield return new WaitForSeconds(0.5f);
        }
    }

    
    void AddInput(char c)
    {
        List<int> indexes = new List<int>();
        string lower = "a h o r c a d o";
        for (int i = 0; i < lower.Length; i++) if (lower[i] == c) indexes.Add(i);
        StringBuilder builder = new StringBuilder(ahorcadoText.text);
        foreach (int i in indexes) builder[i] = "A h o r c a d o"[i];
        ahorcadoText.text = builder.ToString();
    }

}
