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
        if (sampleDetectWindow == null) return;
        if (IsNearSample())
        {
            sampleDetectWindow.SetActive(true);
        }
    }
    private bool IsNearSample()
    {
        Collider[] hitColliders = Physics.OverlapSphere(characterScript.transform.position, characterScript.interactionRange);
        foreach(Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("SampleChimra"){
                return true;
            }
        }
        return false;
    }
}
