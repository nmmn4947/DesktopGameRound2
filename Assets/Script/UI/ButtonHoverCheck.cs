using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverCheck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool IsHovering { get; private set; }
    
    private RectTransform rectTransform;
    
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolButtonVisual.GetInstance().SetCurrentToolButtonPosition(rectTransform);
        IsHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolButtonVisual.GetInstance().SetCurrentToolButtonPosition(null);
        IsHovering = false;
    }
}
