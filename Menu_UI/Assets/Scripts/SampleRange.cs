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

    // Start is called before the first frame update
    void Start()
    {
        if (sampleDetectWindow != null)
        {
            sampleDetectWindow.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (characterScript == null) return;

        float distanceToPlayer = Vector3.Distance(characterScript.transform.position, transform.position);

        if (distanceToPlayer <= SampleDetectProximity)
        {
            if (!popUpVisible)
            {
                if (sampleDetectWindow != null)
                    sampleDetectWindow.SetActive(true);

                if (pressEText != null)
                    pressEText.SetActive(true);

                popUpVisible = true;
            }
        }
        else
        {
            if (popUpVisible)
            {
                if (sampleDetectWindow != null)
                    sampleDetectWindow.SetActive(false);

                if (pressEText != null)
                    pressEText.SetActive(false);

                popUpVisible = false;
            }
        }
    }
}
