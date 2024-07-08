using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseWindow : MonoBehaviour
{
    [SerializeField] private AudioSource jumpscareAudio;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform player;

    [SerializeField] private FadeBlack fadeBlack;

    public void NurseDisappear()
    {
        gameObject.SetActive(true);
        StartCoroutine(InitiateDisappear());
    }

    private void Update()
    {
        transform.LookAt(player);
    }
    private IEnumerator InitiateDisappear()
    {
        // Check if the player is looking at this GameObject
        while (!IsPlayerLookingAt())
        {
            yield return null; // Wait until the player looks at the GameObject
        }

        jumpscareAudio.Play();
        fadeBlack.StartFade();
        yield return new WaitForSeconds(0.75f);
        

        // Check if the GameObject is still active before destroying it
        if (gameObject != null && gameObject.activeSelf)
        {
            Destroy(gameObject);
        }
    }

    // Function to check if the player is looking at this GameObject
    private bool IsPlayerLookingAt()
    {
        // Layer mask to only hit colliders on the "Default" layer and the "Nurse_LP" layer
        int layerMask = LayerMask.GetMask("monster", "nurse_lp");

        // Raycast from the camera to this GameObject, ignoring all other layers
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            //Debug.Log("Hit: " + hit.collider.gameObject.name);
            // Check if the hit GameObject is this GameObject
            Debug.Log(hit.collider.gameObject.name);
            return hit.collider.gameObject == gameObject;
        }
        return false;
    }
}
