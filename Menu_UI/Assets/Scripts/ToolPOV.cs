using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPOV : MonoBehaviour
{
    public Transform rover;

    public Vector3 positionOffset = Vector3.zero;

    public Vector3 rotationEulerAngles = Vector3.zero;

    void LateUpdate()
    {
        transform.position = rover.TransformPoint(positionOffset);

        transform.rotation = rover.rotation * Quaternion.Euler(rotationEulerAngles);
    }
}
