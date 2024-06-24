using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent agent; // Reference to the NavMeshAgent component
    public Transform player;   // Reference to the player's transform

    [SerializeField] private float minDistance;


    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component if not assigned
        }

        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player"); // Find the player object by tag
            if (playerObject != null)
            {
                player = playerObject.transform; // Get the player's transform
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && agent != null)
        {
            
            transform.LookAt(player);
            agent.SetDestination(player.position); // Set the destination of the agent to the player's position

            anim.SetTrigger("walk");


        }
    }
}