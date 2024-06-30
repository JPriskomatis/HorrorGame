using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpenDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim, bookAnim;
    [SerializeField] private AudioSource doorCreakingAudio;
    [SerializeField] private Door doorToOpen;
    private void Start()
    {
        TextAppear.Initialize();
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextAppear.RemoveText();

            bookAnim.SetTrigger("push");
            TextAppear.SetText("Something clicked");

            anim.SetTrigger("open");
            doorCreakingAudio.Play();

            Component doorScript = doorToOpen.GetComponent<Door>();
            Destroy(doorScript);
            StartCoroutine(DestroyScript());
        }
    }
    private IEnumerator DestroyScript()
    {
        
        yield return new WaitForSeconds(2f);
        Destroy(this);
    }

    public void OnInteractEnter()
    {
        TextAppear.SetText("Interact");
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }
}
