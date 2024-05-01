using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    private TextMeshProUGUI text;
    private PlayerThoughts playerThoughts;

    private void Start()
    {
        playerThoughts = FindObjectOfType<PlayerThoughts>();

        // Find the GameObject named "InteractionText" and get its TextMeshPro component
        GameObject interactionTextObject = GameObject.Find("InteractionText");
        if (interactionTextObject != null)
        {
            text = interactionTextObject.GetComponent<TextMeshProUGUI>();
            if (text == null)
            {
                Debug.LogError("No TextMeshProUGUI component found on the InteractionText GameObject.");
            }
        }
        else
        {
            Debug.LogError("InteractionText GameObject is not found.");
        }
    }

    public void SetText(string textToPut)
    {
        if (text != null)
        {
            text.text = textToPut;
            text.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component is not assigned.");
        }
    }

    public void RemoveText()
    {
        if (text != null)
        {
            text.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component is not assigned.");
        }
    }
}
