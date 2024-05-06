using TMPro;
using UnityEngine;

public class Candle : MonoBehaviour, IInteractable
{
    private HighlightEffect highlight;
    private bool emissionToggled = false;

    [SerializeField] private string textToDisplay;

    private PickUpItem pickUpItem;

    private void Start()
    {
        // Initialize highlight effect
        highlight = GetComponent<HighlightEffect>();
        pickUpItem = FindObjectOfType<PickUpItem>();
        TextAppear.Initialize();
    }


    public void ToggleEmmision()
    {
        if (!emissionToggled) // Check if emission has not been toggled yet
        {
            highlight.ToggleEmission();
            emissionToggled = !emissionToggled; // Set the flag to true
        }
    }


    public void Interact()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextAppear.RemoveText();
            //highlight.ToggleEmission();
            pickUpItem.PickUp(this.gameObject);

            TextAppear.RemoveText();
            Destroy(gameObject);
        }
    }
    public void OnInteractExit()
    {
        ToggleEmmision();
        emissionToggled = !emissionToggled;
    }
    public void OnInteractEnter()
    {
        TextAppear.SetText(textToDisplay);
        ToggleEmmision();
        emissionToggled = !emissionToggled;
    }
}
