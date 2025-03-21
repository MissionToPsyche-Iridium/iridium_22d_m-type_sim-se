using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleRandomizer : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject samples = null;
    public int totalSamples = 0;
    public int inactiveSamples = 0;
    void Start()
    {
        //while (totalSamples == 0) { };
        //while (inactiveSamples == 0) { };
       // while (samples is null) { samples = GameObject.Find("SceneSamples"); };

        int deactivatedSamples = 0;
        System.Random random = new System.Random();
        while (deactivatedSamples < inactiveSamples)
        {
            int index = random.Next(1, totalSamples);
            //if (!(GameObject.Find("Sample" + index.ToString()) is null)) {
                GameObject.Find("Sample" + index.ToString()).SetActive(false);
                deactivatedSamples++;
           // }
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}