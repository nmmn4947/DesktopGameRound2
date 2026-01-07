using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolButtonVisual : MonoBehaviour
{
    public static ToolButtonVisual instance;

    public static ToolButtonVisual GetInstance()
    {
        return instance;
    }
    
    [SerializeField] private Image image;
    [SerializeField] private CursorManager _cursorManager;
    [SerializeField] private float fixedHoldDuration;
    
    private RectTransform thisRectTransform;
    private bool isHovering = false;
    private ShopItem currentButtonItem;
    private Slider holdSlider;
    private bool isHolding = false;
    private float holdSelectTime = 0.0f;
    private float holdSelectKeep = 0.0f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    
    void Start()
    {
        thisRectTransform = GetComponent<RectTransform>();
        holdSlider = GetComponent<Slider>();
    }
    
    void Update()
    {
        if (_cursorManager.isEquipped)
        {
            image.color = Color.white;
        }
        else
        {
            if (!isHovering)
            {
                //Don't show the selectFrame
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
            }
            else
            {
                //Show hover select frame
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0.25f);
            }
        }

        if (holdSelectTime != 0.0f)
        {
            holdSelectKeep += Time.deltaTime;
            holdSlider.value = Mathf.Lerp(0.0f, 1.0f, holdSelectKeep / holdSelectTime);
            //Debug.Log(holdSelectKeep / holdSelectTime);
        }
    }

    public void SetCurrentToolButtonPosition(RectTransform rectTransform)
    {
        if (_cursorManager.isEquipped)
        {
            return;
        }

        if (isHolding)
        {
            return;
        }
        
        if (rectTransform == null)
        {
            isHovering = false;
            return;
        }
        isHovering = true;
        thisRectTransform.position = rectTransform.position;
        currentButtonItem = rectTransform.gameObject.GetComponent<ButtonHoverCheck>().GetItemData();
        
    }
    
    public void SetHoldSelectActive()
    {
        holdSelectTime = fixedHoldDuration;
        isHolding = true;
        //Debug.Log("holdSelectTime: " + holdSelectTime);
    }
    
    public void SetHoldSelectActive(float holdDuration)
    {
        holdSelectTime = holdDuration;
        isHolding = true;
    }

    public void StopHoldSelect()
    {
        if (!currentButtonItem.isUnlockedInShop)
        {
            if (holdSlider.value >= 0.999f)
            {
                /*if ()     ////////// COST ENOUGH? IF ENOUGH CAN BUY, IF NOT CAN'T UNLOCKED
                {
                    
                }*/
                currentButtonItem.isUnlockedInShop = true;
                
            }
        }
        else
        {
            if (holdSlider.value >= 0.999f)
            {
                _cursorManager.EquipItem(currentButtonItem);
            }
        }
        isHolding = false;
        holdSelectKeep = 0.0f;
        holdSelectTime = 0.0f;
        holdSlider.value = 0.0f;
    }
}
