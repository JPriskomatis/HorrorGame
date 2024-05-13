using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] float timeOn = 0.3f;
    [SerializeField] float timeOff = 0.75f;
    private float changeTime = 0;

    [SerializeField] private bool flicker;

    void Update()
    {
        if (flicker)
        {
            if (Time.time > changeTime)
            {
                GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
                if (GetComponent<Light>().enabled)
                {
                    changeTime = Time.time + timeOn;
                }
                else
                {
                    changeTime = Time.time + timeOff;
                }
            }
        }
        
    }
}
