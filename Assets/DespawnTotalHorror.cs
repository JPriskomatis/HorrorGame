using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTotalHorror : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private GameObject totalHorror;

    private bool canDespawn;

    private void Start()
    {
        canDespawn = false;
    }
    private void Update()
    {
        if (door.open)
        {
            canDespawn = true;
            
        }
        if(canDespawn && !door.open)
        {
            totalHorror.SetActive(false);
        }
    }
}
