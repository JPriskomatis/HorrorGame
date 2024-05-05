using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookObject : MonoBehaviour, IInteractable
{

    private BookManager bookManager;
    private HighlightEffect highlight;
    private bool emissionToggled = false;

    [HideInInspector] public bool isOpen;


    [SerializeField] private string textToDisplay;


    private Quest quest;

    public void Start()
    {
        highlight = GetComponent<HighlightEffect>();
        bookManager = FindObjectOfType<BookManager>();
        TextAppear.Initialize();
        isOpen = false;
        quest = FindObjectOfType<Quest>();
    }
    public void ToggleEmmision()
    {
        if (!emissionToggled) // Check if emission has not been toggled yet
        {
            highlight.ToggleEmission();
            emissionToggled = !emissionToggled; // Set the flag to true
        }
    }
    public void OnInteractExit()
    {
        ToggleEmmision();
        emissionToggled = !emissionToggled;
    }
    public void OnInteractEnter()
    {
        ToggleEmmision();
        emissionToggled = !emissionToggled;
    }

    public void Interact()
    {
        TextAppear.SetText(textToDisplay);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isOpen)
            {
                OpenBook();
                quest.CompleteQuest();
                quest.ActivateQuest("Fill in the wine glass");
                isOpen = true;
            }else
            {
                CloseBook();

                isOpen = false;
            }
        }
        
    }

    public void OpenBook()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bookManager.ReadBook();
            isOpen = true;
        }
    }
    public void CloseBook()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bookManager.CloseBook();
            isOpen = false;
        }
    }
    
}