using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator anim;

    private void OnEnable()
    {
        audioSource.Play();

    }
}
