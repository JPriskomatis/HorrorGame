using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NoteWindow : MonoBehaviour, IInteractable
{
    [SerializeField] private NurseWindow nurseWindow;
    [SerializeField] private string textToDisplay;

    private void Start()
    {
        TextAppear.Initialize();
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextAppear.SetText("textToDisplay");
            nurseWindow.NurseDisappear();
            Destroy(this);
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
