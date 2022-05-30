using UnityEngine;

[System.Serializable]
public class SimonItem
{
    public string name;
    public string symbol;
    public Sprite icon;
    public Color color;
    public AudioClip clip;
    bool isSymbol;

    public SimonItem(string name, AudioClip clip, Sprite icon, Color? color = null, string symbol = null, bool isSymbol = false)
    {
        this.name = name;
        this.symbol = symbol;
        this.icon = icon;
        this.color = color ?? Color.white;
        this.clip = clip;
        this.isSymbol = isSymbol;
    }
}
