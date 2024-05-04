using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFrontDoor : MonoBehaviour
{
    [SerializeField] Door frontDoor;
    [SerializeField] DoorKnocking knocking;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            frontDoor.CloseDoor();
            
            StartCoroutine(StartKnocking());
            StartCoroutine(DestroyScript());
        }
    }

    private IEnumerator StartKnocking()
    {
        yield return new WaitForSeconds(1f);
        knocking.StartKnocking();
    }
    private IEnumerator DestroyScript()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this);
    }
}
