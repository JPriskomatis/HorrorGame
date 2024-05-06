using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZombie : MonoBehaviour
{
    [SerializeField] private InitiateZombie initiazeZombie;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            initiazeZombie.StartBreath();
        }
    }
}
