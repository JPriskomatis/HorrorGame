using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private PlayerTalking playerTalking;

    [SerializeField] private AudioClip audioclip;
    [SerializeField] private string text;

    private void Start()
    {
        StartCoroutine(StartGameTalk());
    }

    private IEnumerator StartGameTalk()
    {
        yield return new WaitForSeconds(2f);
        playerTalking.PlayerTalk(audioclip, text);
    }
}
