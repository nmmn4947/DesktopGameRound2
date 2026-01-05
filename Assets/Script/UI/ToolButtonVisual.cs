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
    [SerializeField] CursorManager _cursorManager;
    
    private RectTransform thisRectTransform;
    private bool isHovering = false;
    
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
            holdSlider.value = Mathf.Lerp(holdSlider.value, 1.0f, holdSelectKeep / holdSelectTime);
        }
    }

    public void SetCurrentToolButtonPosition(RectTransform rectTransform)
    {
        if (_cursorManager.isEquipped)
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
        
    }

    public void SetHoldSelectActive(float holdDuration)
    {
        holdSelectTime = holdDuration;
        isHolding = true;
    }

    public void StopHoldSelect()
    {
        isHolding = false;
        holdSelectKeep = 0.0f;
        holdSelectTime = 0.0f;
        holdSlider.value = 0.0f;
    }
}
