using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleFall : MonoBehaviour
{
    [SerializeField] private GameObject bottle;
    [SerializeField] private GameObject piecesToDis;

    [SerializeField] private AudioSource bottleAudio;
    [SerializeField] private GameObject totalHorror;

    [SerializeField] private TortureDoor tortureDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bottle.SetActive(false);
            piecesToDis.SetActive(true);
            bottleAudio.Play();
            


            Component thisScript = this.GetComponent<BottleFall>();
            //Activate TotalHorror monster;
            totalHorror.SetActive(true);

            
            tortureDoor.OpenDoor();

            Destroy(thisScript);
        }
    }


}
