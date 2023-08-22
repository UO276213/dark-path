using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class MazeBlock : MonoBehaviour
{

    public GameObject mazeBlock;
    

    // void OnCollisionEnter(Collision other)
    // {
    //     Debug.Log("Hola");
    //     if (other.gameObject.CompareTag("MazeCube"))
    //     {
    //         Destroy(other.gameObject);
    //     }
    // }
}
