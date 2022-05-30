using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField] public Paragraph[] paragraphs;

    public Dialogue(Paragraph[] paragraphs)
    {
        this.paragraphs = paragraphs;
    }
}
