using UnityEngine;

public static class BoundsCalculator
{
    public static Bounds GetBounds(Transform transform, MonoBehaviour callingScript)
    {
        // �������� ������� �������
        UnityEngine.Bounds objectBounds = transform.GetComponent<Renderer>().bounds;

        // ����� ������� ������� � ������� �����������
        float leftBound = objectBounds.min.x;

        // ������ ������� ������� � ������� �����������
        float rightBound = objectBounds.max.x;
        //Debug.Log($"{callingScript.GetType().Name} bounds: left: {leftBound}; right: {rightBound}");

        return new Bounds(leftBound, rightBound);
    }
}
