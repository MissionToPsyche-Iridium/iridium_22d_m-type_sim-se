using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController characterController;
    public float robotSpeed = 10f;
    public float rotationSpeed = 1000f;
    public float gravity = -0.144f;
    private float currentRotationAngle = 0f;
    private Vector3 velocity;

    public float interactionRange = 5f; 
    public KeyCode interactKey = KeyCode.E; 
    private SampleCounter sampleCounter;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        sampleCounter = FindObjectOfType<SampleCounter>();
    }

    void Update()
    {
        HandleMovement();
        HandleInteraction();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0)
        {
            currentRotationAngle += horizontal * rotationSpeed * Time.deltaTime;
            currentRotationAngle = Mathf.Repeat(currentRotationAngle, 360);
            transform.rotation = Quaternion.Euler(0, currentRotationAngle, 0);
        }

        Vector3 move = transform.forward * vertical;

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

    private void HandleInteraction()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionRange);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("SampleRock"))
            {
                Debug.Log("Sample rock detected: " + hitCollider.name);

                if (Input.GetKeyDown(interactKey))
                {
                    InteractWithRock(hitCollider.gameObject);
                }
            }
        }
    }

    private void InteractWithRock(GameObject rock)
    {
        Debug.Log("Interacting with: " + rock.name);

        rock.SetActive(false);

        if (sampleCounter != null)
        {
            sampleCounter.AddSample();
        }
    }
}
