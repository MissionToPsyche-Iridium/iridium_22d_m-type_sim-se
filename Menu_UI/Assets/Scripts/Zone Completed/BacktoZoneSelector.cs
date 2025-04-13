using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoZoneSelector : MonoBehaviour
{
    public string zoneSceneName = "3dTestScene";

    void OnMouseDown()
    {
        LoadLoadingScreen();
    }

    public void LoadLoadingScreen()
    {
        SceneManager.LoadScene("LoadingScreen");
        //here
    }
    public void NextScene()
    {
        SceneManager.LoadScene("3dTestScene");
    }
}