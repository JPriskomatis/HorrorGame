using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedScript : MonoBehaviour, IInteractable
{
    [SerializeField] private Hide hide;
    [SerializeField] private Movement movement;
    [SerializeField] private GameObject floor;
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            movement.Hide(floor);
        }
    }

    public void OnInteractEnter()
    {
        TextAppear.SetText("Hide");
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }
}
