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
    
    private GameObject currentTool;

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
            }
            else
            {
                equipClaw();
            }
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            if (archScrew.activeSelf == false)
            {
                equipArchScrew();
            }
            else
            {
                equipTouchGo();
            }
        }
    }
    public void equipTouchGo()
    {
        unequipAll();
        touchTool.SetActive(true);
        currentTool = touchTool;
    }

    public void equipClaw()
    {
        unequipAll();
        clawTool.SetActive(true);
        currentTool = clawTool;
    }

    public void equipChimra()
    {
        unequipAll();
        chimraTool.SetActive(true);
        currentTool = chimraTool;
    }
    public void equipArchScrew()
    {
        unequipAll();
        archScrew.SetActive(true);
        currentTool = archScrew;
    }
    private void unequipAll()
    {
        chimraTool.SetActive(false);
        archScrew.SetActive(false);
        clawTool.SetActive(false);
        touchTool.SetActive(false);
    }
    public GameObject getCurrentTool()
    {
        return currentTool;
    }
}