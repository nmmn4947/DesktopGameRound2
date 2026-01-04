using System;
using UnityEngine;
using System.Collections;

public class Fade3DObject : MonoBehaviour
{
    private float fadeDuration = 1f;
    private Material mat;

    void Awake()
    {
        mat = GetComponent<Renderer>().material; 
    }

    private void Start()
    {
        mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0.25f);
        UIManager.instance.tabOn += FadeIn;
        UIManager.instance.tabOff += FadeOut;
    }

    public void FadeOut(float fadeTime)
    {
        mat.SetFloat("_Mode", 2); // Fade
        mat.SetInt("_ZWrite", 0);
        mat.renderQueue = 3000;
        StartCoroutine(Fade(1f, 0f));
        fadeDuration = fadeTime;
    }

    public void FadeIn(float fadeTime)
    {
        mat.SetFloat("_Mode", 0); // Opaque
        mat.SetInt("_ZWrite", 1);
        mat.renderQueue = -1;
        StartCoroutine(Fade(0f, 1f));
        fadeDuration = fadeTime;
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float t = 0f;
        Color c = mat.color;

        while (t < fadeDuration)
        {
            float a = Mathf.Lerp(startAlpha, endAlpha, t / fadeDuration);
            mat.color = new Color(c.r, c.g, c.b, a);
            t += Time.deltaTime;
            yield return null;
        }

        mat.color = new Color(c.r, c.g, c.b, endAlpha);
    }
}
