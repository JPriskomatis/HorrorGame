using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiningRoomAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private AudioSource audioSource;
    private bool playedAudio = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hello");
            InitiateAnim();
            TotalHorrorScript.FindObjectOfType<TotalHorrorScript>().StartBreathing();

            StartCoroutine(DestroyScript());
        }
    }
    private void InitiateAnim()
    {
        anim.SetTrigger("start");
        if (playedAudio)
        {
            audioSource.Play();
            playedAudio = false;
        }
        
    }

    IEnumerator DestroyScript()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
