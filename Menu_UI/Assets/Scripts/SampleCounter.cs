using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SampleCounter : MonoBehaviour
{
    public Text sampleText;
    public GameObject zoneCompleted;
    private int sampleCount = 0;

    public void AddSample()
    {
        
        sampleCount++; 
        UpdateSampleText(); 
        
        if (zoneCompleted && sampleCount == 4) {
            zoneCompleted.GetComponent<Animator>().SetBool("start", true);
        }
    }

    private void UpdateSampleText()
    {
        sampleText.text = "Samples Collected: " + sampleCount;
    }
}
