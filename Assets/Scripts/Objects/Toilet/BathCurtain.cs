using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathCurtain : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource curtainOpenAudio;

    private bool isOpen;

    private void Start()
    {
        TextAppear.Initialize();
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
            TextAppear.SetText("Draw Curtains");

        }
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }
}
