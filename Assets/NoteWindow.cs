using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextAppear))]
public class NoteWindow : MonoBehaviour, IInteractable
{
    [SerializeField] private NurseWindow nurseWindow;
    private TextAppear textAppear;

    private void Start()
    {
        textAppear = GetComponent<TextAppear>();
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            textAppear.SetText("Notes about how special herbs can put someone in a coma-like state");
            nurseWindow.NurseDisappear();
            Destroy(this);
        }
    }

    public void OnInteractEnter()
    {
        textAppear.SetText("Read");
    }

    public void OnInteractExit()
    {
        textAppear.RemoveText();
    }


}
