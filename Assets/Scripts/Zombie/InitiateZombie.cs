using System.Collections;
using UnityEngine;

public class InitiateZombie : MonoBehaviour
{
    [SerializeField] private AudioSource breathing, screach;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    private Vector3 direction = Vector3.forward;

    public void StartBreath()
    {
        breathing.Play();
        StartCoroutine(StartCrawling());
    }

    private IEnumerator StartCrawling()
    {
        screach.Play();
        anim.SetTrigger("crawl");

        float elapsedTime = 0f;
        while (elapsedTime < 5f) // Move for 3 seconds
        {
            transform.Translate(direction * speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
