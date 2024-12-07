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

            direction = -direction.normalized;

            targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            Debug.Log($"Flipped Direction: {direction}");
            Debug.Log($"Target Rotation (Euler): {targetRotation.eulerAngles}");

            isRotating = true;
        }
    }

}
