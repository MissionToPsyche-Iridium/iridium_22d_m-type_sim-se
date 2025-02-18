using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    private Slider loadingBar; 
    public float loadingSpeed = 0.5f; 

    private float progress = 0f; 

    void Start()
    {
        loadingBar = GetComponent<Slider>();

        if (loadingBar != null)
        {
            loadingBar.value = 0f;
            StartCoroutine(LoadingProcess());
        }
    }

    System.Collections.IEnumerator LoadingProcess()
    {
        while (loadingBar.value < loadingBar.maxValue)
        {
            loadingBar.value += loadingSpeed * Time.deltaTime;
            yield return null; 
        }
        SceneManager.LoadScene("3dTestScene");
    }
}
