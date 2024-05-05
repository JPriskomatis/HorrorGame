using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TalkingPaiting : MonoBehaviour, IInteractable
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] private string textToDisplay;

    private bool canInteract = false;

    private void Start()
    {
        TextAppear.Initialize();
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            video.Play();
            TextAppear.RemoveText();
        }
    }

    public void OnInteractEnter()
    {
        TextAppear.SetText(textToDisplay);
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }



}
