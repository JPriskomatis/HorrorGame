using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTotalHorror : MonoBehaviour
{
    [SerializeField] private GameObject totalHorror;
    [SerializeField] private TotalHorrorScript totalHorrorScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            totalHorror.SetActive(true);
            totalHorrorScript.StartBreathing();
        }
    }
}
