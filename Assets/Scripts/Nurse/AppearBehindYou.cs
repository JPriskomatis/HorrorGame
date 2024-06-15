using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearBehindYou : MonoBehaviour
{
    [SerializeField] private GameObject nurse;   // Reference to the nurse prefab
    [SerializeField] private GameObject player;  // Reference to the player GameObject

    private Vector3 offset = new Vector3(0, 0, 2);  // Offset to place nurse behind the player

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            // Calculate spawn position directly behind the player
            Vector3 spawnPosition = player.transform.position - player.transform.forward * offset.z;

            // Instantiate nurse prefab at calculated position with player's rotation
            Instantiate(nurse, spawnPosition, player.transform.rotation);
        }
    }
}
