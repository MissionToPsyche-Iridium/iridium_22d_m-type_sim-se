using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour 
{
    public void QuitGame() 
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void LoadCredits() {
        SceneManager.LoadScene("Credits");
    }
}