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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
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

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

