using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float movmentSpeed = 10f;
    [SerializeField] float sprintSpeed = 15f;
    [SerializeField] float jumpHeight = 5f;
    Rigidbody rb;
    bool isJumping = false;
    bool isSprinting = false;
    float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = movmentSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        Moving();
        Jumping();
        Sprinting();
    }

    private void Sprinting()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
        if (isSprinting && !isJumping)
        {
            playerSpeed = sprintSpeed;
        }
        else
        {
            playerSpeed = movmentSpeed;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "floor")
        {
            isJumping = false;
        }
    }
    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void Moving()
    {
        float x = Input.GetAxis("Horizontal") * playerSpeed;
        float z = Input.GetAxis("Vertical") * playerSpeed;
        Vector3 changePosition = transform.right * x + transform.forward * z;
        rb.velocity = new Vector3(changePosition.x, rb.velocity.y, changePosition.z);
    }
}
