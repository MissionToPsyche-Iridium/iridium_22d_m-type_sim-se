using UnityEngine;
using UnityEngine.UI;

public class SampleCounter : MonoBehaviour
{
    public Text sampleText;
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
