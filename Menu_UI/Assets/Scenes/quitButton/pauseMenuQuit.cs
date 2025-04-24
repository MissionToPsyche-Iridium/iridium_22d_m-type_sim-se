using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenuQuit : MonoBehaviour
{
    public GameObject menuPanel; 
    private bool isMenuOpen = false;
    public Button closeBtn;
    public Button quitBtn;
    public Button restartBtn;
    public Button newZoneBtn;


    void Start()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
        if (closeBtn != null)
        {
            closeBtn.onClick.AddListener(CloseMenu);
        }
        if (quitBtn != null)
        {
            quitBtn.onClick.AddListener(QuitGame);
        }
        if (restartBtn != null)
        {
            restartBtn.onClick.AddListener(ReloadScene);
        }
        if (newZoneBtn != null)
        {
            newZoneBtn.onClick.AddListener(LoadScene);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen)
            {
                CloseMenu();
            }
            else
            {
                ToggleMenu();
            }
        }
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        menuPanel.SetActive(isMenuOpen);
    }
    public void CloseMenu()
    {
        isMenuOpen = false;
        menuPanel.SetActive(false);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("3dTestScene");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

    }
}

