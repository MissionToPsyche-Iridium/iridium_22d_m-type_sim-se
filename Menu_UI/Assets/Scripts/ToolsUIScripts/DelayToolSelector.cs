using System.Collections;
using UnityEngine;

public class DelayToolSelector : MonoBehaviour
{

    public GameObject toolSelector;

    // Start is called before the first frame update
    void Start()
    {
        if(toolSelector != null) {
            toolSelector.SetActive(false);
        }

        Invoke("Delay", 6f); 
    }

    // Delay sample collection panel visibility
    void Delay()
    {
        toolSelector.SetActive(true);
    }
}