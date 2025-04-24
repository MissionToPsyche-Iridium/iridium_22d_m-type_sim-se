using UnityEngine;

public class OnCloseInstructionPanel : MonoBehaviour
{

    public GameObject sampleCollectionPanel;
    public GameObject toolSelector;
    public GameObject currentToolPanel;

    // Start is called before the first frame update
    void Start()
    {
        if(sampleCollectionPanel != null) {
            sampleCollectionPanel.SetActive(false);
        }

        if(toolSelector != null) {
            toolSelector.SetActive(false);
        }

        if(currentToolPanel != null) {
            currentToolPanel.SetActive(false);
        }
    }

    public void OnCloseInstructions()
    {
        sampleCollectionPanel.SetActive(true);
        toolSelector.SetActive(true);
        currentToolPanel.SetActive(true);
    }
}