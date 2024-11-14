using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 20f;
    private CharacterController myCC;
    public Animator camAnim;
    private bool isWalking;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float myGravity = -9.81f;
    private float verticalVelocity;

    void Start()
    {
        myCC = GetComponent<CharacterController>();   
    }

    void Update()
    {
        GetInput();
        ApplyGravity();
        MovePlayer(); 
        CheckForHeadBob();
        UpdateCameraAnimation();
    }

    void GetInput()
    {
        inputVector = new Vector3(x: Input.GetAxisRaw("Horizontal"), y: 0f, z: Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);
    }

    void ApplyGravity()
    {
        if (myCC.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity += myGravity * Time.deltaTime;
        }

        movementVector = inputVector * playerSpeed;
        movementVector.y = verticalVelocity;
    }

    void MovePlayer()
    {
        myCC.Move(movementVector * Time.deltaTime);
    }

    void CheckForHeadBob()
    {
        if (myCC.velocity.magnitude > 0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false; 
        }
    }

    void UpdateCameraAnimation()
    {
        camAnim.SetBool("isWalking", isWalking);
    }
}
