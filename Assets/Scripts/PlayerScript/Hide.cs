using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void HideUnderBed()
    {
        anim.SetTrigger("Hide");
    }

    public void LeaveFromUnderBed()
    {
        anim.SetBool("hide", false);

    }

}
