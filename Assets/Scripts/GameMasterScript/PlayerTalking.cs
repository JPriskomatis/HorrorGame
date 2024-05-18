using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/**
    Script for managing whenever the player wants to talk to himself about something;
    Note* This is not the same as when he reads about notes or items;
    This is simple for the situations when they discover a new place or something similar;
     */


public class PlayerTalking : MonoBehaviour
{
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI textComp;



    public void PlayerTalk(AudioClip audioClip, string texts)
    {
        textComp.gameObject.SetActive(true);
        audioSource.clip = audioClip;
        audioSource.Play();
        textComp.text = texts;


        StartCoroutine(DisableText());


        
    }
    private IEnumerator DisableText()
    {
        yield return new WaitForSeconds(5f);
        textComp.gameObject.SetActive(false);
    }

}
