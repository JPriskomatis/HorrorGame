using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class BloodAppearPhotos : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject blood1, blood2, blood3;
    
    [SerializeField] private AudioSource bloodspalsh;
    [SerializeField] private AudioSource tenseAudio;
    [SerializeField] private AudioSource speech;
    

    private void Start()
    {
        TextAppear.Initialize();
    }

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextAppear.SetText("Appears to be a family photo...");
            speech.Play();
            StartCoroutine(InitiateBlood());
        }
    }

    public void OnInteractEnter()
    {
        TextAppear.SetText("Inspect Photos");
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
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
        Component targetScript = this.GetComponent<BloodAppearPhotos>();
        Destroy(targetScript);

    }
}
