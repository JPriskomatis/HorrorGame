using System.Collections;
using UnityEngine;

public class AppearBehindYou : MonoBehaviour
{
    [SerializeField] private GameObject nursePrefab;   // Reference to the nurse prefab
    [SerializeField] private GameObject player;        // Reference to the player GameObject

    private float offsetDistance = 1f;                // Distance behind the player

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            // Calculate spawn position directly behind the player
            Vector3 spawnPosition = player.transform.position - player.transform.forward * offsetDistance;

            // Instantiate nurse prefab at calculated position with the correct rotation
            GameObject spawnedNurse = Instantiate(nursePrefab, spawnPosition, Quaternion.LookRotation(player.transform.forward, Vector3.up));

            // Play audio source on the instantiated nurse
            spawnedNurse.GetComponent<AudioSource>().Play();

            // Start coroutine to initiate disappearance when player looks at the nurse
            StartCoroutine(DisappearNurse(spawnedNurse));
        }
    }

    IEnumerator DisappearNurse(GameObject nurse)
    {
        while (true)
        {
            // Check if the player is looking towards the nurse
            Vector3 directionToNurse = nurse.transform.position - player.transform.position;
            float dotProduct = Vector3.Dot(player.transform.forward, directionToNurse.normalized);

            // If player looks at the nurse (dot product is positive), then destroy the nurse
            if (dotProduct > 0)
            {
                yield return new WaitForSeconds(1);
                Destroy(nurse);
                yield break; // Exit coroutine
            }

            yield return null; // Wait for next frame to check again
        }
    }
}
