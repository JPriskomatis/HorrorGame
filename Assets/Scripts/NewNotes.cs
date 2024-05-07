using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewNotes : MonoBehaviour
{
    [SerializeField] private string[] text;
    [SerializeField] private TextMeshProUGUI textComponent;
    private int index;

    private void Update()
    {
        //If we press the space button we go the next line;
        if (Input.GetKeyDown(KeyCode.Space)){
            NextLine();
        }
    }

    public void TransferStrings(string[] texts)
    {
        System.Array.Resize(ref text, texts.Length);
        for (int i = 0; i < texts.Length; i++)
        {
            text[i] = texts[i];
            EnableDialogue();
        }
    }
    private void EnableDialogue()
    {
        //Activate gameobject;
        textComponent.gameObject.SetActive(true);

        //Make it empty;
        textComponent.text = string.Empty;

        //Initialize Index;
        index = 0;

        //Start Dialogue;
        Dialogue();
        
    }
    private void Dialogue()
    {

        //Assing text to it;
        if (index < text.Length)
        {
            //Assign text to it;
            textComponent.text = this.text[index];
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

        //we reset our index so that next iteration we start from 0;
        index = 0;
    }
}
