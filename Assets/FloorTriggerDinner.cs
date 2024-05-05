using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTriggerDinner : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource chairAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("start", true);
            chairAudio.Play();
            Component thisScript = this.GetComponent<FloorTriggerDinner>();
            Destroy(thisScript);
        }
    }
}
