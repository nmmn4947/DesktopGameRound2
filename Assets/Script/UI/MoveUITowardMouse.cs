using UnityEngine;

public class MoveUITowardMouse : MonoBehaviour
{
    RectTransform rectTransform;
    Canvas canvas;
    RectTransform canvasRect;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasRect = canvas.transform as RectTransform;
    }

    void Update()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent.GetComponent<RectTransform>(),
            Input.mousePosition,
            canvas.worldCamera,   // ✅ NOT Camera.main
            out Vector2 localPoint
        );

        rectTransform.anchoredPosition = localPoint;
    }
}