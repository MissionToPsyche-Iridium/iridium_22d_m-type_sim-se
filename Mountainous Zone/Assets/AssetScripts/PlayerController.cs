using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;        
    public float rotationSpeed = 5f;    
    public LayerMask groundLayer;       
    public Transform cameraTransform;   

    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 groundNormal;       

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;  
        }
    }

    void Update()
    {
        CheckGroundStatus();
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical");      

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movementInput = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized;

        Vector3 movement = Vector3.ProjectOnPlane(movementInput, groundNormal) * moveSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);

        if (movement.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    void CheckGroundStatus()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f, groundLayer))
        {
            isGrounded = true;
            groundNormal = hit.normal;  
        }
        else
        {
            isGrounded = false;
            groundNormal = Vector3.up;  
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
