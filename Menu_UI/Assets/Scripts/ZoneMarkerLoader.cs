using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneMarkerLoader : MonoBehaviour
{
    // The name of the scene to load when this sphere is clicked
    private string zoneSceneName = "AsteroidMountain";

    void OnMouseDown()
    {
        if (!string.IsNullOrEmpty(zoneSceneName))
        {
            SceneManager.LoadScene(zoneSceneName, LoadSceneMode.Single);
            Debug.Log($"Loading scene: {zoneSceneName}");
        }
        else
        {
            Debug.LogError("Zone scene name is not set.");
        }
    }
}

