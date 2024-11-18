using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTool : MonoBehaviour
{
    public GameObject chimraTool;
    public GameObject archScrew;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //testing keybinds
        if (Input.GetKeyDown(KeyCode.C))
        {
            equipChimra();
        } else if (Input.GetKeyDown(KeyCode.T)) {
            equipArchScrew();
        }
    }
    public void equipChimra()
    {
        chimraTool.SetActive(true);
        archScrew.SetActive(false);
    }
    public void equipArchScrew()
    {
        chimraTool.SetActive(false);
        archScrew.SetActive(true);
    }
}