using System.Collections;
using UnityEngine;

public class DelayZoneCompletePanel : MonoBehaviour
{

    public GameObject zoneCompletePanel;

    // Start is called before the first frame update
    void Start()
    {
        if(zoneCompletePanel != null) {
            zoneCompletePanel.SetActive(false);
        }

        Invoke("Delay", 3f); 
    }

    // Delay sample collection panel visibility
    void Delay()
    {
        zoneCompletePanel.SetActive(true);
    }
}