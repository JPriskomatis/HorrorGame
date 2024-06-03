using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * We create a controlled infinite loop that plays the thunder audio
 * every X seconds;
 */
public class ThunderAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool loop;
    private bool canPlayAudio;

    private void Start()
    {
        canPlayAudio = true;            //If we don't have this flag variable then the audio will play many times (as it gets called once per frame);
        loop = true;
    }

    private void Update()
    {
        if (loop && canPlayAudio)
        {
            StartCoroutine(Thunder());
        }
    }

    private IEnumerator Thunder()
    {
        canPlayAudio = false;
        yield return new WaitForSeconds(20f);

        audioSource.PlayOneShot(audioSource.clip);
        canPlayAudio = true;
    }

}
