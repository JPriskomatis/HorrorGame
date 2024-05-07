using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextContent : MonoBehaviour, IInteractable
{
    [SerializeField] string[] textToDisplay;
    [SerializeField] private NewNotes newNotes;

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            newNotes.TransferStrings(textToDisplay);
        }
    }

    public void OnInteractEnter()
    {
        TextAppear.SetText("Read");
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }
}
