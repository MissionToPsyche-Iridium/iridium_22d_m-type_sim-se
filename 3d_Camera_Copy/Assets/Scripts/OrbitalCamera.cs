using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    public Transform target; // The object to rotate around
    public float rotationSpeed = 100f; // Speed of rotation
    public float distance = 50f; // Distance from the target

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
        // Set the camera's initial position
        transform.position = target.position + offset.normalized * distance;
    }

    void Update()
    {
        // Get input from WASD keys
        float horizontal = Input.GetAxis("Horizontal"); // A/D keys for left-right rotation
        float vertical = Input.GetAxis("Vertical"); // W/S keys for up-down rotation

        // Horizontal rotation (around Y-axis)
        if (horizontal != 0)
        {
            transform.RotateAround(target.position, Vector3.up, horizontal * rotationSpeed * Time.deltaTime);
        }

        // Vertical rotation (around camera's right axis)
        if (vertical != 0)
        {
            // Rotate around the camera's right axis (transform.right) for vertical movement
            transform.RotateAround(target.position, transform.right, -vertical * rotationSpeed * Time.deltaTime);
        }

        offset = transform.position - target.position;

        transform.LookAt(target);
    }
}
