using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpenDoor : MonoBehaviour, IInteractable
{
    private void Start()
    {
        TextAppear.Initialize();
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextAppear.SetText("Something clicked");
        }
    }

    public void OnInteractEnter()
    {
        TextAppear.SetText("Interact");
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }
}
