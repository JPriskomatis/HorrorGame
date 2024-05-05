using System.Collections;
using UnityEngine;

public class PhoneScript : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource currentCall;
    [SerializeField] private AudioSource pickUpCall;




    private Quest quest;
    private void Start()
    {
        quest = FindObjectOfType<Quest>();
        TextAppear.Initialize();
        audioSource.Play();

    }

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            audioSource.Stop();
            PlayCall();
            
            quest.ActivateQuest("Read the Book");

        }
    }
    private void PlayCall()
    {
        pickUpCall.Play();
        StartCoroutine(waitForPhonecall());
    }

    IEnumerator waitForPhonecall()
    {
        while (pickUpCall.isPlaying)
        {
            yield return null;
        }
        currentCall.Play();
    }

    public void OnInteractEnter()
    {
        TextAppear.SetText("Pick up the phone");
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }
}
