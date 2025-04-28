using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleRange : MonoBehaviour
{
    public float SampleDetectProximity = 5f;
    public character characterScript;
    public GameObject sampleDetectWindow;
    private bool popUpVisible = false;
    public GameObject pressEText;
    private bool hasBeenCollected = false;
    public ToolPOV toolPOV;

    // Start is called before the first frame update
    void Start()
    {
        if (sampleDetectWindow != null)
        {
            sampleDetectWindow.SetActive(false);

        }
        if (pressEText != null)
        {
            pressEText.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (sampleDetectWindow == null || characterScript == null || hasBeenCollected) return;
        float distance = Vector3.Distance(characterScript.transform.position, transform.position);

        if (distance <= SampleDetectProximity)
        {
            if (!popUpVisible)
            {
                pressEText.SetActive(true);
                sampleDetectWindow.SetActive(true);

                popUpVisible = true;
            }
        }
        else
        {
            if (popUpVisible)
            {
                pressEText.SetActive(false);
                sampleDetectWindow.SetActive(false);

                popUpVisible = false;
            }
        }
    }
    public void MarkCollected()
    {
        hasBeenCollected = true;

        if (pressEText != null)
            pressEText.SetActive(false);

        if (sampleDetectWindow != null)
            sampleDetectWindow.SetActive(false);

        if (toolPOV != null)
        {
            toolPOV.ActivatePOV();
        }
        else
        {
            Debug.LogWarning("ToolPOV reference is not assigned");
        }
    }


}