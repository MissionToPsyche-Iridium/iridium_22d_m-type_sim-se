using UnityEngine;

public class RotatePsyche : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public Vector3 rotationAxis = new Vector3(1f, 1f, 0f); 
    private bool isRotating = true;

    public GameObject cameraFollow; 
    private bool isFollowEnabled = false; 

    void Start()
    {
        rotationAxis = rotationAxis.normalized;
    }

    void Update()
    {
        if (isRotating)
        {
            RotateObject();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleRotation();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleCameraFollow();
        }

        if (isFollowEnabled && cameraFollow != null)
        {
            AlignCameraWithRotation();
        }
    }

    private void RotateObject()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }

    public void ToggleRotation()
    {
        isRotating = !isRotating;
    }

    public void SetRotationSpeed(float newSpeed)
    {
        rotationSpeed = newSpeed;
    }

    public void SetRotationAxis(Vector3 newAxis)
    {
        rotationAxis = newAxis.normalized;
    }

    public void StopRotation()
    {
        isRotating = false;
        Debug.Log("Rotation stopped.");
    }

    public void StartRotation()
    {
        isRotating = true;
        Debug.Log("Rotation started.");
    }

    public void ToggleCameraFollow()
    {
        isFollowEnabled = !isFollowEnabled;
        Debug.Log(isFollowEnabled ? "Camera follow enabled." : "Camera follow disabled.");
    }

    private void AlignCameraWithRotation()
    {
        cameraFollow.transform.rotation = transform.rotation;
    }
}
