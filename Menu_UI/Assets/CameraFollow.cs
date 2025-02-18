using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform MainRobot;
    public Vector3 offset = new Vector3(0, 5, -10);  // follow position
    public float positionSmoothSpeed = 0.125f;  // camera speed
    public float rotationSmoothSpeed = 0.5f; 

    private void LateUpdate()
    {
        if (MainRobot != null)
        {
            Vector3 desiredPosition = MainRobot.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, positionSmoothSpeed);
            Quaternion desiredRotation = Quaternion.Euler(0, MainRobot.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothSpeed * Time.deltaTime);
        }
    }
}
