using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatchPlayer : MonoBehaviour
{
    [SerializeField] AudioSource screech;
    [SerializeField] Animator anim;
    [SerializeField] private float minDistance;
    [SerializeField] GameObject player;

    //Time interval between checks in seconds;
    [SerializeField] private float checkInterval = 0.3f;

    private void Start()
    {
        screech.Play();
        anim.SetTrigger("walk");
        StartCoroutine(CheckDistance());
    }

    private IEnumerator CheckDistance()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkInterval);

            if (Vector3.Distance(this.transform.position, player.transform.position) < minDistance)
            {
                anim.SetTrigger("attack");
                //Optionally break the coroutine if the attack is a one-time event;
                break;
            }
        }
    }
}
