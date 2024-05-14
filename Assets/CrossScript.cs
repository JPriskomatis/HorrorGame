using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossScript : MonoBehaviour
{
    [SerializeField] private AudioSource crossAudio;
    [SerializeField] private Animator anim;

    public void StartCrossAnim()
    {
        crossAudio.Play();
        anim.SetBool("Play", true);
    }
}
