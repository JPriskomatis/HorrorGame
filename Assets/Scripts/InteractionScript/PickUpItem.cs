using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private GameObject placeHolder;
    [SerializeField] private GameObject placeHolderLeft;
    [SerializeField] private Transform parentObject;
    private List<GameObject> pickedUpItems = new List<GameObject>(); // List to hold picked-up items
    public string currentPickedUpItemName;

    public void PickUp(GameObject item, bool useLeftPlaceholder = false)
    {
        Debug.Log("Picking up Item");

        // Determine which placeholder to use
        GameObject selectedPlaceholder = useLeftPlaceholder ? placeHolderLeft : placeHolder;

        // Instantiate and set the new picked-up item
        GameObject newItem = Instantiate(item, selectedPlaceholder.transform.position, selectedPlaceholder.transform.rotation);
        newItem.transform.parent = parentObject;

        currentPickedUpItemName = item.name;
        // Remove all scripts from the picked-up item
        RemoveAllScripts(newItem);

        // Add the picked-up item to the list
        pickedUpItems.Add(newItem);
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
