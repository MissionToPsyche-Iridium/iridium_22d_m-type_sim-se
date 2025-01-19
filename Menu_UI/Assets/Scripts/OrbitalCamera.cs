using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 100f;
    public float distance = 50f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;

        transform.position = target.position + offset.normalized * distance;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0)
        {
            transform.RotateAround(target.position, Vector3.up, horizontal * rotationSpeed * Time.deltaTime);
        }

        if (vertical != 0)
        {
            transform.RotateAround(target.position, transform.right, -vertical * rotationSpeed * Time.deltaTime);
        }

        offset = transform.position - target.position;

        transform.LookAt(target);
    }
}