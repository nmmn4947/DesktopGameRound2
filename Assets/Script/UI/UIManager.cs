using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject toolsUI;
    [SerializeField] private float fadeTime;
    [SerializeField] private List<BoxCollider> AllUIButtons = new List<BoxCollider>();

    private float fadeTimeTrack = 0.0f;
    private CanvasGroup canvasGroup;
    private bool changeFadeStyle = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Transparent3D.instance.isTabOff)
        {
            UIFadeIn(false);
        }
        else
        {
            UIFadeIn(true);
        }
    }

    void HandleEnablingUIButtons(bool enableUI)
    {
        for (int i = 0; i < AllUIButtons.Count; i++)
        {
            AllUIButtons[i].enabled = enableUI;
        }
    }
    
    void UIFadeIn(bool isFadeIn)
    {
        fadeTimeTrack += Time.deltaTime;

        if (changeFadeStyle != isFadeIn)
        {
            fadeTimeTrack = 0f;
            changeFadeStyle = isFadeIn;
            HandleEnablingUIButtons(isFadeIn);
        }

        if (fadeTimeTrack > fadeTime)
        {
            changeFadeStyle = isFadeIn;
            return;
        }
        
        if (isFadeIn)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1, fadeTimeTrack / fadeTime);
        }
        else
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 0, fadeTimeTrack / fadeTime);
        }
    }
    
    public void ToggleTools(Animator animator)
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
