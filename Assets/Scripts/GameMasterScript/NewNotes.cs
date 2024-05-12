using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NewNotes : MonoBehaviour
{
    [SerializeField] private string[] text;
    [SerializeField] private AudioClip[] text2;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private TextMeshProUGUI spaceComponent;
    private int index;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //If we press the space button we go the next line;
        if (Input.GetKeyDown(KeyCode.Space)){
            NextLine();
        }
    }

    //Transfer the strings from the gameobject into the textMeshProGUI text component;
    public void TransferStrings(string[] texts)
    {
        System.Array.Resize(ref text, texts.Length);
        for (int i = 0; i < texts.Length; i++)
        {
            text[i] = texts[i];
            EnableDialogue();
        }
    }

    //We get the audioclips from the gameobject;
    public void TransferAudios(AudioClip[] audios)
    {
        //Resize the audioClips array to match the length of the audios array;
        System.Array.Resize(ref text2, audios.Length);

        //Store each audio clip in the audioclip array;
        for (int i = 0; i < audios.Length; i++)
        {
            text2[i] = audios[i];
        }

        // Enable dialogue after storing the audio clips
        EnableDialogue();
    }

    private void EnableDialogue()
    {
        //Activate gameobject;
        textComponent.gameObject.SetActive(true);

        //Activate spaceText;
        spaceComponent.gameObject.SetActive(true);

        //Make it empty;
        textComponent.text = string.Empty;

        //Initialize Index;
        index = 0;

        //Start Dialogue;
        Dialogue();
        
    }
    private void Dialogue()
    {
        //Check if the index is within the range of the text array;
        if (index >= 0 && index < text.Length)
        {
            //Display the text from the text array;
            textComponent.text = text[index];

            //If the index is within the range of the text2 array;
            if (index >= 0 && index < text2.Length)
            {
                //Play the audio clip from the text2 array;
                if (text2[index] != null)
                {
                    //Assuming you have an AudioSource component attached to the same GameObject;
                    //You can play the audio clip directly;
                    GetComponent<AudioSource>().clip = text2[index];
                    GetComponent<AudioSource>().Play();
                }
                else
                {
                    Debug.LogWarning("AudioClip is null at index " + index);
                }
            }
        }
    }

    private void NextLine()
    {
        //If the arraylist is not empty (means index==text.length)
        //then proceed to the next line;
        if(index < text.Length - 1)
        {
            index++;
            Dialogue();
        }
        else
        {
            EndOfDialogue();
        }
    }
    private void EndOfDialogue()
    {
        //We deactivate our object
        textComponent.text = string.Empty;
        textComponent.gameObject.SetActive(false);
        spaceComponent.gameObject.SetActive(false);

        //we reset our index so that next iteration we start from 0;
        index = 0;
    }
}
