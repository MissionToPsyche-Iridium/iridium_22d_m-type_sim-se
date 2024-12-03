using UnityEngine;
using UnityEngine.SceneManagement;

public class UiSceneLoader : MonoBehaviour
{
    void Start()
    {
        if (!SceneManager.GetSceneByName("roverUIscene").isLoaded)
        {
            SceneManager.LoadScene("roverUIscene", LoadSceneMode.Additive);
        }
    }
}
