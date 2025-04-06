using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPOV : MonoBehaviour
{
    public Transform rover;
    public Vector3 positionOffset = Vector3.zero;
    public Vector3 rotationEulerAngles = Vector3.zero;

    public float activeDuration = 3f;

    private bool isActive = false;
    private float timer = 0f;

    void Start()
    {
        enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivatePOV();
        }

        if (isActive)
        {
            timer += Time.deltaTime;

            if (timer >= activeDuration)
            {
                DeactivatePOV();
            }
        }
    }

    void LateUpdate()
    {
        if (!isActive) return;

        transform.position = rover.TransformPoint(positionOffset);
        transform.rotation = rover.rotation * Quaternion.Euler(rotationEulerAngles);
    }
    void ActivatePOV()
    {
        isActive = true;
        timer = 0f;
        enabled = true;
    }
    void DeactivatePOV()
    {
        isActive = false;
        enabled = false;
    }
}
