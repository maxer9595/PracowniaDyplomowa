using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    [SerializeField] float sens = 250f;
    public Transform Camera;
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

        Vector3 rotate = new Vector3(y * sens / 250, 0, 0);
        Camera.localEulerAngles -= rotate;

    }
}
