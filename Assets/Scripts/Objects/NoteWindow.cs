using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NoteWindow : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject nurse;
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
            TextAppear.SetText(textToDisplay);

            nurse.GetComponent<NurseWindow>().enabled = true;
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
