using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim;

    private void Start()
    {
        TextAppear.Initialize();
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("Open", true);
        }
    }

    public void OnInteractEnter()
    {
        TextAppear.SetText("Press E to Open");
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }

    public void CloseDoor()
    {
        anim.SetBool("Open", false);
        anim.SetBool("Close", true);
    }
}
