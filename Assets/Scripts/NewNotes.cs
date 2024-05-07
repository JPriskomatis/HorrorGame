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
        textComponent.text = string.Empty;
        textComponent.gameObject.SetActive(false);
        index = 0;
    }
}
