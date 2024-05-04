using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextAppear))]
public class ToiletScript : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim;
    TextAppear textAppear;
    private bool isOpen;
    private void Start()
    {
        textAppear = GetComponent<TextAppear>();
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            anim.SetBool("Open", true);
            isOpen = true;
        }
    }

    public void OnInteractEnter()
    {
        if (isOpen)
        {
            textAppear.SetText("Open");

        }
    }

    public void OnInteractExit()
    {
        textAppear.RemoveText();
    }

    
}
