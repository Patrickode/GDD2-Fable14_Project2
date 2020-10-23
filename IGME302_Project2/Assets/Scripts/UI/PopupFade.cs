using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PopupFade : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image[] backdrops = null;
    [SerializeField] private TextMeshProUGUI[] textFields = null;

    [Header("Fade Parameters")]
    [SerializeField] private float fadeInTime = 0.5f;
    [SerializeField] private float stayVisibleTime = 5.0f;
    [SerializeField] private float fadeOutTime = 1.0f;

    private List<float> backdropAlphas = new List<float>();
    private List<float> textAlphas = new List<float>();

    private Coroutine fadeCoroutine = null;

    private void Awake()
    {
        //Cache the alphas of all the things that will be fading
        foreach (Image backdrop in backdrops) { backdropAlphas.Add(backdrop.color.a); }
        foreach (TextMeshProUGUI textField in textFields) { textAlphas.Add(textField.color.a); }

        LevelManager.OnLoaded += ResetFade;
    }
    private void OnDestroy()
    {
        LevelManager.OnLoaded -= ResetFade;
    }

    private IEnumerator FadeInOut()
    {
        float progress = 0;
        while (progress < 1)
        {
            progress += Time.deltaTime / fadeInTime;

            //Set backdrop alphas
            for (int i = 0; i < backdrops.Length; i++)
            {
                LerpAlphas(backdrops, 0, backdropAlphas[i], progress);
            }
            //Set text alphas
            for (int i = 0; i < textFields.Length; i++)
            {
                LerpAlphas(textFields, 0, textAlphas[i], progress);
            }

            yield return null;
        }

        progress = 0;
        yield return new WaitForSeconds(stayVisibleTime);

        while (progress < 1)
        {
            progress += Time.deltaTime / fadeOutTime;

            //Set backdrop alphas
            for (int i = 0; i < backdrops.Length; i++)
            {
                LerpAlphas(backdrops, backdropAlphas[i], 0, progress);
            }
            //Set text alphas
            for (int i = 0; i < textFields.Length; i++)
            {
                LerpAlphas(textFields, textAlphas[i], 0, progress);
            }

            yield return null;
        }

        fadeCoroutine = null;
    }

    private void ResetFade(Level _)
    {
        if (fadeCoroutine != null) { StopCoroutine(fadeCoroutine); }
        fadeCoroutine = StartCoroutine(FadeInOut());
    }

    private void LerpAlphas(Image[] arrayWithAlphas, float from, float to, float t)
    {
        for (int i = 0; i < arrayWithAlphas.Length; i++)
        {
            arrayWithAlphas[i].color = SetAlpha(arrayWithAlphas[i].color, Mathf.SmoothStep(from, to, t));
        }
    }
    private void LerpAlphas(TextMeshProUGUI[] arrayWithAlphas, float from, float to, float t)
    {
        for (int i = 0; i < arrayWithAlphas.Length; i++)
        {
            arrayWithAlphas[i].color = SetAlpha(arrayWithAlphas[i].color, Mathf.SmoothStep(from, to, t));
        }
    }

    private Color SetAlpha(Color color, float alpha)
    {
        return new Color(color.r, color.g, color.b, alpha);
    }
}
