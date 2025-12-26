using System.Collections;
using UnityEngine;

public class UIDisabler : MonoBehaviour
{
    public bool disabledOnToolSelect;
    
    private CanvasGroup canvasGroup;
    private Coroutine currentFade;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        UIManager.instance.tabOn += FadeInUI;
        UIManager.instance.tabOff += FadeOutUI;
        if (disabledOnToolSelect)
        {
            UIManager.instance.UnselectedTools += FadeInUI;
            UIManager.instance.SelectedTools += FadeOutUI;
        }
    }

    void FadeInUI(float duration)
    {
        if (currentFade != null)
        {
            StopCoroutine(currentFade);
            currentFade = null;
        }
        currentFade = StartCoroutine(FadeIn(duration));
    }

    void FadeOutUI(float duration)
    {
        if (currentFade != null)
        {
            StopCoroutine(currentFade);
            currentFade = null;
        }

        currentFade = StartCoroutine(FadeOut(duration));
    }

    
    IEnumerator FadeIn(float duration)
    {
        float startAlpha = canvasGroup.alpha;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 1f, t / duration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
        currentFade = null;
    }

    
    IEnumerator FadeOut(float duration)
    {
        float startAlpha = canvasGroup.alpha;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, t / duration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        currentFade = null;
    }

    
    // Unneccesary?
    /*void OnDestroy()
    {
        if (UIManager.instance == null) return;

        UIManager.instance.tabOn -= FadeInUI;
        UIManager.instance.tabOff -= FadeOutUI;
        UIManager.instance.SelectedTools -= FadeOutUI;
        UIManager.instance.UnselectedTools -= FadeInUI;
    }*/
}
