using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The sore purpose of this script is so that each gameobject we want
 * to have a readable note on it, can have its text stored here;
 * When we want to read the text, we simply transfer the array of
 * strings to the UI gameobject with the script that displays the
 * text ot the user.
 */

public class TextContent : MonoBehaviour, IInteractable
{
    [SerializeField] string[] textToDisplay;
    [SerializeField] private NewNotes newNotes;

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            newNotes.TransferStrings(textToDisplay);
            TextAppear.RemoveText();
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
