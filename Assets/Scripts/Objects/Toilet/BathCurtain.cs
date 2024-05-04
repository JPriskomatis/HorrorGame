using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextAppear))]
public class BathCurtain : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource curtainOpenAudio;
    private TextAppear textAppear;
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
            curtainOpenAudio.Play();
            isOpen = true;
        }
    }

    public void OnInteractEnter()
    {
        if (!isOpen)
        {
            textAppear.SetText("Draw Curtains");

        }
    }

    public void OnInteractExit()
    {
        textAppear.RemoveText();
    }
}
