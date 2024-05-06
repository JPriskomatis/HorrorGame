using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartbeatAudio : MonoBehaviour
{
    [SerializeField] private AudioSource heartBeat;

    public void InitiateHeartbeat()
    {
        heartBeat.Play();
    }
}
