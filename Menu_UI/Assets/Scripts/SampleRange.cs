using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleRange : MonoBehaviour
{
    public float SampleDetectProximity = 5f;
    public character characterScript;
    public GameObject sampleDetectWindow;
    private bool popUpVisible = false;


    // Start is called before the first frame update
    void Start()
    {
        if(sampleDetectWindow != null)
        {
            sampleDetectWindow.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sampleDetectWindow == null || characterScript == null) return;
        if (IsNearSample())
        {
            if (!popUpVisible)
            {
                sampleDetectWindow.SetActive(true);
                popUpVisible = true;
            }
        }
        else
        {
            if (popUpVisible)
            {
                sampleDetectWindow.SetActive(false);
                popUpVisible = false;
            }
        }
    }

    private bool IsNearSample()
    {
        Collider[] hitColliders = Physics.OverlapSphere(characterScript.transform.position, SampleDetectProximity);

        foreach (Collider hit in hitColliders)
        {
            if (hit.CompareTag("SampleChimra") ||
                hit.CompareTag("SampleTNG") ||
                hit.CompareTag("SampleScrew") ||
                hit.CompareTag("SampleClaw"))
            {
                Debug.Log("Sample detected: " + hit.name);
                return true;
            }
        }

        return false;
    }
}
