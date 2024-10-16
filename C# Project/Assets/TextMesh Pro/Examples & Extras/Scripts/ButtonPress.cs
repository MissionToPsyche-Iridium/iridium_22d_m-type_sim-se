using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour
{
   
    public void NextScene() {
        SceneManager.LoadScene("AfterButton");
    }

}
