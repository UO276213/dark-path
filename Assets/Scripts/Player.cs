using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController _characterController;

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3? newSpeed = Vector3.zero;
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            newSpeed += Vector3.forward * speed;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            newSpeed += Vector3.right * speed;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            newSpeed += Vector3.back * speed;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            newSpeed += Vector3.left * speed;

        // If player gives speeds then we update player and camera position
        if (newSpeed != Vector3.zero)
        {
            // Calculate the movement
            Vector3 prevPos = transform.position;
            _characterController.SimpleMove(newSpeed.Value);
            Vector3 afterPos = transform.position;

            // Apply also the movement to the camera
            Camera.main.transform.position += (afterPos - prevPos);
        }

    }
}