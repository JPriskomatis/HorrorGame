using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotesScript : MonoBehaviour, IInteractable
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    private float speed = 0.1f;
    private int index;
    [SerializeField] private AudioSource bgAudio;

    private void Start()
    {
        textComponent.text = string.Empty;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(textComponent.text ==lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void StartDialogue()
    {
        bgAudio.Play();
        textComponent.gameObject.SetActive(true);
        textComponent.text = string.Empty;
        index = 0;
        StartCoroutine(TypeLine());

    }

    private IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(speed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            bgAudio.loop = false;
            textComponent.gameObject.SetActive(false);
        }
            
    }

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextAppear.RemoveText();
            StartDialogue();
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