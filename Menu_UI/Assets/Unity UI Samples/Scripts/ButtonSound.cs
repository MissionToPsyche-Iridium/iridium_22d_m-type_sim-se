using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{ 
    public AudioSource audioSource;

    public void Start()
    {
        //audioSource.Stop();
    }
    public void PlaySound()
    {
        audioSource.Play();
    }
}
