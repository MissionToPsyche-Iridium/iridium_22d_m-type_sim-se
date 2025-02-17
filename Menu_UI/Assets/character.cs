using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    public float robotSpeed = 5; //originally 10
    public float rotationSpeed = 1000f; // turning speed of robot
    public float gravity = -9.81f; // pysche's actual gravity is -0.144f
    private float currentRotationAngle = 0f;
    private Vector3 velocity;     

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // WASD movements
        float horizontal = Input.GetAxis("Horizontal");  // left and right arrow keys or A/D
        float vertical = Input.GetAxis("Vertical");     // forward and arrow keys or W/S

        //Debug.Log(vertical);
        if (horizontal != 0)
        {
            animator.SetFloat("Horizontal", horizontal * robotSpeed);
            currentRotationAngle += horizontal * rotationSpeed * Time.deltaTime;
            currentRotationAngle = Mathf.Repeat(currentRotationAngle, 360);
            transform.rotation = Quaternion.Euler(0, currentRotationAngle, 0);
            animator.SetFloat("Horizontal", horizontal * robotSpeed);
        }

        animator.SetFloat("Vertical", vertical * robotSpeed);
        Vector3 move = transform.forward * vertical;  // forward 

        if (!characterController.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = -2f;
        }

        characterController.Move(move * robotSpeed * Time.deltaTime + velocity * Time.deltaTime);
    }
}