using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NoteWindow : MonoBehaviour, IInteractable
{
    [SerializeField] private NurseWindow nurseWindow;

    private void Start()
    {
        TextAppear.Initialize();
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextAppear.SetText("Notes about how special herbs can put someone in a coma-like state");
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
