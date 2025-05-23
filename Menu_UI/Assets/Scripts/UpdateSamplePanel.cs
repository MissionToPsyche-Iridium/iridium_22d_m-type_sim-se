using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class UpdateSamplePanel : MonoBehaviour
{
    public GameObject SamplesPanel;
    public GameObject zeroSamplePanel;
    public GameObject oneSamplePanel;
    public GameObject twoSamplePanel;
    public GameObject threeSamplePanel;
    public GameObject fourSamplePanel;
    public character character;
    public GameObject zoneCompleted;
    public AudioClip successAudio;
    public AudioClip winnerAudio;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        zeroSamplePanel.SetActive(true);
        audioSource = GetComponent<AudioSource>();

        if (character == null)
        {
            character = FindObjectOfType<character>();
        }

        if (character == null)
        {
            Debug.LogError("Character script not found! Ensure it's assigned in the Inspector or exists in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateSampleCollection()
    {
        if (character.getSampleCount() == 1)
        {
            zeroSamplePanel.SetActive(false);
            oneSamplePanel.SetActive(true);
            audioSource.PlayOneShot(successAudio, 1);
        }
        if (character.getSampleCount() == 2)
        {
            oneSamplePanel.SetActive(false);
            twoSamplePanel.SetActive(true);
            audioSource.PlayOneShot(successAudio, 1);
        }
        if (character.getSampleCount() == 3)
        {
            twoSamplePanel.SetActive(false);
            threeSamplePanel.SetActive(true);
            audioSource.PlayOneShot(successAudio, 1);
        }
        if (character.getSampleCount() == 4)
        {
            threeSamplePanel.SetActive(false);
            fourSamplePanel.SetActive(true);
            audioSource.PlayOneShot(winnerAudio, 1);
        }
    }
}
