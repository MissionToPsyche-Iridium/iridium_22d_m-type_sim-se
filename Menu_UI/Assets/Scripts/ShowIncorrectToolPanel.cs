using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowIncorrectToolPanel : MonoBehaviour
{

    GameObject IncorrectToolPanel;
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
        string updatedMessage = message.Replace("right", toolName);
        popUpText.text = updatedMessage;
        StartCoroutine(ShowPanelCoroutine(duration));
    }
    public IEnumerator ShowPanelCoroutine(float duration)
    {
        IncorrectToolPanel.SetActive(true);
        yield return new WaitForSeconds(duration);
        IncorrectToolPanel.SetActive(false);
    }
}
