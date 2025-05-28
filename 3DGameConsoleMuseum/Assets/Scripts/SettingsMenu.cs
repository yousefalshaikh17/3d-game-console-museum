using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    public void updateDisplay()
    {
        masterVolumeSlider.value = UserSettings.getMasterVolume();
        musicVolumeSlider.value = UserSettings.getMusicVolume();
        sfxVolumeSlider.value = UserSettings.getSFXVolume();
    }

    // OnEnable() instead of Awake() because this will be enabled multiple times and it is always disabled by default.
    void OnEnable()
    {
        updateDisplay();
    }

    private void Start()
    {
        UserSettings.updateMixer();
    }


    public void setMasterVolume(float value)
    {
        UserSettings.setMasterVolume(value);
    }

    public void setMusicVolume(float value)
    {
        UserSettings.setMusicVolume(value);
    }

    public void setSFXVolume(float value)
    {
        UserSettings.setSFXVolume(value);
    }

}
