using UnityEngine;

[System.Serializable]
public class Counter
{
    public float max;
    public float current;
    public float min = 0;
    public float changer;
    public bool reached = false;

    public Counter(float max,float change = 1, float min = 0, float current = 0)
    {
        this.current = current == 0 ? min : current;
        this.max = max;
        this.min = min;
        this.changer = change;

    }

    public void Reset()
    {
        current = min;
        reached = false;
    }

    public bool Raise()
    {
        current += changer;
        reached = current >= max;
        if (reached) current = max;
        return reached;
    }


    public float GetReverseValue() => max - current;
    
}
