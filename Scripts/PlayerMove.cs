using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 20f;  
    private CharacterController myCC;

    private Vector3 inputVector;
    private Vector3 movementVector;  
    private float myGravity = -10f;   

    void Start()
    {
        myCC = GetComponent<CharacterController>();   
    }

    void Update()
    {
        GetInput();
        MovePlayer(); 
    }

    void GetInput()
    {
        inputVector = new Vector3(x: Input.GetAxisRaw("Horizontal"), y: 0f, z: Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);
        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
    }

    void MovePlayer()
    {
        myCC.Move(movementVector * Time.deltaTime);
    }
}