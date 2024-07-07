using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExplanationText : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] string textToDisplay;
    [SerializeField] TextMeshProUGUI explanationText;
    public void OnPointerEnter(PointerEventData eventData)
    {
        explanationText.text = textToDisplay;
    }
}
