using UnityEngine;
public class Identify
{
    public string[] names;
    public string soundStr;
    public AudioClip[] sounds;
    public Sprite image;


    public Identify(string[] names, string path, string soundStr = null)
    {
        this.names = names;
        if(path != null) sounds = Methods.LoadMultipleByName("Identify/", path);
        image = Methods.loadSprite($"Identify/{path}");
        this.soundStr = soundStr != null ? soundStr : "Escucha";

    }
}
