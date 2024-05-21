using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineGlass : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject wine;
    [SerializeField] private AudioSource gettingCut;
    [SerializeField] private CrossScript cross, cross2, cross3;
    public bool canCut;

    [SerializeField] private GameObject candleHolder;
    [SerializeField] private LightManager lightManager;
    [SerializeField] private Collider floorTriger;
    [SerializeField] private CameraShake cameraShake;


    private void Start()
    {
        TextAppear.Initialize();
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && canCut)
        {
            //Start cutting hand;
            StartCoroutine(FillCup());
        }
    }

    public void OnInteractEnter()
    {
        if (canCut)
        {
            TextAppear.SetText("Press E to cut yourself");
            canCut = true;
        }


    }

    public void OnInteractExit()
    {

        TextAppear.RemoveText();
    }

    IEnumerator FillCup()
    {
        yield return new WaitForSeconds(0.5f);
        gettingCut.Play();
        wine.SetActive(true);
        cross.StartCrossAnim();
        cross2.StartCrossAnim();
        cross3.StartCrossAnim();

        cameraShake.shakeDuration = 1f;
        
        CloseAllLights();
        cameraShake.shakeAmount = 0.4f;

        EnableCollider();
        FlashCandleLight();

        



    }

    private void EnableCollider()
    {
        floorTriger.GetComponent<Collider>().enabled = true;
    }
    private void CloseAllLights()
    {
        lightManager.EraseLight();
    }

    private void FlashCandleLight()
    {
        candleHolder.SetActive(false);
        StartCoroutine(ToggleLight());

    }

    IEnumerator ToggleLight()
    {
        yield return new WaitForSeconds(1);
        candleHolder.SetActive(true);
        StartCoroutine(DestroyScripts());

    }
    IEnumerator DestroyScripts()
    {
        yield return new WaitForSeconds(1f);

        // Get all the components attached to the GameObject
        Component[] components = GetComponents<Component>();

        // Iterate through all the components except Transform (which is always attached)
        foreach (Component component in components)
        {
            // Skip the Transform component
            if (component.GetType() == typeof(Transform))
                continue;

            // Destroy the component
            Destroy(component);
        }
    }
}
