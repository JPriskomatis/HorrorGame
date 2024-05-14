using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour, IInteractable
{
    [SerializeField] private TextContent content;
    [SerializeField] private GameObject wineGlass;
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextAppear.RemoveText();
            content.ReadTextContent();
            wineGlass.GetComponent<WineGlass>().enabled = true;
            wineGlass.GetComponent<WineGlass>().canCut = true;

        }
    }

    public void OnInteractEnter()
    {
        TextAppear.SetText("Read");
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }
}
