//Adin Farid, adfa8505
//Linn Li, lili6794
//Nora Wennerberg, nowe9092

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioMixer audioMixer;


    private void Start() {
        if (PlayerPrefs.HasKey("musicVolume")) {
            LoadVolume();
        }
        else {
            SetMusicVolume();
            SetSFXVolume();
            SetMasterVolume();
        }
    }

    public void SetMusicVolume() {
        float volume = musicSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume() {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetMasterVolume(){
        float volume = masterSlider.value;
        audioMixer.SetFloat("master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    private void LoadVolume() {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        SetMusicVolume();
        SetSFXVolume();
        SetMasterVolume();
    }
}
