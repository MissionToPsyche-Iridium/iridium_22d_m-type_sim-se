using UnityEngine;

public class CameraSync : MonoBehaviour
{
    public Transform freeLookCamera; 
    public float positionLerpSpeed = 10f; 
    public float rotationLerpSpeed = 10f; 
    public Vector3 followOffset = new Vector3(0, 2, -5); 
    public float maxFollowDistance = 10f; 

    private Vector3 targetPosition; 

    void Update()
    {
        if (freeLookCamera != null)
        {
            targetPosition = freeLookCamera.position + freeLookCamera.TransformDirection(followOffset);

            transform.position = Vector3.Lerp(transform.position, targetPosition, positionLerpSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Slerp(transform.rotation, freeLookCamera.rotation, rotationLerpSpeed * Time.deltaTime);
        }
    }
}