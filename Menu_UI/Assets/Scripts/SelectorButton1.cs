using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorButton1 : MonoBehaviour
{
    public string zoneSceneName = "Edge_Of_Crater";

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
