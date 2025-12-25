using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject toolsUI;
    [SerializeField] private GameObject settingsButtons;
    [SerializeField] private float fadeTimeTabOff;
    [SerializeField] private float fadeTimeToolSelect;
    [SerializeField] private List<BoxCollider> AllUIButtons = new List<BoxCollider>();
    [SerializeField] private CursorTool cursorTool;
    
    private CanvasGroup canvasGroup;
    private float allUIFadeTrack = 0.0f;
    private bool allUIFadeState = false;
    private float someUIFadeTrack = 0.0f;
    private bool someUIFadeState = false;
    List<GameObject> DisabledWhenToolIsSelected = new List<GameObject>();

    public event Action SelectedTools;
    public event Action UnselectedTools;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        
        DisabledWhenToolIsSelected.Add(settingsButtons);
    }

    // Update is called once per frame
    void Update()
    {
        if (Transparent3D.instance.isTabOff)
        {
            AllUIFadeIn(false);
        }
        else
        {
            if (cursorTool.GetIfToolIsSelected())
            {
                SOMEUIFadeIn(false, DisabledWhenToolIsSelected); // IMMA REWRITE THIS OMG IT IS NOT WORKING
            }
            else
            {
                SOMEUIFadeIn(true, DisabledWhenToolIsSelected);
                AllUIFadeIn(true);
            }
        }


    }

    void HandleEnablingAllUIButtons(bool enableUI)
    {
        for (int i = 0; i < AllUIButtons.Count; i++)
        {
            AllUIButtons[i].enabled = enableUI;
        }
    }
    
    void AllUIFadeIn(bool isFadeIn)
    {
        allUIFadeTrack += Time.deltaTime;

        if (allUIFadeState != isFadeIn)
        {
            allUIFadeTrack = 0f;
            allUIFadeState = isFadeIn;
            HandleEnablingAllUIButtons(isFadeIn);
        }

        if (allUIFadeTrack > fadeTimeTabOff)
        {
            allUIFadeState = isFadeIn;
            return;
        }
        
        if (isFadeIn)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1, allUIFadeTrack / fadeTimeTabOff);
        }
        else
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 0, allUIFadeTrack / fadeTimeTabOff);
        }
    }
    
    void HandleEnablingSOMEUIButtons(bool enableUI, List<GameObject> some)
    {
        for (int i = 0; i < some.Count; i++)
        {
            BoxCollider[] colliders = some[i].GetComponentsInChildren<BoxCollider>(true);

            for (int j = 0; j < colliders.Length; j++)
            {
                colliders[j].enabled = enableUI;
            }
        }
    }
    
    void SOMEUIFadeIn(bool isFadeIn, List<GameObject> Some)
    {
        someUIFadeTrack += Time.deltaTime;

        if (someUIFadeState != isFadeIn)
        {
            someUIFadeTrack = 0f;
            someUIFadeState = isFadeIn;
            HandleEnablingSOMEUIButtons(isFadeIn, Some);
        }

        if (someUIFadeTrack > fadeTimeToolSelect)
        {
            someUIFadeState = isFadeIn;
            return;
        }
        
        if (isFadeIn)
        {
            for (int i = 0; i < Some.Count; i++)
            {
                Some[i].GetComponent<CanvasGroup>().alpha = Mathf.Lerp(canvasGroup.alpha, 1, someUIFadeTrack / fadeTimeToolSelect);
            }
        }
        else
        {
            for (int i = 0; i < Some.Count; i++)
            {
                Some[i].GetComponent<CanvasGroup>().alpha = Mathf.Lerp(canvasGroup.alpha, 0, someUIFadeTrack / fadeTimeToolSelect);
            }
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
        settingsPanel.SetActive(true);
    }
    
    public void CloseSetting()
    {
        settingsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
