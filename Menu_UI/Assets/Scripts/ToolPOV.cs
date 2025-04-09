using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPOV : MonoBehaviour
{
    public Transform rover;
    public GameObject toolPOVBorder;
    public GameObject toolCamera;
    public Vector3 positionOffset = Vector3.zero;
    public Vector3 rotationEulerAngles = Vector3.zero;

    public float activeDuration = 3f;

    private bool isActive = false;
    private float timer = 0f;

    void Start()
    {
        gameObject.SetActive(true);
        if (toolPOVBorder != null) toolPOVBorder.SetActive(false);
        if (toolCamera != null) toolCamera.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivatePOV();
            Debug.Log("E key pressed!");
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
    }