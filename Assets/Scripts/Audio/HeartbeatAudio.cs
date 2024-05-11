using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartbeatAudio : MonoBehaviour
{
    [SerializeField] private AudioSource heartBeat;
    [SerializeField] private AudioSource heavyBreathing;
    public void InitiateHeartbeat()
    {
        heartBeat.Play();
        StartCoroutine(Breathing());
    }

    private IEnumerator Breathing()
    {
        yield return new WaitForSeconds(0.65f);
        heavyBreathing.Play();
    }
}
