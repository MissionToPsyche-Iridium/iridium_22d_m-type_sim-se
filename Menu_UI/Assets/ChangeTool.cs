using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTool : MonoBehaviour
{
    public GameObject chimraTool;
    public GameObject archScrew;
    public GameObject clawTool;
    public GameObject touchTool;

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
            if (chimraTool.activeSelf == false)
            {
                equipChimra();
            } else
            {
                equipClaw();
            }
        } else if (Input.GetKeyDown(KeyCode.T)) {
            if (archScrew.activeSelf == false)
            {
                equipArchScrew();
            } else
            {
                equipTouchGo();
            }
        }
    }

    private void equipTouchGo()
    {
        chimraTool.SetActive(false);
        archScrew.SetActive(false);
        clawTool.SetActive(false);
        touchTool.SetActive(true);
    }

    private void equipClaw()
    {
        chimraTool.SetActive(false);
        archScrew.SetActive(false);
        clawTool.SetActive(true);
        touchTool.SetActive(false);
    }

    public void equipChimra()
    {
        chimraTool.SetActive(true);
        archScrew.SetActive(false);
        clawTool.SetActive(false);
        touchTool.SetActive(false);
    }
    public void equipArchScrew()
    {
        chimraTool.SetActive(false);
        archScrew.SetActive(true);
        clawTool.SetActive(false);
        touchTool.SetActive(false);
    }
}