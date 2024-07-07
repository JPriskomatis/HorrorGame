using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMenu : MonoBehaviour
{
    [SerializeField] GameObject igmenuPanel;

    bool isOpen;

    [SerializeField] GameObject movement;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            CheckMenu();
        }
    }
    public void CheckMenu()
    {
        if (isOpen)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();

        }
    }

    public void OpenMenu()
    {
        igmenuPanel.SetActive(true);
        movement.GetComponent<Movement>().enabled = false;

        //Reveal Cursor;
        Cursor.lockState = CursorLockMode.None;

        isOpen = true;

    }

    public void CloseMenu()
    {
        //Hide cursor;
        Cursor.lockState = CursorLockMode.Locked;

        movement.GetComponent<Movement>().enabled = true;

        igmenuPanel.SetActive(false);

        isOpen = false;
    }
}
