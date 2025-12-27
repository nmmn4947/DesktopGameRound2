using UnityEngine;

public class MoveUITowardMouse : MonoBehaviour
{
    RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out localPoint);
        rectTransform.anchoredPosition = localPoint;
    }
}
