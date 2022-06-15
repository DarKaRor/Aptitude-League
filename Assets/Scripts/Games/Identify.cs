using UnityEngine;
public class Identify
{
    public string[] names;
    public string soundStr;
    public AudioClip[] sounds;
    public Sprite[] images;


    public Identify(string[] names, string path, string soundStr = null)
    {
        this.names = names;
        if(path != null) sounds = Methods.LoadMultipleByName("Identify/", path);
        images = Methods.LoadIdentifyImages("Identify/", path);
        this.soundStr = soundStr != null ? soundStr : "Escucha";

    }
}
