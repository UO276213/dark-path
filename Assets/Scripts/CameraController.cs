using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerTransform;

    public float sensX = 100f;
    public float sensY = 100f;

    private float xRotation;
    private float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensX * Time.deltaTime ;
        float mouseY = Input.GetAxis("Mouse Y") * sensY * Time.deltaTime ;
        
        // yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Math.Clamp(xRotation, -90, 90);
        
        
        playerTransform.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0,  0);
    }
}
