using UnityEngine;

public class CameraIntro : MonoBehaviour
{
    public OrbitalCamera orbitalCamera;
    public Transform asteroid;
    public float initialDistance = 100f;
    public float zoomSpeed = 5f;
    public float rotationSpeed = 20f;
    public float rotationDuration = 5f;

    private Vector3 defaultCameraPosition;
    private bool isAnimating = true;
    private float elapsedRotationTime = 0f;

    void Start()
    {
        orbitalCamera.enabled = false;
        defaultCameraPosition = orbitalCamera.transform.position;
        Vector3 directionToAsteroid = (orbitalCamera.transform.position - asteroid.position).normalized;
        orbitalCamera.transform.position = asteroid.position + directionToAsteroid * initialDistance;
    }

    void Update()
    {
        if (isAnimating)
        {
            AnimateCamera();
        }
    }

    private void AnimateCamera()
    {
        orbitalCamera.transform.position = Vector3.Lerp(orbitalCamera.transform.position, defaultCameraPosition, Time.deltaTime * zoomSpeed);

        if (elapsedRotationTime < rotationDuration)
        {
            elapsedRotationTime += Time.deltaTime;
            orbitalCamera.transform.RotateAround(asteroid.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(orbitalCamera.transform.position, defaultCameraPosition) < 0.1f && elapsedRotationTime >= rotationDuration)
        {
            isAnimating = false;
            EnablePlayerControl();
        }
    }
    private void EnablePlayerControl()
    {
        orbitalCamera.enabled = true;
    }
}
