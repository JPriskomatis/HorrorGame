using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource close;
    [SerializeField] private AudioSource open;
    [SerializeField] private AudioSource lockedAudio;
    public bool locked;


    public void OpenDoor()
    {
        anim.SetTrigger("Open");
        open.Play();

        if (gameObject.tag==("nurseDisappear"))
        {
            NurseDisappear nurse = FindObjectOfType<NurseDisappear>();
            nurse.DisappearNurse();
        }
    }

    public void CloseDoor()
    {
        anim.SetTrigger("Close");

    }
    public void CloseAudio()
    {
        close.Play();
    }

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!locked)
            {
                OpenDoor();
            }
            else
            {
                PlayerThoughts.FindObjectOfType<PlayerThoughts>().DoorLockedText();
                lockedAudio.Play();
            }
        }
    }

    public void OnInteractEnter()
    {
        Debug.Log("Can Open door");
    }

    public void OnInteractExit()
    {
        Debug.Log("Cannot Open door");
    }
}
