using System.Collections;
using UnityEditor;
using UnityEngine;

public class SetCurrentTool : MonoBehaviour
{

    public GameObject ArchPanel;
    public GameObject ChimraPanel;
    public GameObject TNGPanel;
    public GameObject ClawPanel;

    // Start is called before the first frame update
    void Start()
    {
        ChimraPanel.SetActive(true);
    }

    // Update Current Tool Panel
    void Update()
    {

    }

    public void SetArchTool() {
        ChimraPanel.SetActive(false);
        TNGPanel.SetActive(false);
        ClawPanel.SetActive(false);
        ArchPanel.SetActive(true);
    }

    public void SetChimraTool() {
        TNGPanel.SetActive(false);
        ClawPanel.SetActive(false);
        ArchPanel.SetActive(false);
        ChimraPanel.SetActive(true);
    }

    public void SetTNGTool() {
        ClawPanel.SetActive(false);
        ArchPanel.SetActive(false);
        ChimraPanel.SetActive(false);
        TNGPanel.SetActive(true);
    }

    public void SetClawTool() {
        TNGPanel.SetActive(false);
        ArchPanel.SetActive(false);
        ChimraPanel.SetActive(false);
        ClawPanel.SetActive(true);
    }
}