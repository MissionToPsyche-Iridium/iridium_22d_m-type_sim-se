using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAsteroidMarkers : MonoBehaviour
{
    public GameObject sphereContainer; 

    void Start()
    {
        if (sphereContainer != null)
        {
            sphereContainer.SetActive(true); 
            Debug.Log("Asteroid markers loaded on start.");
        }
        else
        {
            Debug.LogError("Marker not assigned.");
        }
    }
}
