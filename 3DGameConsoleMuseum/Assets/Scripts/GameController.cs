using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class GameController : MonoBehaviour
{
    public AudioMixer mixer;
    private void Start()
    {
        UserSettings.setAudioMixer(mixer);
    }
}
