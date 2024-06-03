using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] FadeText fadeText;
    [SerializeField] TextMeshProUGUI textToDisplay;

    private void Start()
    {
        StartCoroutine(FirstText());
    }

    IEnumerator FirstText()
    {
        yield return new WaitForSeconds(3f);
        textToDisplay.text = "This game contains scenes of explicit violence and gore.";
        fadeText.FadeInText();
        yield return new WaitForSeconds(fadeText.fadeDuration);
        StartCoroutine(FirstTextDisappear());
    }

    IEnumerator FirstTextDisappear()
    {
        yield return new WaitForSeconds(4f);
        fadeText.FadeOutText();
        
        StartCoroutine(SecondarySpriteTexture());
    }

    IEnumerator SecondarySpriteTexture()
    {
        yield return new WaitForSeconds(fadeText.fadeDuration);
        textToDisplay.text = " If you have a history of heart conditions, epilepsy, or are prone to panic attacks, we strongly advise against playing this game.";
        fadeText.FadeInText();
        yield return new WaitForSeconds(fadeText.fadeDuration);
        StartCoroutine(SecondTextDisappear());
    }

    IEnumerator SecondTextDisappear()
    {
        yield return new WaitForSeconds(4f);
        fadeText.FadeOutText();
        StartCoroutine(ThirdTextDisappear());


    }

    IEnumerator ThirdTextDisappear()
    {
        yield return new WaitForSeconds(fadeText.fadeDuration);
        textToDisplay.text = "For the best experience, we recommend playing with <b>headphones</b>.";
        fadeText.FadeInText();
        yield return new WaitForSeconds(fadeText.fadeDuration);
        fadeText.FadeOutText();
    }
}
