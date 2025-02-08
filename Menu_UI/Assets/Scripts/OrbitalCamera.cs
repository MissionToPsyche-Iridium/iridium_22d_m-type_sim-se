using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 100f;
    public float distance = 50f;
    public float startDistance = 1000f;
    public float zoomSpeed = 2f;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;

        transform.position = target.position + offset.normalized * distance;
        StartCoroutine(ZoomToAsteroid());
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
    IEnumerator ZoomToAsteroid()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = target.position + offset.normalized * startDistance; 
        Vector3 endPosition = target.position + offset.normalized * distance;       

        while (elapsedTime < zoomSpeed)
        {
            float t = elapsedTime / zoomSpeed;

            transform.position = Vector3.Lerp(startPosition, endPosition, t);

            transform.LookAt(target);

            elapsedTime += Time.deltaTime;
            yield return null; 
        }

        transform.position = endPosition;
    }
}