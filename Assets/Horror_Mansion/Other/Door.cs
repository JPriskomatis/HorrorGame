using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    bool trig, open;
    bool ePressed = false;
    public float smooth = 2.0f;
    public float DoorOpenAngle = 90.0f;
    public float rotationTolerance = 1.0f; // Tolerance for stopping rotation
    private Quaternion defaultRot;
    private Quaternion openRot;
    public Text txt;

    [SerializeField] private AudioSource closeAudio;
    [SerializeField] private AudioSource openAudio;
    [SerializeField] private AudioSource lockedAudio;

    [SerializeField] private bool locked;

    void Start()
    {
        defaultRot = transform.rotation;
        openRot = Quaternion.Euler(defaultRot.eulerAngles + Vector3.up * DoorOpenAngle);
    }

    void Update()
    {
        if (ePressed && trig)
        {
            TryToggleDoor();
        }

        if (open && Quaternion.Angle(transform.rotation, openRot) > rotationTolerance)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, openRot, Time.deltaTime * smooth);
        }
        else if (!open && Quaternion.Angle(transform.rotation, defaultRot) > rotationTolerance)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, defaultRot, Time.deltaTime * smooth);
        }

        if (trig)
        {
            UpdateUIText();
        }
    }

    void TryToggleDoor()
    {
        if (!locked) // Check if the door is not locked
        {
            ToggleDoorState();
        }
        else
        {
            HandleLockedDoor();
        }
    }

    void ToggleDoorState()
    {
        if (!open)
        {
            openAudio.Play();
        }
        else
        {
            closeAudio.Play();
        }
        open = !open;
        
        ePressed = false;
    }

    void HandleLockedDoor()
    {
        // Door is locked, provide feedback or take appropriate action
        Debug.Log("The door is locked.");
        ePressed = false;
        lockedAudio.Play();
    }

    void UpdateUIText()
    {
        if (open)
        {
            txt.text = "Close E";
        }
        else
        {
            txt.text = "Open E";
        }
    }
    public void CloseDoor()
    {
        closeAudio.Play();
        open = false;
        locked = true;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            UpdateUIText();
            trig = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            txt.text = " ";
            trig = false;
        }
    }

    private void OnTriggerStay(Collider coll)
    {
        if (coll.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            ePressed = true;
        }
    }
}
