using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineGlass : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject wine;

    private bool canCut;
    private Quest quest;
    [SerializeField] private DoorScript doorScript;
    private void Start()
    {
        TextAppear.Initialize();
        quest = FindObjectOfType<Quest>();
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && canCut)
        {
            //Start cutting hand;
            StartCoroutine(FillCup());
        }
    }

    public void OnInteractEnter()
    {
        if (PickUpItem.FindObjectOfType<PickUpItem>().currentPickedUpItemName == "DaggerPivot")
        {
            TextAppear.SetText("Press E to cut yourself");
            canCut = true;
        }
        else Debug.Log("No dagger");
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }

    IEnumerator FillCup()
    {
        yield return new WaitForSeconds(1f);
        wine.SetActive(true);
        quest.CompleteQuest();
        doorScript.locked = false;
        Debug.Log("Complete quest");
        StartCoroutine(DestroyScripts());
    }

    IEnumerator DestroyScripts()
    {
        yield return new WaitForSeconds(1f);

        // Get all the components attached to the GameObject
        Component[] components = GetComponents<Component>();

        // Iterate through all the components except Transform (which is always attached)
        foreach (Component component in components)
        {
            // Skip the Transform component
            if (component.GetType() == typeof(Transform))
                continue;

            // Destroy the component
            Destroy(component);
        }
    }
}
