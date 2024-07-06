using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour, IInteractable
{
    bool moveBooks = false;
    [SerializeField] Animator anim;

    [SerializeField] SwitchButton btn;
    bool firstInteract = true;

    [SerializeField] AudioSource audioSource;

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
            {
            if (!moveBooks)
            {
                TextAppear.RemoveText();


                TextAppear.SetText("There's a switch there");
                StartCoroutine(TextForSwitch());
                
            }
            else
            {
                //MOVE Books;
                anim.SetTrigger("move");
                audioSource.Play();

                btn.GetComponent<SphereCollider>().enabled = true;

                Component scriptToDestroy = this.GetComponent<BookShelf>();
                Destroy(scriptToDestroy);
            }
        }
        
        
    }

    public void OnInteractEnter()
    {
        if (firstInteract)
        {
            TextAppear.SetText("Inspect");
            firstInteract = false;

        } else
            TextAppear.SetText("Move books");

    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }

    IEnumerator TextForSwitch()
    {
        yield return new WaitForSeconds(1.5f);
        TextAppear.SetText("Move books");
        moveBooks = true;
    }
}
