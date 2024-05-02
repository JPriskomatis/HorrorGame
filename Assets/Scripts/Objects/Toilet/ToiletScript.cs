using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextAppear))]
public class ToiletScript : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim;
    TextAppear textAppear;

    private void Start()
    {
        textAppear = GetComponent<TextAppear>();
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
        textAppear.SetText("Open");
    }

    public void OnInteractExit()
    {
        textAppear.RemoveText();
    }

    
}
