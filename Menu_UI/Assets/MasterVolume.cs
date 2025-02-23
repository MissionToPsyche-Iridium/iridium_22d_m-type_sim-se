using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MasterVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider masterSlider;


    private void Start() {
        if(PlayerPrefs.HasKey("master")) {
            LoadVolume();
        } else {
            SetMasterVolume();
        }
    }
    public void SetMasterVolume() {
        float volume = masterSlider.value;
        myMixer.SetFloat("MasterVolume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("master", volume);
        PlayerPrefs.Save();
    }

    private void LoadVolume() {
        masterSlider.value=PlayerPrefs.GetFloat("master");
        myMixer.SetFloat("MasterVolume", Mathf.Log10(masterSlider.value)*20);
        SetMasterVolume();
    }
}
