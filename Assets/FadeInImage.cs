using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInImage : MonoBehaviour
{
    [SerializeField] GameObject textToDisplay;
    [SerializeField] private RawImage logo;
    float alpha = 0f;

    private void Start()
    {
        // Initialize the logo's alpha value
        Color currColor = logo.color;
        currColor.a = alpha;
        logo.color = currColor;

        // Start the fade-in coroutine
        StartCoroutine(StartfadeIn());
    }

    IEnumerator StartfadeIn()
    {
        // Wait for 2 seconds before starting the fade
        yield return new WaitForSeconds(2f);

        // Manually fade in the alpha since CrossFadeAlpha doesn't work with RawImage
        float duration = 2f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);
            Color currColor = logo.color;
            currColor.a = newAlpha;
            logo.color = currColor;

            yield return null;
        }

        yield return new WaitForSeconds(2f);
        StartCoroutine(StartfadeOut());
    }

    IEnumerator StartfadeOut()
    {
        // Wait for 2 seconds before starting the fade
        yield return new WaitForSeconds(2f);

        // Manually fade in the alpha since CrossFadeAlpha doesn't work with RawImage
        float duration = 2f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            Color currColor = logo.color;
            currColor.a = newAlpha;
            logo.color = currColor;

            yield return null;
        }

        yield return new WaitForSeconds(1.5f);
        textToDisplay.SetActive(true);
    }
}



