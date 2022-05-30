using UnityEngine;


[System.Serializable]
public enum Side
{
    Left,
    Right
}

[System.Serializable]
public class Connection
{
    public float? height = 0;
    public Glass child;
    public bool isBlocked = false;
    public Side side;

    public Connection(float height, Glass child, bool isBlocked, Side side)
    {
        this.height = height;
        this.child = child;
        this.isBlocked = isBlocked;
        this.side = side;
    }
}
