using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            menu.SetActive(true);
        }
    }

    public void Resume()
    {
        menu.SetActive(false);  
    }
}
