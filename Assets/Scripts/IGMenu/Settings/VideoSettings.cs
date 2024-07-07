using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSettings : MonoBehaviour
{
    [SerializeField] GameObject videoSettings;
    [SerializeField] GameObject audioSettings;


    public void CloseVideo()
    {
        videoSettings.SetActive(false);
        audioSettings.SetActive(true);
    }

    public void OpenVideo()
    {
        videoSettings.SetActive(true);
        audioSettings.SetActive(false);
    }

}
