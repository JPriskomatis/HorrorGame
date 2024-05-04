using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextAppear))]
public class ToiletScript : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim;
    TextAppear textAppear;
    private bool isOpen;
    [SerializeField] private AudioSource headAudio;


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
            // Use FadeInAndPlay method to fade in audio and play it
            headAudio.Play();
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            anim.SetBool("Open", false);
            isOpen = false;
            // Use FadeOut method to fade out the audio
            headAudio.Play();
        }
    }

    public void OnInteractEnter()
    {
        if (!isOpen)
        {
            textAppear.SetText("Open");
        }
    }

    public void OnInteractExit()
    {
        textAppear.RemoveText();
    }
}
