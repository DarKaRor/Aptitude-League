using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViviListens : MonoBehaviour
{
    [SerializeField] DialogueBubble dialogueBubble;
    [SerializeField] Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        SetEnable(false);

        dialogueBubble.dialogue = new Dialogue(
            new Paragraph[]{
                new Paragraph("Hola veo que has llegado a X ronda.",null),
                new Paragraph("¿Cómo te sientes?",ViviSprites.GetSprite(ViviSprite.Happy)),
            }
        );

        dialogueBubble.standPosition = Vector2.zero;

        dialogueBubble.StartSpeak(() => {
            SetEnable(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetEnable(bool enable){
        foreach(var button in buttons){
            button.gameObject.SetActive(enable);
        }
    }
}
