using UnityEngine;
using System.Collections;

public class TotalHorrorScript : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource breathing;
    [SerializeField] private AudioSource screech;
    [SerializeField] private AudioSource jumpscare;
    [SerializeField] private HeartbeatAudio heartBeat;

    public Transform player;
    public float speed = 5f;
    [SerializeField] private float lookSpeed = 10f;
    [SerializeField] private float activationDistance = 0.1f; // Distance threshold for activating the function
    [SerializeField] private float fadeDuration = 5f; // Duration of the fade-in effect
    [SerializeField] private GameObject floor;

    private bool canChase = false;
    private bool isBreathing = false;
    private bool hasPlayedAudio = false; // Flag to track if audio clips have been played


    private void Start()
    {
        breathing.Play();
        heartBeat = FindObjectOfType<HeartbeatAudio>();
    }

    private void Update()
    {
        if (player != null && canChase)
        {
            

            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);

            // Calculate the distance between the object and the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Check if the distance is lower than the activation distance
            if (distanceToPlayer < activationDistance)
            {
                // Call the function
                DeactivateGameObject();
            }
        }
        else
        {
            Debug.LogWarning("Player reference is not set or canChase flag is false!");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayedAudio) // Check if player triggered and audio hasn't been played yet
        {
            Debug.Log("Player");
            canChase = true;
            anim.SetTrigger("walk");
            breathing.Stop();

            screech.Play();
            jumpscare.Play();
            isBreathing = false;
            heartBeat.InitiateHeartbeat();

            hasPlayedAudio = true; // Set the flag to true to indicate that audio has been played
        }
    }

    private void DeactivateGameObject()
    {
        
        Component ScrpiptToRemove = floor.GetComponent<SpawnTotalHorror>();
        Destroy(ScrpiptToRemove);
        gameObject.SetActive(false);
    }

    public void StartBreathing()
    {
        isBreathing = true;
        StartCoroutine(FadeInBreathingAudio());
    }

    private IEnumerator FadeInBreathingAudio()
    {
        // Ensure breathing audio is stopped and reset volume to zero
        breathing.Stop();
        breathing.volume = 0f;

        // Play the breathing audio
        breathing.Play();

        // Gradually increase the volume over time
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            breathing.volume = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure volume is set to 1 at the end
        breathing.volume = 1f;
    }
}