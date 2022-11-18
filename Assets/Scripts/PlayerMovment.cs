using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float movmentSpeed = 10f;
    [SerializeField] float jumpHeight = 5f;
    Rigidbody rb;
    bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Jumping();
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

    private void Mover()
    {
        float x = Input.GetAxis("Horizontal") * movmentSpeed;
        float z = Input.GetAxis("Vertical") * movmentSpeed;
        Vector3 changePosition = transform.right * x + transform.forward * z;
        rb.velocity = new Vector3(changePosition.x, rb.velocity.y, changePosition.z);
    }
}
