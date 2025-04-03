using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadScreenScene(string sceneLoad)
    {
        sceneName = sceneLoad;
        SceneManager.LoadScene("LoadingScreen");
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("Menu 3D");
    }

    public void LoadTitleCard() {
        SceneManager.LoadScene("Title Card");
    }
}
