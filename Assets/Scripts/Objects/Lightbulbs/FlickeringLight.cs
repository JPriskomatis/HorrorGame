using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    [SerializeField] private GameObject lightBulb, lightbulb2;

    private void Awake()
    {
        StartCoroutine(Flickering());
    }
    public IEnumerator Flickering()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.75f);
            lightBulb.SetActive(!lightBulb.activeSelf);
            lightbulb2.SetActive(!lightbulb2.activeSelf);
        }
        
    }
}
