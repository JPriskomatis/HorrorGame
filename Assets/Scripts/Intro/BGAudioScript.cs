using System.Collections;
using UnityEngine;

public class BGAudioScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float fadeDuration = 10.0f;
    private bool isFadingIn = false;
    private bool isFadingOut = false;

    private void Start()
    {
        if (audioSource == null)
        {
            return;
        }

        FadeIn();
    }

    void Update()
    {
        // Check if fading in and update the volume accordingly
        if (isFadingIn)
        {
            // Calculate the progress of the fade
            float progress = Mathf.Clamp01(Time.time / fadeDuration);

            // Increase the volume over time
            audioSource.volume = Mathf.Lerp(0f, 0.8f, progress);

            // Check if fade is complete
            if (progress >= 1.0f)
            {
                isFadingIn = false;
            }
        }

        // Check if fading out and update the volume accordingly
        if (isFadingOut)
        {
            // Calculate the progress of the fade
            float progress = Mathf.Clamp01(Time.time / fadeDuration);

            // Decrease the volume over time
            audioSource.volume = Mathf.Lerp(0.8f, 0f, progress);

            // Check if fade is complete
            if (progress >= 1.0f)
            {
                isFadingOut = false;
                audioSource.Stop(); // Stop the audio after fading out
            }
        }
    }

    void FadeIn()
    {
        audioSource.volume = 0f;
        isFadingIn = true;
    }

    public void FadeOut()
    {
        isFadingOut = true;
    }
}