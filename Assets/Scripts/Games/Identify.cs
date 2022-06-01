using UnityEngine;
public class Identify
{
    public string[] names;
    public string soundStr;
    public AudioClip sound;
    public Sprite image;


    public Identify(string[] names, AudioClip sound, Sprite image, string soundStr)
    {
        this.names = names;
        this.sound = sound;
        this.image = image;
        this.soundStr = soundStr;
    }
}
