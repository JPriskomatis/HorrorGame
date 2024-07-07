using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSettings : MonoBehaviour
{
    [SerializeField] GameObject videoSettings;
    [SerializeField] AudioSettings audioSettings;


    public void CloseVideo()
    {
        videoSettings.SetActive(false);
        audioSettings.OpenAudio();
    }

    public void OpenVideo()
    {
        videoSettings.SetActive(true);
        audioSettings.CloseAudio();
    }

    public void SetExplanationText()
    {

    }
}
