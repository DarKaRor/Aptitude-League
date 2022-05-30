
using UnityEngine;

public class Range 
{
    public float min = 0;
    public float max = 0;

    public Range(float max, float min = 0)
    {
        this.min = min;
        this.max = max;
    }

    public float GetPercentage(float percent) => (percent  * (max - min) / 100) + min;

    public float GetRandomNumber() => Random.Range(min, max);
}
