using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    [SerializeField] float sens = 250f;
    public Transform Camera;
    float cameraRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;
        float x = Input.GetAxis("Mouse X") * sens * Time.deltaTime;

        transform.Rotate(Vector3.up * x);

        cameraRotation -= y;
        cameraRotation = Mathf.Clamp(cameraRotation, -90f, 90f);
        Camera.localEulerAngles = Vector3.right * cameraRotation;


    }
}
