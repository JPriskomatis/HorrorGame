using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSecretRoom : MonoBehaviour
{
    [SerializeField] Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            anim.SetTrigger("close");
        }
    }
}
