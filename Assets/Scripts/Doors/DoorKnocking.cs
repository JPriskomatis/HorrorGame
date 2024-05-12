using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnocking : MonoBehaviour
{
    [SerializeField] private AudioSource knockingAudio;
    [SerializeField] private Door door;

    private void Update()
    {
        if (door.open)
        {
            StopKnocking();
            Component scriptToDel = this.GetComponent<DoorKnocking>();
            Destroy(scriptToDel);
        }
    }
    public void StartKnocking()
    {
        knockingAudio.Play();
    }

    public void StopKnocking()
    {
        knockingAudio?.Stop();
    }
    
}
