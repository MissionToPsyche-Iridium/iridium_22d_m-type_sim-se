using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{ 
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>(); 
    }

    public void PlaySound()
    {
        if (audioSource != null)
            audioSource.Play();
        else
            Debug.LogWarning("AudioSource is not assigned on " + gameObject.name);
    }
}
