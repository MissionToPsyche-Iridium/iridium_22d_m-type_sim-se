using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolPopup : MonoBehaviour
{
    public GameObject toolPanel;
    public void showTouchGo()
    {
        toolPanel.SetActive(true);
        GameObject.Find("ToolImage").GetComponent<Image>().sprite = GameObject.Find("Touch & Go").GetComponent<Image>().sprite;
        GameObject.Find("Tool Title Text").GetComponent<TextMeshProUGUI>().SetText("Touch and Go");
        GameObject.Find("Tool Descrip Text").GetComponent<TextMeshProUGUI>().SetText(GameObject.Find("TouchGoText").GetComponent<TextMeshProUGUI>().text);
    }

    public void showClaw()
    {
        toolPanel.SetActive(true);
        GameObject.Find("ToolImage").GetComponent<Image>().sprite = GameObject.Find("Claw").GetComponent<Image>().sprite;
        GameObject.Find("Tool Title Text").GetComponent<TextMeshProUGUI>().SetText("Claw");
        GameObject.Find("Tool Descrip Text").GetComponent<TextMeshProUGUI>().SetText(GameObject.Find("ClawText").GetComponent<TextMeshProUGUI>().text);
    }

    public void showChimra()
    {
        toolPanel.SetActive(true);
        GameObject.Find("ToolImage").GetComponent<Image>().sprite = GameObject.Find("CHIMRA").GetComponent<Image>().sprite;
        GameObject.Find("Tool Title Text").GetComponent<TextMeshProUGUI>().SetText("CHIMRA");
        GameObject.Find("Tool Descrip Text").GetComponent<TextMeshProUGUI>().SetText(GameObject.Find("ChimraText").GetComponent<TextMeshProUGUI>().text);
    }

    public void showArchScrew()
    {
        toolPanel.SetActive(true);
        GameObject.Find("ToolImage").GetComponent<Image>().sprite = GameObject.Find("Archimede's Screw").GetComponent<Image>().sprite;
        GameObject.Find("Tool Title Text").GetComponent<TextMeshProUGUI>().SetText("Archimede's Screw");
        GameObject.Find("Tool Descrip Text").GetComponent<TextMeshProUGUI>().SetText(GameObject.Find("ArchText").GetComponent<TextMeshProUGUI>().text);
    }
}
