using System.Collections;
using UnityEngine;

public class DelayCurrentToolPanel : MonoBehaviour
{

    public GameObject currentToolPanel;

    // Start is called before the first frame update
    void Start()
    {
        if(currentToolPanel != null) {
            currentToolPanel.SetActive(false);
        }

        Invoke("Delay", 6f); 
    }

    // Delay sample collection panel visibility
    void Delay()
    {
        currentToolPanel.SetActive(true);
    }
}