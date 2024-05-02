using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextAppear))]
public class FrontDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim;
    TextAppear textAppear;


    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("Open", true);
        }
    }

    public void OnInteractEnter()
    {
        textAppear.SetText("Press E to Open");
    }

    public void OnInteractExit()
    {
        textAppear.RemoveText();
    }
}
