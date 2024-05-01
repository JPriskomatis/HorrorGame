using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    [SerializeField] bool cursorLock = true;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float Speed = 6.0f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] float gravity = -30f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] private AudioSource footstepsAudio;
    [SerializeField] private AudioClip stoneFootstepSound;
    [SerializeField] private AudioClip grassFootstepSound;
    private string floorTag;


    private bool isFirstCollision = true;

    public float jumpHeight = 6f;
    float velocityY;
    bool isGrounded;

    float cameraCap;
    Vector2 currentMouseDelta;
    Vector2 currentMouseDeltaVelocity;

    CharacterController controller;
    Vector2 currentDir;
    Vector2 currentDirVelocity;

    //Get the current State of the game;
    private UIController stateController;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        stateController = FindObjectOfType<UIController>();

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }

        footstepsAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (stateController.canMove)
        {
            UpdateMouse();
            UpdateMove();

            // Check for player movement and play/stop audio accordingly
            if (currentDir.magnitude > 0.1f)
            {
                // Start playing footstep audio based on ground material
                FootstepsAudio();
                Debug.Log("Now walking");
            }
            else
            {
                // Stop audio when not moving
                footstepsAudio.Stop();
            }
        }
        else
        {
            footstepsAudio.Stop();


        }
    }

    void UpdateMouse()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraCap -= currentMouseDelta.y * mouseSensitivity;

        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraCap;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMove()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground);

        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (isGrounded)  // Reset velocityY when grounded
        {
            velocityY = -0.001f;  // You can set it to a small negative value to keep the player grounded
        }
        else
        {
            velocityY += gravity * 2f * Time.deltaTime;
        }

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * Speed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (isGrounded && controller.velocity.y < -1f)
        {
            velocityY = -8f;
        }
    }

    private void FootstepsAudio()
    {
        // Check if the footstep audio is already playing
        if (!footstepsAudio.isPlaying)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                floorTag = hit.collider.tag;

                if (floorTag == "Grass")
                {
                    footstepsAudio.clip = grassFootstepSound;
                }
                else if (floorTag == "stone")
                {
                    footstepsAudio.clip = stoneFootstepSound;
                }

                // Play the footstep audio
                footstepsAudio.Play();

            }
        }
    }

}
