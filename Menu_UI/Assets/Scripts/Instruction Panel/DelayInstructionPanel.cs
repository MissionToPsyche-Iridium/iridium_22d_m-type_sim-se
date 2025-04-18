using UnityEngine;

public class DelayInstructionPanel : MonoBehaviour
{

    public GameObject inPanel;
    public GameObject inBorder;

    // Start is called before the first frame update
    void Start()
    {
        if(inPanel != null) {
            inPanel.SetActive(false);
        }

        if(inBorder != null) {
            inBorder.SetActive(false);
        }

        Invoke("Delay", 6f); 
    }

    // Delay sample collection panel visibility
    void Delay()
    {
        inPanel.SetActive(true);
        inBorder.SetActive(true);
    }
}