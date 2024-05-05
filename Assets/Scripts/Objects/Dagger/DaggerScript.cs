using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerScript : MonoBehaviour, IInteractable
{

    private PickUpItem pickUp;
    private Vector3 initialPos;
    [SerializeField] private GameObject item;
    private bool picked;


    private void Start()
    {
        pickUp = FindObjectOfType<PickUpItem>();
        TextAppear.Initialize();
        initialPos = gameObject.transform.position;

       

        
    }

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && !picked)
        {
            // Use pickedUpTransform's transform to set position and rotation

            
            pickUp.PickUp(this.gameObject);
            //Instantiate(item, initialPos, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void OnInteractEnter()
    {
        if (!picked)
            TextAppear.SetText("Pickup the Dagger");
    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();
    }
}
