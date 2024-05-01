using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseDisappear : MonoBehaviour
{

    [SerializeField] private GameObject candleFlame;
    [SerializeField] private AudioSource jumpscare;
    public void DisappearNurse()
    {
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        

        yield return new WaitForSeconds(1f);

        jumpscare.Play();

        yield return new WaitForSeconds(1.25f);

        candleFlame.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
