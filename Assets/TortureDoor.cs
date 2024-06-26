using UnityEngine;
using System.Collections;

public class TortureDoor : MonoBehaviour
{
    public Animator anim;
    public AudioSource audioSource;

    private bool slamming;

    [SerializeField] private GameObject totalHorrorScript;

    void Start()
    {
        slamming = true;
        StartCoroutine(SlamCoroutine());
    }

    IEnumerator SlamCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // Wait for 2 seconds

            StartSlaming(); // Call your function to start slamming
        }
    }

    public void StartSlaming()
    {
        
        anim.SetTrigger("slamTrigger"); // Trigger the "slamTrigger" parameter in Animator
        // Wait for the duration of your slam animation
        StartCoroutine(ResetSlam());

    }

    IEnumerator ResetSlam()
    {
        yield return new WaitForSeconds(2f);

        // Stop the audio after the animation duration
        anim.ResetTrigger("slamTrigger");

        // Reset the animator parameter after a delay
        yield return new WaitForSeconds(2f); // Adjust delay as needed

    }
    public void PlayAudio()
    {
        audioSource.Play();
    }

    public void OpenDoor()
    {
        slamming = false;

        anim.SetBool("openDoor", true);
        totalHorrorScript.SetActive(true);
    }
}