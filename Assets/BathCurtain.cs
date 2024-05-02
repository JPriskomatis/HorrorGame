using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextAppear))]
public class BathCurtain : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim;
    private TextAppear textAppear;

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
        textAppear.SetText("Draw Curtains");
    }

    public void OnInteractExit()
    {
        textAppear.RemoveText();
    }
}
