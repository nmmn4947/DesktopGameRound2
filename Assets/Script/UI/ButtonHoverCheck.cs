using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverCheck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private ShopItem itemData;
    
    public bool IsHovering { get; private set; }
    public bool buttonIsDown { get; private set; }

    private RectTransform rectTransform;
    
    
    // Should I get CursorManager to check isEquipped?
    
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

    public void OnPointerDown(PointerEventData eventData)
    {
        // get ShopItemBehavior, then find out the type of the button, if it is a hold type use a hold in ToolButtonVisual!
        buttonIsDown = true;
        if (!itemData.isUnlockedInShop)
        {
            ToolButtonVisual.GetInstance().SetHoldSelectActive();
            return;
        }

        if (itemData.isTool)
        {
            ToolButtonVisual.GetInstance().SetHoldSelectActive();
            return;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonIsDown = false;
        if (!itemData.isUnlockedInShop)
        {
            ToolButtonVisual.GetInstance().StopHoldSelect();
            return;
        }

        if (itemData.isTool)
        {
            ToolButtonVisual.GetInstance().StopHoldSelect();
            return;
        }
    }
}
