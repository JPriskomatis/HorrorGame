using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearBehindYou : MonoBehaviour
{
    [SerializeField] private GameObject nurse;   // Reference to the nurse prefab
    [SerializeField] private GameObject player;  // Reference to the player GameObject

    private float offsetDistance = 2.0f; // Distance behind the player

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            // Calculate spawn position directly behind the player
            Vector3 spawnPosition = player.transform.position - player.transform.forward * offsetDistance;

            // Instantiate nurse prefab at calculated position with the player's rotation
            GameObject spawnedNurse = Instantiate(nurse, spawnPosition, Quaternion.LookRotation(player.transform.forward, Vector3.up));

            // Play the audio source on the instantiated nurse
            spawnedNurse.GetComponent<AudioSource>().Play();
        }
    }
}
