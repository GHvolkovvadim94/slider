using UnityEngine;

public static class BoundsCalculator
{
    public static Bounds GetBounds(Transform transform, MonoBehaviour callingScript)
    {
        // Получаем границы объекта
        UnityEngine.Bounds objectBounds = transform.GetComponent<Renderer>().bounds;

        // Левая граница объекта в мировых координатах
        float leftBound = objectBounds.min.x;

        // Правая граница объекта в мировых координатах
        float rightBound = objectBounds.max.x;
        //Debug.Log($"{callingScript.GetType().Name} bounds: left: {leftBound}; right: {rightBound}");

        return new Bounds(leftBound, rightBound);
    }
}
