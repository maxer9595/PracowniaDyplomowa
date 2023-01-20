using UnityEngine;


public class PlayerMovment : MonoBehaviour
{
    public GameObject eq;
    public WatchSlot watchslot;
    public float movmentSpeed = 10f;
    public float sprintSpeed = 15f;
    Rigidbody rb;
    [HideInInspector] public bool isEqVisible = false;
    float playerSpeed;

    public CharacterController PlayerController;

    float gravity = -15;
    float jumpHeight = 1.2f;

    public Transform floorCheck;
    public float distanceFromFloor = 0.4f;
    public LayerMask floorLayer;
    Vector3 velocity;
    bool isOnFloor;

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
            MovmentAndJumping();
            Sprinting();
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;

        }
        ShowEq();
    }

    private void MovmentAndJumping()
    {
        isOnFloor = Physics.CheckSphere(floorCheck.position, distanceFromFloor, floorLayer);

        if (isOnFloor && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        PlayerController.Move(move * playerSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        PlayerController.Move(velocity * Time.deltaTime);
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
        if (Input.GetKey(KeyCode.LeftShift) && isOnFloor)
        {
            playerSpeed = sprintSpeed * watchslot.sprintBoost;
        }
        else
        {
            playerSpeed = movmentSpeed * watchslot.sprintBoost;
        }
    }
}
