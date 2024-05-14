using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpeech : MonoBehaviour, IInteractable
{
    [SerializeField] AudioSource zombieSpeech;
    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteractEnter()
    {
        TextAppear.SetText("What the hell is even that?");
        zombieSpeech.Play();
        StartCoroutine(DeleteScript());
    }

    public void OnInteractExit()
    {
        Debug.Log("Exited");
    }

    private IEnumerator DeleteScript()
    {
        yield return new WaitForSeconds(1.5f);
        TextAppear.RemoveText();
        Component scriptToDel = this.GetComponent<ZombieSpeech>();
        Destroy(scriptToDel);
    }
}