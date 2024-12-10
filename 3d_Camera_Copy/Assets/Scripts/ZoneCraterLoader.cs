using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneCraterLoader : MonoBehaviour
{
    public string zoneSceneName = "CraterZone";  // Name of the scene to load

    void OnMouseDown()
    {
        LoadZone();
    }

    public void LoadZone()
    {
        if (!string.IsNullOrEmpty(zoneSceneName))
        {
            SceneManager.LoadScene(zoneSceneName, LoadSceneMode.Single);
            Debug.Log($"Scene '{zoneSceneName}' loaded.");
        }
        else
        {
            Debug.LogError("Zone scene name is not set.");
        }
    }
}

