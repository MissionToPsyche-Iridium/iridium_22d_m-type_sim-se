using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeTool : MonoBehaviour
{
    public GameObject chimraTool;
    public GameObject archScrew;
    public GameObject clawTool;
    public GameObject touchTool;

    public TextMeshProUGUI toolText;

    void Start()
    {
        UpdateToolText("None");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!chimraTool.activeSelf)
            {
                EquipChimra();
            }
            else
            {
                EquipClaw();
            }
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            if (!archScrew.activeSelf)
            {
                EquipArchScrew();
            }
            else
            {
                EquipTouchGo();
            }
        }
    }

    private void EquipTouchGo()
    {
        chimraTool.SetActive(false);
        archScrew.SetActive(false);
        clawTool.SetActive(false);
        touchTool.SetActive(true);
        UpdateToolText("Touch-And-Go");
    }

    private void EquipClaw()
    {
        chimraTool.SetActive(false);
        archScrew.SetActive(false);
        clawTool.SetActive(true);
        touchTool.SetActive(false);
        UpdateToolText("Claw and Filtration");
    }

    public void EquipChimra()
    {
        chimraTool.SetActive(true);
        archScrew.SetActive(false);
        clawTool.SetActive(false);
        touchTool.SetActive(false);
        UpdateToolText("Chimra Turret");
    }

    public void EquipArchScrew()
    {
        chimraTool.SetActive(false);
        archScrew.SetActive(true);
        clawTool.SetActive(false);
        touchTool.SetActive(false);
        UpdateToolText("Archimede Screw");
    }

    private void UpdateToolText(string toolName)
    {
        if (toolText != null)
        {
            toolText.text = "Current Tool: " + toolName;
        }
    }
}
