using UnityEngine;

public class OpenPanelsOnClose : MonoBehaviour
{

    public GameObject instrumentPanel;
    public GameObject currentToolPanel;
    public GameObject sampleWindow;

    void Start()
    {
        if(instrumentPanel != null) {
            instrumentPanel.SetActive(false);
        }

    }

    public void OnCloseInstructionOpenPanels()
    {
        instrumentPanel.SetActive(true);
        currentToolPanel.SetActive(true);
        sampleWindow.SetActive(true);
    }
}