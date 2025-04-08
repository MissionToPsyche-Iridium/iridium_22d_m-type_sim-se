using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepExploring : MonoBehaviour
{
    public GameObject ToolSelector;
    public GameObject ZoneComplete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void enable() {
        ToolSelector.SetActive(true);
        ZoneComplete.SetActive(false);
    }
}
