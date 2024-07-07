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

[RequireComponent(typeof(AudioSource))]
public class TextContent : MonoBehaviour, IInteractable
{
    [SerializeField] string[] textToDisplay;
    [SerializeField] AudioClip[] speechToDisplay;
    private AudioSource audioSource;
    [HideInInspector] public Dictionary<string, AudioClip> dictionary = new Dictionary<string, AudioClip>();
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        for(int i = 0; i < textToDisplay.Length; i++)
        {
            dictionary.Add(textToDisplay[i], speechToDisplay[i]);
        }
    }

    [SerializeField] private NewNotes newNotes;

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ReadTextContent();
            
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

    public void ReadTextContent()
    {
        newNotes.TransferStrings(textToDisplay);
        newNotes.TransferAudios(speechToDisplay);

        TextAppear.RemoveText();
    }
}
