using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public int MIN_DISTANCE = 5;
    public int MAX_DISTANCE = 30;
    public float CAMERA_CHANGE = 1f;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    CinemachineComponentBase componentBase;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Debug.Log("- pressed.");
            if (componentBase == null)
            {
                componentBase = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
            }
            if (componentBase is Cinemachine3rdPersonFollow)
            {
                (componentBase as Cinemachine3rdPersonFollow).CameraDistance -= CAMERA_CHANGE;
                if ((componentBase as Cinemachine3rdPersonFollow).CameraDistance < MIN_DISTANCE)
                {
                    (componentBase as Cinemachine3rdPersonFollow).CameraDistance = MIN_DISTANCE;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Debug.Log("+ pressed.");
            if (componentBase == null)
            {
                componentBase = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
            }
            if (componentBase is Cinemachine3rdPersonFollow)
            {
                (componentBase as Cinemachine3rdPersonFollow).CameraDistance += CAMERA_CHANGE;
                if ((componentBase as Cinemachine3rdPersonFollow).CameraDistance > MAX_DISTANCE)
                {
                    (componentBase as Cinemachine3rdPersonFollow).CameraDistance = MAX_DISTANCE;
                }
            }
        }
    }
}