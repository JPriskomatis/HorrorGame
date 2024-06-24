using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPlayer : MonoBehaviour
{
    [SerializeField] AudioSource screech;
    [SerializeField] Animator anim;
    [SerializeField] private float minDistance;
    [SerializeField] GameObject player;
    private void Start()
    {
        screech.Play();
        anim.SetTrigger("walk");
    }

    private void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < minDistance)
        {
            anim.SetTrigger("attack");
        }
    }
}
