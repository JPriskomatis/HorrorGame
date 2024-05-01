using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseTrigger : MonoBehaviour
{
    [SerializeField] private NurseDisappear nurseDisappear;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            nurseDisappear.DisappearNurse();
            Destroy(gameObject);
        }
    }
}
