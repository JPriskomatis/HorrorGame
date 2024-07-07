using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] GameObject audioContainer;
    [SerializeField] GameObject videoContainer;




    public void CloseAudio()
    {
        audioContainer.SetActive(false);
        videoContainer.SetActive(true);
    }
    public void OpenAudio()
    {
        audioContainer.SetActive(true);
        videoContainer.SetActive(false);
    }
}
