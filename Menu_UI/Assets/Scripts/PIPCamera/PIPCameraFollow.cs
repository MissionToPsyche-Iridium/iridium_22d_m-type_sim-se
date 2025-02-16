using UnityEngine;

public class FreeC : MonoBehaviour
{
    public Transform cinemachineCamera;  

    void Update()
    {
        if (cinemachineCamera != null)
        {
            transform.position = cinemachineCamera.position;
            transform.rotation = cinemachineCamera.rotation;
        }
    }
}
