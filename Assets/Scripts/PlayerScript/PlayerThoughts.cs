using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerThoughts : MonoBehaviour
{
    public bool displayText;

    [SerializeField] private string[] doorLockedTexts;
    [SerializeField] private AudioClip[] doorLockedAudios;

    // State Texts
    [SerializeField] private string[] calmTexts;
    [SerializeField] private string[] mildStressTexts;
    [SerializeField] private string[] highStressTexts;
    [SerializeField] private string[] panicTexts;

    [SerializeField] private TextMeshProUGUI thoughtsText;

    private Health stressSystem; // Reference to the Health script
    private float nextUpdateTime; // Time for next text update
    private const float updateInterval = 25f; // Time interval to display the text
    private Coroutine textDisappearCoroutine; // Coroutine reference for text disappearance
    private Dictionary<string, AudioClip> lockedDoorAudioMap = new Dictionary<string, AudioClip>();
    private AudioSource audioSource;

    private void Start()
    {

        stressSystem = FindObjectOfType<Health>(); // Get reference to Health script
        nextUpdateTime = Time.time + updateInterval; // Set initial update time
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < doorLockedTexts.Length; i++)
        {
            if (i < doorLockedAudios.Length)
            {
                lockedDoorAudioMap.Add(doorLockedTexts[i], doorLockedAudios[i]);
            }
            else
            {
                Debug.LogWarning("Not enough audio clips for all locked door texts.");
                break;
            }
        }


    }

    public void DoorLockedText()
    {
        int textIndex = Random.Range(0, doorLockedTexts.Length);
        thoughtsText.gameObject.SetActive(true);
        thoughtsText.text = doorLockedTexts[textIndex];

        if (lockedDoorAudioMap.ContainsKey(doorLockedTexts[textIndex]))
        {
            audioSource.clip = lockedDoorAudioMap[doorLockedTexts[textIndex]];
            audioSource.Play();
        }


        // Set playerThinking to true since thoughtsText is active
        displayText = true;

        // If the text disappearance coroutine is already running, don't start a new one
        if (textDisappearCoroutine != null)
        {
            StopCoroutine(textDisappearCoroutine);
        }

        // Start a new coroutine to make the text disappear after 2 seconds
        textDisappearCoroutine = StartCoroutine(TextDisappearCoroutine());
    }

    // Coroutine to make the text disappear after 2 seconds
    private IEnumerator TextDisappearCoroutine()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        
        yield return new WaitForSeconds(2f);
        displayText = false;
        thoughtsText.gameObject.SetActive(false);

    }

    // Update the thoughts text content based on the player's stress state
    public void UpdateThoughtsText()
    {
        // Start a coroutine to wait until displayText becomes false
        StartCoroutine(WaitForDisplayText());

        // The rest of the method will be executed once displayText is false
    }

    private IEnumerator WaitForDisplayText()
    {
        // Wait until displayText becomes false
        while (displayText)
        {
            // Wait for a short time before checking again
            // This prevents the loop from consuming too much CPU
            yield return null;
        }

        // Once displayText is false, execute the remaining part of UpdateThoughtsText()
        // Select random text from the appropriate array based on the current stress state
        string[] selectedTexts;
        switch (stressSystem.GetState())
        {
            case Health.StressState.Calm:
                Debug.Log("Test");
                selectedTexts = calmTexts;
                break;
            case Health.StressState.MildStress:
                selectedTexts = mildStressTexts;
                break;
            case Health.StressState.HighStress:
                selectedTexts = highStressTexts;
                break;
            case Health.StressState.Panic:
                selectedTexts = panicTexts;
                break;
            default:
                selectedTexts = calmTexts; // Default to calm texts if state is unknown
                break;
        }

        // Select a random text from the selected array
        int textIndex = Random.Range(0, selectedTexts.Length);

        // Display the selected text
        thoughtsText.gameObject.SetActive(true);
        thoughtsText.text = selectedTexts[textIndex];


        // Cancel any existing coroutine before starting a new one
        if (textDisappearCoroutine != null)
            StopCoroutine(textDisappearCoroutine);

        // Start a new coroutine to make the text disappear after 2 seconds
        textDisappearCoroutine = StartCoroutine(TextDisappearCoroutine());
    }

}
