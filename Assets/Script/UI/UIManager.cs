using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject toolsUI;
    [SerializeField] private GameObject settingsButtons;
    [SerializeField] private GameObject fullScreenBlocker;
    [SerializeField] private float fadeTimeTabOff;
    //[SerializeField] private float fadeTimeToolSelect;
    //[SerializeField] private CursorTool cursorTool;

    private bool isPrevTabOff;
    //private bool isToolSelect;
    
    public event Action<float> tabOn;
    public event Action<float> tabOff;
    public event Action<float> SelectedTools;
    public event Action<float> UnselectedTools;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPrevTabOff = Transparent3D.instance.isTabOff;
        //isToolSelect = cursorTool.GetIfToolIsSelected();
    }

    // Update is called once per frame
    void Update()
    {
        if (Transparent3D.instance.isTabOff)
        {
            if (isPrevTabOff != Transparent3D.instance.isTabOff)
            {
                isPrevTabOff = Transparent3D.instance.isTabOff;
                tabOff?.Invoke(fadeTimeTabOff);
            }
        }
        else
        {
            if (isPrevTabOff != Transparent3D.instance.isTabOff)
            {
                isPrevTabOff = Transparent3D.instance.isTabOff;
                tabOn?.Invoke(fadeTimeTabOff);
            }
            
            /*if (cursorTool.GetIfToolIsSelected())
            {
                if (isToolSelect != cursorTool.GetIfToolIsSelected())
                {
                    isToolSelect = cursorTool.GetIfToolIsSelected();
                    SelectedTools?.Invoke(fadeTimeToolSelect);
                }
            }
            else
            {
                if (isToolSelect != cursorTool.GetIfToolIsSelected())
                {
                    isToolSelect = cursorTool.GetIfToolIsSelected();
                    UnselectedTools?.Invoke(fadeTimeToolSelect);
                }
            }*/
        }
    }

    
    public void ToggleToolsUI(Animator animator)
    {
        if (animator.GetBool("isOpen"))
        {
            animator.Play("CloseTools");
        }
        else
        {
            animator.Play("OpenTools");
        }
        animator.SetBool("isOpen", !animator.GetBool("isOpen"));
    }

    public void OpenSetting()
    {
        fullScreenBlocker.SetActive(true);
        settingsPanel.SetActive(true);
    }
    
    public void CloseSetting()
    {
        fullScreenBlocker.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
