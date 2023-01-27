using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip fire1Sound;
    static AudioSource audioSrc;

    void Start()
    {
        fire1Sound = Resources.Load<AudioClip>("SoundEffects/fire1");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "fire1":
                audioSrc.PlayOneShot(fire1Sound);
                break;
        }
    }
}
