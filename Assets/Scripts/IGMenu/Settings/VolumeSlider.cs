using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public TextMeshProUGUI volumeText;

    void Start()
    {
        // Ensure the text reflects the initial slider value
        UpdateText(volumeSlider.value);

        // Add a listener to update the text whenever the slider value changes
        volumeSlider.onValueChanged.AddListener(delegate { UpdateText(volumeSlider.value); });
    }

    void UpdateText(float value)
    {
        volumeText.text = value.ToString("0"); // Display the value as an integer
    }
}