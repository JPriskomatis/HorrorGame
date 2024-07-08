using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBlack : MonoBehaviour
{
    public void StartFade()
    {
        StartCoroutine(DoFade());
    }
    IEnumerator DoFade()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

        


        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha+= Time.deltaTime*3;
            yield return null;
        }
        yield return new WaitForSeconds(0.75f);

        while(canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime*2;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
    }

}
