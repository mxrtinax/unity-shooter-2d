using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume = 1)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        Debug.Log(volume);
    }
}
