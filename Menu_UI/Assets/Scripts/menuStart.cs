using UnityEngine;
using UnityEngine.SceneManagement;

public class menuStart : MonoBehaviour
{
    public void LoadZoneSelector()
    {
        SceneManager.LoadScene("3DTestScene");
    }
}