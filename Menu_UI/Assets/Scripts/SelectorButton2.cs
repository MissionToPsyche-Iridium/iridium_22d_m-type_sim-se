using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorButton2 : MonoBehaviour
{
    public string zoneSceneName = "Inner_Crater";

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
        SceneManager.LoadScene("Inner_Crater");
    }
}