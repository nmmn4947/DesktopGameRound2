using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveUIGroups : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform uiGroup;
    [SerializeField] private RectTransform uiMouse;
    
    private RectTransform canvasRectTransform;
    private bool isMoving = false;
    
    private void Start()
    {
        canvasRectTransform = canvas.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (isMoving)
        {
            uiGroup.anchoredPosition = uiMouse.anchoredPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Cursor.visible = false;
        isMoving = true;
    }

    
    public void OnPointerUp(PointerEventData eventData)
    {
        Cursor.visible = true;
        isMoving = false;
    }
}
