using UnityEngine;
using TMPro; 

public class SampleCounter : MonoBehaviour
{
    public TextMeshProUGUI sampleText;
    private int sampleCount = 0; 

    public void AddSample()
    {
        sampleCount++; 
        UpdateSampleText(); 
    }

    private void UpdateSampleText()
    {
        sampleText.text = "Samples Collected: " + sampleCount;
    }
}
