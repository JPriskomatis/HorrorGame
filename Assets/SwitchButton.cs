using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour, IInteractable
{
    [SerializeField] Animator anim;
    [SerializeField] AudioSource audioSource;
    [SerializeField] SecretRoom room;

    private void Start()
    {
        this.GetComponent<SwitchButton>().enabled = false;
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextAppear.RemoveText();
            anim.SetTrigger("swtich");
            audioSource.Play();

            room.RevealRoom();
        }

    }

    public void OnInteractEnter()
    {
        TextAppear.SetText("Press");
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }
}
