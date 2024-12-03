using UnityEngine;

public class RotateToZoneFlag3 : MonoBehaviour
{
    public GameObject zoneFlag3;
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
        if (zoneFlag3 != null && cameraParent != null)
        {
            if (orbitalCamera != null)
            {
                orbitalCamera.enabled = false;
            }

            Vector3 direction = zoneFlag3.transform.position - cameraParent.position;
            direction = -direction.normalized;
            targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            isRotating = true;
        }
    }
}
