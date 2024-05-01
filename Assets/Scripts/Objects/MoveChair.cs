using UnityEngine;
using System.Collections;

public class MoveChair : MonoBehaviour, IInteractable
{
    private ChairPuzzle chairPuzzle;
    [SerializeField] private int chairNumber;
    private bool pull;

    private TextAppear textAppear;

    private void Start()
    {
        chairPuzzle = FindObjectOfType<ChairPuzzle>();
        textAppear = FindObjectOfType<TextAppear>();
    }

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(MoveChairCoroutine());
            // Toggle pull value
            pull = !pull;
            if (pull)
            {
                chairPuzzle.AddChairToList(chairNumber);
            }
            else
            {
                chairPuzzle.RemoveChairFromList(chairNumber);
            }
        }
    }

    IEnumerator MoveChairCoroutine()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = !pull ? transform.position + Vector3.forward * 0.8f : transform.position - Vector3.forward * 0.8f;
        float duration = 1.0f; // Adjust the duration of the movement
        float timer = 0f;

        while (timer < duration)
        {
            float t = timer / duration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }

    public void OnInteractEnter()
    {
        textAppear.SetText(pull ? "Pull the chair" : "Push the chair");
    }

    public void OnInteractExit()
    {
        textAppear.RemoveText();
    }
}
