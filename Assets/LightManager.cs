using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private Light[] lightObjects;
    [SerializeField] private GameObject[] lights;

    public void EraseLight()
    {
        for (int i = 0; i < lightObjects.Length; i++)
        {
            lightObjects[i].GetComponent<Light>().enabled = false;
        }

        for (int i = 0; i < lights.Length; i++)
        {
            ParticleSystem particleSystem = lights[i].GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                //particleSystem.gameObject.SetActive(false);
                var emissionModule = particleSystem.emission;
                emissionModule.enabled = false;
                
            }
        }
    }
    
}
