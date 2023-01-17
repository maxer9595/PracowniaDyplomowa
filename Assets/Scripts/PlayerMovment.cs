using UnityEngine;


public class PlayerMovment : MonoBehaviour
{
    public GameObject eq;
    public WatchSlot watchslot;
    public float movmentSpeed = 10f;
    public float sprintSpeed = 15f;
    [SerializeField] float jumpHeight = 5f;
    Rigidbody rb;
    bool isJumping = false;
    [HideInInspector] public bool isEqVisible = false;
    float playerSpeed;

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
            Moving();
            Jumping();
            Sprinting();
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;

        }
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
                watchslot.BoostMenager();
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
        if (Input.GetKey(KeyCode.LeftShift) && !isJumping)
        {
            playerSpeed = sprintSpeed * watchslot.sprintBoost;
        }
        else
        {
            playerSpeed = movmentSpeed * watchslot.sprintBoost;
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
