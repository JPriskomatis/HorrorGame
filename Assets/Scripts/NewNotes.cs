using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewNotes : MonoBehaviour, IInteractable
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
            textComponent.text = text[index];
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

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextAppear.RemoveText();
            EnableDialogue();
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
