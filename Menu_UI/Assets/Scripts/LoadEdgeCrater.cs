using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEdgeCrater : MonoBehaviour
{
    public bool loadOnStart = false;

    void Start()
    {
        if (loadOnStart)
        {
            LoadScene();
        }
    }

    void OnMouseDown()
    {
        LoadScene();
    }

    public void LoadScene()
    {
        string sceneName = "Edge_Of_Crater";
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            Debug.Log($"Scene '{sceneName}' is loading.");
        }
        else
        {
            Debug.LogError($"Scene '{sceneName}' cannot be loaded. Make sure it is added to the Build Settings.");
        }
    }
}

