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
    public float activationRange = 5f;
    public float tngActivationRange = 25f;

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
        if (Input.GetKeyDown(KeyCode.E) && (IsNearSample() || IsNearTNGSample()))
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

        transform.position = rover.TransformPoint(positionOffset);
        transform.rotation = rover.rotation * Quaternion.Euler(rotationEulerAngles);
    }
    public void ActivatePOV()
    {
        isActive = true;
        timer = 0f;
        if (toolPOVBorder != null) toolPOVBorder.SetActive(true);
        if (toolCamera != null)
        {
            toolCamera.SetActive(true);

            toolCamera.transform.position = rover.TransformPoint(positionOffset);

            Vector3 frontOfRover = rover.position + rover.forward * 1.5f + Vector3.up * 1f;
            toolCamera.transform.LookAt(frontOfRover);


        }

        gameObject.SetActive(true);
        Debug.Log("Tool POV Activated");
    }
    void DeactivatePOV()
    {
        isActive = false;
        if (toolPOVBorder != null) toolPOVBorder.SetActive(false);
        if (toolCamera != null) toolCamera.SetActive(false);
        Debug.Log("Tool POV Deactivated");
    }
    private bool IsNearSample()
    {
        Collider[] hitColliders = Physics.OverlapSphere(rover.position, activationRange);

        foreach (Collider hit in hitColliders)
        {

            if (hit.CompareTag("SampleChimra") ||
                hit.CompareTag("SampleScrew") ||
                hit.CompareTag("SampleClaw"))
            {

                if (ToolCheck(hit.gameObject))
                {
                    return true;
                }
                else
                {
                    Debug.Log("ToolCheck failed.");
                }
            }
        }

        return false;
    }

    private bool IsNearTNGSample()
    {
        Collider[] hitColliders = Physics.OverlapSphere(rover.position, tngActivationRange);

        foreach (Collider hit in hitColliders)
        {
            if (hit.CompareTag("SampleTNG"))
            {

                if (ToolCheck(hit.gameObject))
                {
                    return true;
                }
                else
                {
                    Debug.Log("ToolCheck for tng failed.");
                }
            }
        }
        return false;
    }
    private bool ToolCheck(GameObject sample)
    {

        if (sample.CompareTag("SampleChimra"))
        {
            if (GameObject.Find("ChimraTool")?.activeSelf == true)
            {
                Debug.Log("ChimraTool is active.");
                return true;
            }
        }

        if (sample.CompareTag("SampleClaw"))
        {
            if (GameObject.Find("ClawTool")?.activeSelf == true)
            {
                Debug.Log("ClawTool is active.");
                return true;
            }
        }

        if (sample.CompareTag("SampleScrew"))
        {
            if (GameObject.Find("ArchScrew")?.activeSelf == true)
            {
                return true;
            }
        }

        if (sample.CompareTag("SampleTNG"))
        {
            if (GameObject.Find("TouchTool")?.activeSelf == true)
            {
                return true;
            }
        }

        return false;
    }

}