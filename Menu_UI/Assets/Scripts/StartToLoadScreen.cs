using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartToLoadScreen : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
}
