using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnocking : MonoBehaviour
{
    [SerializeField] private AudioSource knockingAudio;

    public void StartKnocking()
    {
        knockingAudio.Play();
    }

    public void StopKnocking()
    {
        knockingAudio?.Stop();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StopKnocking();
            }
        }
    }
}
