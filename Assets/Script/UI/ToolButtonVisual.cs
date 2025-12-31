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
    [SerializeField] CursorTool cursorTool;
    
    private List<ButtonHoverCheck> buttonHoverChecks = new List<ButtonHoverCheck>();
    private RectTransform thisRectTransform;
    private bool isHovering = false;

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
    }
    
    void Update()
    {
        if (cursorTool.GetIfToolIsSelected())
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
    }

    public void SetCurrentToolButtonPosition(RectTransform rectTransform)
    {
        if (cursorTool.GetIfToolIsSelected())
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
}
