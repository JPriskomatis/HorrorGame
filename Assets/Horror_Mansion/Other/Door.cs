using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] public bool isEnabled;


    [HideInInspector] public bool open;

    public float smooth = 2.0f;
    public float DoorOpenAngle = 90.0f;
    public float rotationTolerance = 1.0f; // Tolerance for stopping rotation
    private Quaternion defaultRot;
    private Quaternion openRot;


    [SerializeField] private AudioSource closeAudio;
    [SerializeField] private AudioSource openAudio;
    [SerializeField] private AudioSource lockedAudio;

    [SerializeField] private bool locked;

    void Start()
    {
        defaultRot = transform.rotation;
        openRot = Quaternion.Euler(defaultRot.eulerAngles + Vector3.up * DoorOpenAngle);
        TextAppear.Initialize();
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


    }

    void HandleLockedDoor()
    {
        // Door is locked, provide feedback or take appropriate action;
        Debug.Log("The door is locked.");

        //Player talking that the door is locked;
        PlayerThoughts.FindObjectOfType<PlayerThoughts>().DoorLockedText();

        lockedAudio.Play();
    }

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
    }

    public void OnInteractEnter()
    {
        if (isEnabled)
        {
            TextAppear.SetText("Open");
        }

    }

    public void OnInteractExit()
    {
        TextAppear.RemoveText();

    }

    public void CloseDoor()
    {
        {
            closeAudio.Play();
            open = false;
            locked = true;
            transform.rotation = defaultRot; // Reset rotation to default
        }
    }
}
