using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFrontDoor : MonoBehaviour
{
    [SerializeField] Door frontDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            frontDoor.CloseDoor();
            StartCoroutine(DestroyScript());
        }
    }

    private IEnumerator DestroyScript()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this);
    }
}
