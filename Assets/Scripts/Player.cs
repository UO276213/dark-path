using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    
    public CharacterController characterController;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * z + transform.right * x;


        // If player gives speeds then we update player and camera position
        if (move != Vector3.zero)
        {
            // Calculate the movement
            characterController.Move(move * (Time.deltaTime * speed));
        }
    }
    
}