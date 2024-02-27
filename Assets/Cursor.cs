using TMPro;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    Slider slider;
    Area area;
    SpriteRenderer areaSpriteRenderer;

    public int Score { get; private set; } = 0;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    public Bounds Bounds { get; private set; }

    private float speed = 4f;
    private Vector3 direction = Vector3.left;

    private float completeTimerValue = 0f;
    private float resetTimerValue = 0;

    [SerializeField]
    private float timeToComplete;

    [SerializeField]
    private float timeToReset;


    void Start()
    {
        slider = FindFirstObjectByType<Slider>();
        area = FindFirstObjectByType<Area>();
        areaSpriteRenderer = area.GetComponent<SpriteRenderer>();
        Bounds = BoundsCalculator.GetBounds(gameObject.transform, this);
        //Debug.Log($"{GetType().Name} bounds on Start: left: {CurrentBounds.Min}; right: {CurrentBounds.Max}");
    }

    void Update()
    {
        MoveCursor();
        UpdateBounds();

        if (isInArea()) onAreaEnter();

        if (!isInArea()) onAreaExit();

        // ��������� ������� ������ ������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PushCursorRight();
        }
    }

    public float GetCompletenessTimerValue()
    {
        return completeTimerValue;
    }
    void UpdateBounds()
    {
        Bounds = BoundsCalculator.GetBounds(gameObject.transform, this);
    }

    private void onAreaEnter()
    {
        resetTimerValue = 0;
        areaSpriteRenderer.color = Color.green;
        completeTimerValue += Time.deltaTime;
        if (completeTimerValue >= timeToComplete)
        {
            Score++;
            scoreText.text = Score.ToString();
            Debug.Log("Win");
            completeTimerValue = 0f;
        }
    }
    private void onAreaExit()
    {
        areaSpriteRenderer.color = Color.red;
        resetTimerValue += Time.deltaTime;
        if (resetTimerValue > timeToReset)
        {
            Debug.Log("Timer reseted");
            completeTimerValue = 0f;
            resetTimerValue = 0;
        }

    }
    private void MoveCursor()
    {
        // ���������� ������
        transform.Translate(direction * speed * Time.deltaTime);

        // ���������, �� ������� �� ������ �� ������� ��������
        ClampCursorToSliderBounds();
    }

    public void PushCursorRight()
    {
        // ���������� ������ �� 1 ������� ������ �� ������� �������
        Vector3 newPosition = new Vector3(Bounds.Max, 0, 0) + Vector3.right * 1f;
        // ���������, �� ������� �� ����� ������� �� ������� ��������
        if (newPosition.x >= slider.Bounds.Max - Bounds.Center)
        {

            newPosition.x = slider.Bounds.Max - Bounds.Center;
        }
        transform.position = newPosition;

    }


    private Vector3 GetClampedPosition()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, slider.Bounds.Min + Bounds.Center, slider.Bounds.Max - Bounds.Center);
        return newPosition;
    }
    private void ClampCursorToSliderBounds()
    {
        // ���� ������ ������� �� ������� ��������, ������������ ��� �������
        if (Bounds.Min <= slider.Bounds.Min || Bounds.Max >= slider.Bounds.Max)
        {
            transform.position = GetClampedPosition();
        }
    }

    private bool isInArea()
    {
        return transform.position.x >= area.CurrentBounds.Min && transform.position.x <= area.CurrentBounds.Max;
    }
}
