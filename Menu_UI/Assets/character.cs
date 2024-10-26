using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public CharacterController characterController;
    public Rigidbody rigidBody;
    public float speed = 5;
    private float jumpPower = 1;
    private float jumpSpeed;
    private const int MIN_SPEED = 1;
    private const int MAX_SPEED = 30;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        // Move the character
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), jumpSpeed, Input.GetAxis("Vertical"));
        if (!characterController.isGrounded)
        {
            move += Physics.gravity;
            if (jumpSpeed > 0)
            {
                jumpSpeed += Physics.gravity.y * Time.deltaTime;
            }
            else if (jumpSpeed < 0)
            {
                jumpSpeed = 0;
            }
        }
        // Increase the character's speed
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed++;
            if (speed > MAX_SPEED)
            {
                speed = MAX_SPEED;
            }
            Debug.Log("Speed increased to " + speed);
        }
        //Decrease the character's speed
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed--;
            if (speed < MIN_SPEED)
            {
                speed = MIN_SPEED;
            }
            Debug.Log("Speed decreased to " + speed);
        }
        
        // Make the character jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space bar pressed.");
            if (characterController.isGrounded)
            {
                jumpSpeed = jumpPower * speed;
            }
        }
        Debug.Log("Movement is " + move);
        characterController.Move(move * Time.deltaTime * speed);
    }
}