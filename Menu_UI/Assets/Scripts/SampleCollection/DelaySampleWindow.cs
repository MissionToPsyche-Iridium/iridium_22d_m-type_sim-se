using System.Collections;
using UnityEngine;

public class DelaySampleWindow : MonoBehaviour
{

    public GameObject samplePanel;

    // Start is called before the first frame update
    void Start()
    {
        if(samplePanel != null) {
            samplePanel.SetActive(false);
        }

        Invoke("Delay", 7f); 
    }

    // Delay sample collection panel visibility
    void Delay()
    {
        samplePanel.SetActive(true);
    }
}
