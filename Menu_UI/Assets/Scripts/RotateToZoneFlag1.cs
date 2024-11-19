using UnityEngine;

public class RotateToZoneFlag1 : MonoBehaviour
{
    public GameObject zoneFlag1; 
    public Transform cameraParent; 
    public float rotationSpeed = 5f; 
    public OrbitalCamera orbitalCamera;

    private bool isRotating = false;
    private Quaternion targetRotation;

    void Update()
    {
        if (isRotating)
        {
            cameraParent.rotation = Quaternion.Slerp(
                cameraParent.rotation,
                targetRotation,
                Time.deltaTime * rotationSpeed
            );

            if (Quaternion.Angle(cameraParent.rotation, targetRotation) < 0.1f)
            {
                isRotating = false;

                if (orbitalCamera != null)
                {
                    orbitalCamera.enabled = true;
                }
            }
        }
    }

    public void OnButtonClick()
    {
        if (zoneFlag1 != null && cameraParent != null)
        {
            if (orbitalCamera != null)
            {
                orbitalCamera.enabled = false;
            }

            Vector3 direction = zoneFlag1.transform.position - cameraParent.position;

            targetRotation = Quaternion.LookRotation(direction);

            isRotating = true;
        }
        else
        {
            Debug.LogWarning("zoneFlag1 is not assigned.");
        }
    }
}
