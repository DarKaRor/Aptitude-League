using UnityEngine;
public class NoteSound
{
    public AudioClip normal;
    public AudioClip loop;

    public NoteSound(AudioClip normal, AudioClip loop)
    {
        this.normal = normal;
        this.loop = loop;
    }
}