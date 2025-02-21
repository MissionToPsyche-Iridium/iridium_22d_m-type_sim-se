using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorButton4 : MonoBehaviour
{
    public string zoneSceneName = "FlatSurface";

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
        SceneManager.LoadScene("FlatSurface");
    }
}