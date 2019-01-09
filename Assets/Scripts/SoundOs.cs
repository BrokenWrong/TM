
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOs : MonoBehaviour 
{
    public AudioSource audioSource;

    public AudioSource dishuAudioSource;

    public void PlayBtnSound()
    {
        if (!GameData.Instance().isHaveSound) return;
        audioSource.Play();
    }

    public void PlayDishuSound()
    {
        if (!GameData.Instance().isHaveSound) return;
        dishuAudioSource.Play();
    }
}
