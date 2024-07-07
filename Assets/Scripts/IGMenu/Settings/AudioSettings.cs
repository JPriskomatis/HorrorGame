using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] GameObject audioContainer;
    [SerializeField] VideoSettings videoContainer;




    public void CloseAudio()
    {
        audioContainer.SetActive(false);
        videoContainer.OpenVideo();
    }
    public void OpenAudio()
    {
        audioContainer.SetActive(true);
        videoContainer.CloseVideo();
    }
}
