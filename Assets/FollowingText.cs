using TMPro;
using UnityEngine;

public class FollowingText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textObject;
    [SerializeField]
    private Transform target;
    [SerializeField]
    float offset;
    private Cursor cursor;
    private void Start()
    {
        cursor = FindFirstObjectByType<Cursor>();
    }


    void Update()
    {
        textObject.text = cursor.GetCompletenessTimerValue().ToString("F1");
        Vector3 worldPosition = target.TransformPoint(Vector3.up * offset);
        textObject.transform.position = Camera.main.WorldToScreenPoint(worldPosition);
    }
}
