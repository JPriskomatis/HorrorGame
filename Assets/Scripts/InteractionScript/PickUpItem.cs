using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private GameObject placeHolder;
    [SerializeField] private Transform parentObject;
    private GameObject currentPickedUpItem;

    public string currentPickedUpItemName;

    public void PickUp(GameObject item)
    {

        Debug.Log("Picking up Item");
        // Check if there's already a picked-up item
        if (currentPickedUpItem != null)
        {
            // Destroy the current picked-up item
            Destroy(currentPickedUpItem);
            Debug.Log("Destroy");
        }

        // Instantiate and set the new picked-up item
        currentPickedUpItem = Instantiate(item, placeHolder.transform.position, placeHolder.transform.rotation);
        currentPickedUpItem.transform.parent = parentObject;

        currentPickedUpItemName = item.name;
        // Remove all scripts from the picked-up item
        RemoveAllScripts(currentPickedUpItem);
    }


    //We remove all scripts from the picked-up item;
    private void RemoveAllScripts(GameObject gameObject)
    {
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            // Check if the script is not this script itself
            if (script != this)
            {
                Destroy(script);
            }
        }
    }

}
