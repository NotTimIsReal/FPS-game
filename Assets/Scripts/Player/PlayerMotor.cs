using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5.0f;
    public float gravity = -9.8f;
    private bool isGrounded;
    public float jumpHeight = 3.0f;
    private bool lerpCrouch = false;
    private float crouchTimer = 0.0f;
    private bool crouching = false;
    private bool sprinting = false;
    [SerializeField]
    private AudioClip walkSound;
    [SerializeField]
    private AudioClip sprintSound;
    [SerializeField]
    private AudioClip jumpSound;
    private new AudioSource audio;
    private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        inputManager = GetComponent<InputManager>();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    // Update is called once per frame
    void Update()
    {

        inputManager.onFoot.Crouch.performed += ctx => Crouch();
        inputManager.onFoot.Sprint.performed += ctx => Sprint();
        inputManager.onFoot.Movement.performed += ctx =>
        {
            audio.clip = walkSound;
            audio.loop = true;
            audio.Play();
        };
        inputManager.onFoot.Movement.canceled += ctx =>
        {
            audio.clip = walkSound;
            audio.Stop();
        };
        inputManager.onFoot.Jump.performed += ctx =>
        {
            audio.clip = jumpSound;
            audio.Play();
        };
        inputManager.onFoot.Sprint.performed += ctx =>
        {
            audio.clip = sprintSound;
            audio.Play();
        };
        inputManager.onFoot.Sprint.canceled += ctx =>
        {
            audio.clip = sprintSound;
            audio.Stop();
        };
        inputManager.onFoot.Jump.canceled += ctx =>
        {
            audio.clip = jumpSound;
            audio.Stop();
        };


        isGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1f, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2f, p);
            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0.0f;
            }
        }
    }
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);

    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }
    public void Crouch()
    {
        if (sprinting)
        {
            this.Sprint();
        }
        crouching = !crouching;
        crouchTimer = 0.0f;
        lerpCrouch = true;
        if (crouching)
            speed = 3.0f;
        else
            speed = 5.0f;
    }
    public void Sprint()
    {
        if (crouching)
        {
            this.Crouch();
        }
        sprinting = !sprinting;
        if (sprinting)
            speed = 10;
        else
            speed = 5;
    }
}
