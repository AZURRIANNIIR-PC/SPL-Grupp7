using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings_MusicController : MonoBehaviour {
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioMixer audioMixer;


    private void Start() {
        SetMasterVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
        SetMusicVolume(PlayerPrefs.GetFloat("SavedMusicVolume", 100));
        SetSFXVolume(PlayerPrefs.GetFloat("SavedSFXVolume", 100));
    }

    public void SetMasterVolume(float _value) {
        if (_value < 1) {
            _value = .001f;
        }
        RefreshMasterSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);
    }

    public void SetMusicVolume(float _value) {
        if (_value < 1) {
            _value = .001f;
        }
        RefreshMusicSlider(_value);
        PlayerPrefs.SetFloat("SavedMusicVolume", _value);
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(_value / 100) * 20f);
    }

    public void SetSFXVolume(float _value) {
        if (_value < 1)
        {
            _value = .001f;
        }
        RefreshSFXSlider(_value);
        PlayerPrefs.SetFloat("SavedSFXVolume", _value);
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(_value / 100) * 20f);
    }

    public void SetVolumeFromMasterSlider() {
        SetMasterVolume(masterSlider.value);
    }

    public void SetVolumeFromMusicSlider() {
        SetMusicVolume(musicSlider.value);
    }

    public void SetVolumeFromSFXSlider() {
        SetSFXVolume(sfxSlider.value);
    }

    public void RefreshMasterSlider(float _value) {
        masterSlider.value = _value;
    }

    public void RefreshMusicSlider(float _value) {
        musicSlider.value = _value;
    }

    public void RefreshSFXSlider(float _value) {
        sfxSlider.value = _value;
    }
}
