using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletScript : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim;
    private bool isOpen;
    [SerializeField] private AudioSource headAudio;
    [SerializeField] private GameObject cautionTapes;


    private void Start()
    {
        TextAppear.Initialize();
    }

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            anim.SetBool("Open", true);
            isOpen = true;
            this.GetComponent<SphereCollider>().enabled = false;
            // Use FadeInAndPlay method to fade in audio and play it
            headAudio.Play();

            Destroy(cautionTapes);
        }
        
    }

    public void OnInteractEnter()
    {
        if (!isOpen)
        {
            TextAppear.SetText("Open");
        }
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }
}
