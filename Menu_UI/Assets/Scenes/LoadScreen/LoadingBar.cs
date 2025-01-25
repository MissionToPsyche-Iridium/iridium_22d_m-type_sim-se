using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Slider loadingBar; 
    public float loadingSpeed = 0.5f; 

    private float progress = 0f; 

    void Start()
    {
        if (loadingBar != null)
        {
            loadingBar.value = 0f;
        }
    }

    void Update()
    {
        if (loadingBar != null && loadingBar.value < progress)
        {
            loadingBar.value += loadingSpeed * Time.deltaTime;
        }
    }

    public void SetProgress(float progress)
    {
        progress = Mathf.Clamp(progress, 0f, 1f);
    }
}
