using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoom : MonoBehaviour
{
    [SerializeField] Animator anim;
    public void RevealRoom()
    {
        anim.SetTrigger("move");
    }
}
