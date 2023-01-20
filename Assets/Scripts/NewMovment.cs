using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovment : MonoBehaviour
{
    public GameObject eq;
    public WatchSlot watchslot;
    public float movmentSpeed = 10f;
    public float sprintSpeed = 15f;
    float jumpHeight = 1.2f;
    Rigidbody rb;
    bool isGrounded = false;
    [HideInInspector] public bool isEqVisible = false;
    float playerSpeed;
    public CharacterController controller;
    Vector3 velocity;
    float gravity = -15f;

    public Transform groundCheck;
    float groundDistance = 0.4f;
    public LayerMask groundMask;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = movmentSpeed;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (!isEqVisible)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.freezeRotation = true;
            Sprinting();
            MoveAndJump();
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        ShowEq();
    }

    private void MoveAndJump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * playerSpeed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void ShowEq()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isEqVisible)
            {

                eq.SetActive(false);
                isEqVisible = false;
                Cursor.lockState = CursorLockMode.Locked;
                GetComponent<RotatePlayer>().enabled = true;
                watchslot.BoostMenager();
                EqManager.instance.SlotMenager();
            }
            else
            {
                eq.SetActive(true);
                isEqVisible = true;
                Cursor.lockState = CursorLockMode.Confined;
                GetComponent<RotatePlayer>().enabled = false;
            }
        }
    }

    private void Sprinting()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            playerSpeed = sprintSpeed * watchslot.sprintBoost;
        }
        else
        {
            playerSpeed = movmentSpeed * watchslot.sprintBoost;
        }
    }

}
