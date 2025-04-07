using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Audio;


public static class UserSettings
{
    private static float masterVolume = 0.5f;
    private static float musicVolume = 0.5f;
    private static float sfxVolume = 0.5f;

    private static AudioMixer mixer;

    private static float convertToDB(float volume)
    {
        if (volume == 0f)
        {
            // Mute
            return -80f;
        }
        return Mathf.Min(20 * Mathf.Log10(volume), 0);
    }

    public static void setAudioMixer(AudioMixer mixer)
    {
        UserSettings.mixer = mixer;
        updateMixer();
    }

    public static void updateMixer()
    {
        mixer.SetFloat("Master", convertToDB(masterVolume));
        mixer.SetFloat("Music", convertToDB(musicVolume));
        mixer.SetFloat("SFX", convertToDB(sfxVolume));
    }

    public static void setMasterVolume(float masterVolume)
    {
        UserSettings.masterVolume = masterVolume;
        mixer.SetFloat("Master", convertToDB(masterVolume));
    }

    public static void setMusicVolume(float musicVolume)
    {
        UserSettings.musicVolume = musicVolume;
        mixer.SetFloat("Music", convertToDB(musicVolume));
    }

    public static void setSFXVolume(float sfxVolume)
    {
        UserSettings.sfxVolume = sfxVolume;
        mixer.SetFloat("SFX", convertToDB(sfxVolume));
    }

    public static float getMasterVolume()
    {
        return masterVolume;
    }

    public static float getMusicVolume()
    {
        return musicVolume;
    }

    public static float getSFXVolume()
    {
        return sfxVolume;
    }

}
