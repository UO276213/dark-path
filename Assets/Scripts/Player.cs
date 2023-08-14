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
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            _characterController.SimpleMove(Vector3.forward * speed);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            _characterController.SimpleMove(Vector3.right * speed);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            _characterController.SimpleMove(Vector3.back * speed);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            _characterController.SimpleMove(Vector3.left * speed);
    }
}