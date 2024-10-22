using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;               // Reference to the player's transform
    public float distanceFromPlayer = 10f; // Default distance from the player
    public float rotationSpeed = 5f;       // Speed of camera rotation
    public Vector3 offset;                 // Optional initial offset
    public float minDistance = 5f;         // Minimum zoom distance
    public float maxDistance = 20f;        // Maximum zoom distance
    public float scrollSpeed = 2f;         // Speed of zooming with the scroll wheel

    private float currentX = 0f;           // Horizontal rotation input
    private float currentY = 0f;           // Vertical rotation input
    public float yMinLimit = -40f;         // Limit for looking down
    public float yMaxLimit = 80f;          // Limit for looking up

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
