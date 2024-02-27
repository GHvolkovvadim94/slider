using System.Collections;
using UnityEngine;

public class Area : MonoBehaviour
{
    Slider slider;
    public Bounds CurrentBounds { get; private set; }

    private float speed = 2f;
    private Vector3 direction = Vector3.right;
    private bool canChangeDirection = true; // Флаг для разрешения изменения направления

    void Start()
    {
        slider = FindFirstObjectByType<Slider>();
        CurrentBounds = BoundsCalculator.GetBounds(gameObject.transform, this);
        StartCoroutine(RandomDirectionChange());
        //Debug.Log($"{GetType().Name} bounds on Start: left: {CurrentBounds.Min}; right: {CurrentBounds.Max}");
    }

    void Update()
    {
        //Двигаем область
        MoveArea();
        // Обновляем границы при каждом кадре
        UpdateBounds();
    }

    void UpdateBounds()
    {
        CurrentBounds = BoundsCalculator.GetBounds(gameObject.transform, this);
    }

    private void MoveArea()
    {
        gameObject.transform.Translate(direction * speed * Time.deltaTime);

        if (!IsInSliderBound() && canChangeDirection)
        {
            ChangeMoveDirection();
        }
    }

    private bool IsInSliderBound()
    {
        return CurrentBounds.Min >= slider.Bounds.Min && CurrentBounds.Max <= slider.Bounds.Max;
    }

    private void ChangeMoveDirection()
    {
        direction = -direction;
        Debug.Log("Меняю направление");
        StartCoroutine(DisallowDirectionChange());
    }

    private IEnumerator DisallowDirectionChange()
    {
        canChangeDirection = false; // Запрещаем изменение направления
        yield return new WaitForSeconds(1f); // Ждем 1 секунду
        canChangeDirection = true; // Разрешаем изменение направления
    }
    private IEnumerator RandomDirectionChange()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f, 5f)); // Ждем случайное время 
            if (canChangeDirection)
            {
                ChangeMoveDirection();
            }
        }
    }
}
