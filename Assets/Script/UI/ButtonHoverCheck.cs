using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverCheck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool IsHovering { get; private set; }
    
    private RectTransform rectTransform;

    public bool buttonIsDown;
    
    // Should I get CursorManager to check isEquipped?
    
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //ToolButtonVisual.GetInstance().SetCurrentToolButtonPosition(rectTransform);
        IsHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Selected item shouldn't be triggered like this anymore?
        //ToolButtonVisual.GetInstance().SetCurrentToolButtonPosition(null);
        IsHovering = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // get ShopItemBehavior, then find out the type of the button, if it is a hold type use a hold in ToolButtonVisual!
        buttonIsDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonIsDown = false;
    }
}
