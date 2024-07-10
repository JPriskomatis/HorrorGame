using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoom : MonoBehaviour
{
    [SerializeField] GameObject nurse;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nurse.SetActive(true);
            nurse.GetComponent<NurseWindow>().enabled = true;
            nurse.GetComponent<NurseWindow>().NurseDisappear();
        }
    }
}
