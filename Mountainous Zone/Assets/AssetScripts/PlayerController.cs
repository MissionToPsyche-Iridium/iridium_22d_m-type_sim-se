using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;      // Speed of the player movement
    public float rotationSpeed = 200f;  // Rotation speed
    public LayerMask groundLayer;     // Layer to check for ground detection

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Freeze rotation on X and Z axes to prevent tipping over
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        MovePlayer();
        CheckGroundStatus();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");  // A/D or left/right arrow
        float moveVertical = Input.GetAxis("Vertical");      // W/S or up/down arrow

        // Create movement vector in the direction the player is facing
        Vector3 movement = transform.TransformDirection(new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * moveSpeed);

        // Maintain horizontal movement velocity while applying gravity
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Rotate player with input
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            Quaternion rotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }

    void CheckGroundStatus()
    {
        // Cast a ray downwards from the player's position to check if grounded
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
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
