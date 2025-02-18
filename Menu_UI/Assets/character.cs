using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class character : MonoBehaviour
{
    private ChangeTool changeTools;
    private CharacterController characterController;
    private Animator animator;
    public float robotSpeed = 10;
    public float rotationSpeed = 1000f; // turning speed of robot
    public float gravity = -0.144f;     // gravity on 16 Psyche
    private float currentRotationAngle = 0f;
    private Vector3 velocity;
    public float interactionRange = 5f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        changeTools = GetComponent<ChangeTool>();
    }

    void Update()
    {
        ChimraInteraction();

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
    private void ChimraInteraction()
    {
        if (changeTools.chimraTool.activeSelf)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionRange);
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("SampleChimra"))
                {
                    Debug.Log("Sample rock detected: " + hitCollider.name);


                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        InteractWithRock(hitCollider.gameObject);
                    }
                }
                else
                {
                    Debug.Log("Wrong tool");
                }
            }
        }
    }

    private void InteractWithRock(GameObject rock)
    {
        Debug.Log("Interacting with: " + rock.name);

        rock.SetActive(false);

    }
}