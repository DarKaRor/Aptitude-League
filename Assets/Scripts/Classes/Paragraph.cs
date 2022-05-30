
using UnityEngine;

[System.Serializable]
public class Paragraph
{
    [SerializeField] public string message;
    [SerializeField] public Sprite sprite;

    public Paragraph() { }
    public Paragraph(string message, Sprite sprite)
    {
        this.message = message;
        this.sprite = sprite;
    }
}
