using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseWindow : MonoBehaviour
{
    [SerializeField] private AudioSource jumpscareAudio;
    [SerializeField] private Camera cam;

    public void NurseDisappear()
    {
        gameObject.SetActive(true);
        StartCoroutine(InitiateDisappear());
    }

    private IEnumerator InitiateDisappear()
    {
        // Check if the player is looking at this GameObject
        while (!IsPlayerLookingAt())
        {
            yield return null; // Wait until the player looks at the GameObject
        }

        jumpscareAudio.Play();
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
        int layerMask = LayerMask.GetMask("monster", "nurse_LP");

        // Raycast from the camera to this GameObject, ignoring all other layers
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Hit: " + hit.collider.gameObject.name);
            // Check if the hit GameObject is this GameObject
            return hit.collider.gameObject == gameObject;
        }
        return false;
    }
}
