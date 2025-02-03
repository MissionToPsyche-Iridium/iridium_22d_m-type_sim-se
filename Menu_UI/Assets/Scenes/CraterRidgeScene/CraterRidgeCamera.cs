using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CraterRidgeCamera : MonoBehaviour {

private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        if (virtualCamera != null)
        {
            virtualCamera.transform.rotation = Quaternion.Euler(30f, 180f, 0f); 
        }
    }

    void Update()
    {
        virtualCamera.m_Lens.FieldOfView = 60f;
    }
}
