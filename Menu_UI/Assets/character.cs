using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    private CharacterController characterController;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed++;
            Debug.Log("Speed increased to " + speed);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed--;
            Debug.Log("Speed decreased to " + speed);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space bar pressed.");
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (characterController.isGrounded)
            {
                move -= Physics.gravity;
            }
            characterController.Move(move * Time.deltaTime * speed);
        }
        else
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (!characterController.isGrounded)
            {
                move += Physics.gravity;
            }
            characterController.Move(move * Time.deltaTime * speed);
        }
    }
}