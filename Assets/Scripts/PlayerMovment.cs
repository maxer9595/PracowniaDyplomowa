using UnityEngine;


public class PlayerMovment : MonoBehaviour
{
    public GameObject eq;
    [SerializeField] float movmentSpeed = 10f;
    [SerializeField] float sprintSpeed = 15f;
    [SerializeField] float jumpHeight = 5f;
    Rigidbody rb;
    bool isJumping = false;
    bool isSprinting = false;
    bool isEqVisible = false;
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
        ShowEq();
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
