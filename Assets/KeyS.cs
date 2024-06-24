using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyS : MonoBehaviour, IInteractable
{
    [SerializeField] private Door door;
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextAppear.RemoveText();
            door.locked = false;

            StartCoroutine(KeyText());
        }
    }

    public void OnInteractEnter()
    {
        TextAppear.SetText("Grab Key");
        
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }

    IEnumerator KeyText()
    {
        yield return new WaitForSeconds(1f);
        TextAppear.SetText("2nd floor 1 door");
        yield return new WaitForSeconds(2f);
        TextAppear.RemoveText();

        Destroy(this);
    }
}
