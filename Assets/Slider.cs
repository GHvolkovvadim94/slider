using UnityEngine;

public class Slider : MonoBehaviour
{
    public Bounds Bounds { get; private set; }

    void Start()
    {
        Bounds = BoundsCalculator.GetBounds(gameObject.transform, this);
    }
}
