using UnityEngine;

[System.Serializable]
public class WalkAnim
{
    public Sprite idle;
    public Sprite[] walk;

    
    public WalkAnim(Sprite idle, Sprite[] walk)
    {
        this.idle = idle;
        this.walk = walk;
    }
}
