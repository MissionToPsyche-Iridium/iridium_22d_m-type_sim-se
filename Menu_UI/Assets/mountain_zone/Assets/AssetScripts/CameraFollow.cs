using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float distanceFromPlayer = 10f;
    public float rotationSpeed = 5f;
    public Vector3 offset;
    public float minDistance = 5f;
    public float maxDistance = 20f;
    public float scrollSpeed = 2f;

    private float currentX = 0f;
    private float currentY = 0f;
    public float yMinLimit = -40f;
    public float yMaxLimit = 80f;

    void Start()
    {
        offset = new Vector3(0, 5, -distanceFromPlayer);
    }

    void LateUpdate()
    {
        if (player != null)
        {
            HandleMouseInput();
            HandleZoom();

            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

            Vector3 newPosition = player.position + rotation * new Vector3(0, 0, -distanceFromPlayer) + offset;

            transform.position = newPosition;
            transform.LookAt(player.position);
        }
    }

    void HandleMouseInput()
    {
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        currentY = Mathf.Clamp(currentY, yMinLimit, yMaxLimit);
    }

    void HandleZoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        distanceFromPlayer -= scrollInput * scrollSpeed;

        distanceFromPlayer = Mathf.Clamp(distanceFromPlayer, minDistance, maxDistance);
    }
}
