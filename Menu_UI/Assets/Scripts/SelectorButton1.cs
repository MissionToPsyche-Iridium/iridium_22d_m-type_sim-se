using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorButton1 : MonoBehaviour
{
    public string zoneSceneName = "Edge_Of_Crater";

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
        SceneManager.LoadScene("Edge_Of_Crater");
    }
}
    