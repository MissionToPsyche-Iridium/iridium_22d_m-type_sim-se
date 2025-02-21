using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTool : MonoBehaviour
{
    public GameObject chimraTool;
    public GameObject archScrew;
    public GameObject clawTool;
    public GameObject touchTool;
    public GameObject touchNotions;

    //The current item equipped, to be called for animation purposes
    public Image currentTool;

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
        touchNotions.SetActive(true);
        currentTool.sprite = touchTool.GetComponent<Image>().sprite;
    }

    public void equipClaw()
    {
        unequipAll();
        clawTool.SetActive(true);
        currentTool.sprite = clawTool.GetComponent<Image>().sprite;
    }

    public void equipChimra()
    {
        unequipAll();
        chimraTool.SetActive(true);
        currentTool.sprite = chimraTool.GetComponent<Image>().sprite;
    }

    public void equipArchScrew()
    {
        unequipAll();
        archScrew.SetActive(true);
        currentTool.sprite = archScrew.GetComponent<Image>().sprite;
    }

    private void unequipAll()
    {
        chimraTool.SetActive(false);
        archScrew.SetActive(false);
        clawTool.SetActive(false);
        touchTool.SetActive(false);
        touchNotions.SetActive(false);
    }
}