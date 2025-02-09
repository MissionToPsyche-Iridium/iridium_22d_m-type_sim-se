using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadTransition : MonoBehaviour
{
    public string scene;

    public void LoadSceneTransition()
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
