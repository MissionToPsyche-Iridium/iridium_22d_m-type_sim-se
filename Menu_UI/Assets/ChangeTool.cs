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
    //The current item equipped, to be called for animation purposes
    private GameObject currentTool;
    // Start is called before the first frame update
    void Start()
    {
        equipChimra();
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
        currentTool = touchTool;
    }

    private void equipClaw()
    {
        chimraTool.SetActive(false);
        archScrew.SetActive(false);
        clawTool.SetActive(true);
        touchTool.SetActive(false);
        currentTool = clawTool;
    }

    public void equipChimra()
    {
        chimraTool.SetActive(true);
        archScrew.SetActive(false);
        clawTool.SetActive(false);
        touchTool.SetActive(false);
        currentTool = chimraTool;
    }
    public void equipArchScrew()
    {
        chimraTool.SetActive(false);
        archScrew.SetActive(true);
        clawTool.SetActive(false);
        touchTool.SetActive(false);
        currentTool = archScrew;
    }
    public GameObject getCurrentTool()
    {
        return currentTool;
    }
}