using System.Collections;
using UnityEngine;

public class DelayInstrumentPanel : MonoBehaviour
{

    public GameObject instrumentPanel;

    // Start is called before the first frame update
    void Start()
    {
        if(instrumentPanel != null) {
            instrumentPanel.SetActive(false);
        }

        Invoke("Delay", 6f); 
    }

    // Delay sample collection panel visibility
    void Delay()
    {
        instrumentPanel.SetActive(true);
    }
}