using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkBeer : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource drinkAudio, burp;
    [SerializeField] private Animator anim;

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextAppear.RemoveText();
            anim.SetTrigger("drink");
            drinkAudio.Play();
            
            StartCoroutine(Burp());
            
            
        }
    }

    public void OnInteractEnter()
    {
        TextAppear.SetText("Drink");
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }

    private IEnumerator Burp()
    {
        
        yield return new WaitForSeconds(2f);
        Debug.Log("Start animation");
        anim.SetTrigger("leave");
        burp.Play();
        StartCoroutine(DeleteScript());
    }

    private IEnumerator DeleteScript()
    {
        
        yield return new WaitForSeconds(1f);
        
        Component scriptToRemove = this.GetComponent<DrinkBeer>();
        Destroy(scriptToRemove);
    }
}
