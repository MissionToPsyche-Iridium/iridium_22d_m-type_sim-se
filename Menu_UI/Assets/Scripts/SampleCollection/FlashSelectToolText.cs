using System.Collections;
using UnityEditor;
using UnityEngine;

public class FlashSelectToolText : MonoBehaviour
{

    public GameObject samplingText;

    void Start()
    {
        if (samplingText != null) 
        {
            InvokeRepeating("Toggle", 0f, 0.4f);
        }
    }

    // Toggle the sampling text
    void Toggle()
    {
        samplingText.SetActive(!samplingText.activeSelf);
    }
}