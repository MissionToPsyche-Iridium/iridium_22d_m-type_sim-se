using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleRandomizer : MonoBehaviour
{
    public int totalSamples = 0;
    public int inactiveSamples = 0;
    public double archSampleRate = 25;     // Percentage of samples to be sampled by the Archimede's Screw
    public double chimraSampleRate = 25;   // Percentage of samples to be sampled by the CHIMRA
    public double clawSampleRate = 25;    // Percentage of samples to be sampled by the Claw and Filtration
    public double touchSampleRate = 25;    // Percentage of samples to be sampled by the Touch and Go

    void Start()
    {
        //while (totalSamples == 0) { };
        //while (inactiveSamples == 0) { };
        // while (samples is null) { samples = GameObject.Find("SceneSamples"); };
        assignSampleType();
        int deactivatedSamples = 0;
        System.Random random = new System.Random();
        while (deactivatedSamples < inactiveSamples)
        {
            int index = random.Next(1, totalSamples);
            if (!(GameObject.Find("Sample" + index.ToString()) is null)) {
                GameObject.Find("Sample" + index.ToString()).SetActive(false);
                deactivatedSamples++;
            }
        }

    }

    private void assignSampleType()
    {
        // Reset the values to default if they're not equal to 100
        if (archSampleRate + chimraSampleRate + clawSampleRate + touchSampleRate != 100)
        {
            archSampleRate = 25;
            chimraSampleRate = 25;
            clawSampleRate = 25;
            touchSampleRate = 25;
        } else {
            // Floors each of the first three sample types rate at the nearest 5% and assigns the
            // remainder to Touch and Go
            archSampleRate = archSampleRate - (archSampleRate % 5);
            chimraSampleRate = chimraSampleRate - chimraSampleRate % 5;
            clawSampleRate = clawSampleRate - clawSampleRate % 5;
            touchSampleRate = 100 - (archSampleRate + chimraSampleRate + clawSampleRate);
        }
        double archIndex = (archSampleRate / 100 * totalSamples);
        double chimraIndex = archIndex + (chimraSampleRate / 100 * totalSamples);
        double clawIndex = chimraIndex + (clawSampleRate / 100 * totalSamples);
        double touchIndex = totalSamples;

        for (int index = 1; index <= totalSamples; index++)
        {
            Debug.Log("Setting Sample" + index + " of " + totalSamples);
            if (index <= archIndex)
            {
                GameObject.Find("Sample" + index.ToString()).tag = "SampleScrew";
            }
            else if (index <= chimraIndex)
            {
                GameObject.Find("Sample" + index.ToString()).tag = "SampleChimra";
            }
            else if (index <= clawIndex)
            {
                GameObject.Find("Sample" + index.ToString()).tag = "SampleClaw";
            }
            else
            {
                GameObject.Find("Sample" + index.ToString()).tag = "SampleTNG";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}