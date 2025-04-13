using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowIncorrectToolPanel : MonoBehaviour
{

    public GameObject IncorrectToolPanel;
    public TextMeshProUGUI popUpText;

    private string message = "Use the right tool";
    // Start is called before the first frame update
    void Start()
    {
        IncorrectToolPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowPanel(float duration, string toolName)
    {
        IncorrectToolPanel.SetActive(true);
        string updatedMessage = message;

        if (toolName.Equals("TNG")) 
        {
            updatedMessage = message.Replace("Use the right tool", "Select Touch-and-Go");
        }

        if (toolName.Equals("Arch Screw")) 
        {
            updatedMessage = message.Replace("Use the right tool", "Select Archimedes' Screw");
        }

        if (toolName.Equals("Claw")) 
        {
            updatedMessage = message.Replace("Use the right tool", "Select Claw");
        }

        if (toolName.Equals("Chimra")) 
        {
            updatedMessage = message.Replace("Use the right tool", "Select Chimra");
        }

        popUpText.text = updatedMessage;
        StartCoroutine(ShowPanelCoroutine(duration));
    }
    public IEnumerator ShowPanelCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        IncorrectToolPanel.SetActive(false);
    }
}
