using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoMain : MonoBehaviour
{
    public string zoneSceneName = "Menu 3D";

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
        SceneManager.LoadScene("Menu 3D");
    }
}