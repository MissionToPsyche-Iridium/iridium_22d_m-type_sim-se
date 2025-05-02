using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quitButton : MonoBehaviour
{
    public GameObject menuPanel; 
    private bool isMenuOpen = false;
    public Button closeBtn;
    public Button quitBtn;
    public Button respawnBtn;
    public Button newZoneBtn;
    public GameObject toolUI;
    public GameObject sampleCollectPanel;


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
        if (respawnBtn != null)
        {
            respawnBtn.onClick.AddListener(ReloadScene);
        }
        if (newZoneBtn != null)
        {
            newZoneBtn.onClick.AddListener(LoadScene);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
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
        sampleCollectPanel.SetActive(false);
        toolUI.SetActive(false);
    }
    public void CloseMenu()
    {
        isMenuOpen = false;
        menuPanel.SetActive(false);
        sampleCollectPanel.SetActive(true);
        toolUI.SetActive(true);
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

