using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(TextAppear))]
public class BloodAppearPhotos : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject blood1, blood2, blood3;
    private TextAppear textAppear;
    [SerializeField] private AudioSource bloodspalsh;
    [SerializeField] private AudioSource tenseAudio;
    

    private void Start()
    {
        textAppear = GetComponent<TextAppear>();
    }

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            textAppear.SetText("Appears to be a family photo...");
            StartCoroutine(InitiateBlood());
        }
    }

    public void OnInteractEnter()
    {
        textAppear.SetText("Inspect Photos");
    }

    public void OnInteractExit()
    {
        textAppear.RemoveText();
    }

    private IEnumerator InitiateBlood()
    {
        yield return new WaitForSeconds(2f);
        bloodspalsh.Play();
        tenseAudio.Play();
        StartCoroutine(FadeAudioSource.StartFade(tenseAudio, 2f, 1));


        blood1.SetActive(true);
        blood2.SetActive(true);
        blood3.SetActive(true);

    }
}
