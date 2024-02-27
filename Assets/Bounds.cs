using System;

[Serializable]
public class Bounds
{
    public float Min { get; private set; }
    public float Max { get; private set; }
    public float Center => (Max - Min) / 2;

    public Bounds(float min, float max)
    {
        Min = min;
        Max = max;
    }
    public Bounds(Bounds bounds)
    {
        Min = bounds.Min;
        Max = bounds.Max;
    }
}

