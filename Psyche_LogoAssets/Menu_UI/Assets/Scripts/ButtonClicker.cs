using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClicker : MonoBehaviour
{
    public Button menuButton;

    void Start()
    {
        if (menuButton != null)
        {
            menuButton.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogWarning("Button is not assigned.");
        }
    }

    void OnButtonClick()
    {
        Debug.Log("Button was clicked!");
        
    }
}
