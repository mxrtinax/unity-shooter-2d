using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown dropdown;
    public GameObject toggle;

    void Start() 
    {
        dropdown.value = QualitySettings.GetQualityLevel();
    }

    public void SetVolume(float volume = 1)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        Debug.Log(volume);
    }

    public void SetQuality(int value) 
    {
        QualitySettings.SetQualityLevel(value);
        switch (value) 
        {
            case 0:
                dropdown.image.color = new Color32(243, 167, 0, 255);
                break;

            case 1:
                dropdown.image.color = new Color32(237, 120, 0, 255);
                break;

            case 2:
                dropdown.image.color = new Color32(237, 70, 0, 255);
                break;
        }
    }

    public void SetFullscreen(bool isFullscreen) 
    {
        Screen.fullScreen = isFullscreen;
        if (isFullscreen == true)
        {
            toggle.GetComponent<Toggle>().GetComponentInChildren<Text> ().text = "Fullscreen";
        }
        else {
            toggle.GetComponent<Toggle>().GetComponentInChildren<Text> ().text = "Windowed";
        }
    }
}   
