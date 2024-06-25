using System.Collections;
using UnityEngine;

public class TortureRoomDoor : MonoBehaviour
{
    public Animator anim;
    public AudioSource audioSource;
    private bool isSlamming = false;

    void Start()
    {
        StartCoroutine(SlamCoroutine());
    }

    IEnumerator SlamCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);

            StartSlaming(); 
        }
    }

    public void StartSlaming()
    {
        if (!isSlamming) // Ensure slamming is not already in progress
        {
            isSlamming = true;
            anim.SetBool("slam", true);
            audioSource.Play();

            // Optionally, you can reset the slam animation after a delay
            StartCoroutine(ResetSlam());
        }
    }

    IEnumerator ResetSlam()
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("slam", false);
        isSlamming = false;
    }
}
