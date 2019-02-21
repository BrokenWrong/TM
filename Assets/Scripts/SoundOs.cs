
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOs : MonoBehaviour 
{
    public AudioSource audioSource;

    public AudioSource dishuAudioSource;

    // 背景音乐
    public AudioSource BgSound;

    // 方块碎裂音效
    public AudioSource SuilieSound;

    /// <summary>
    /// 0 - 11
    /// 01 02 03 04 05 06 07 08 09 10 11 12 
    /// 12 - 20
    /// chui dadishu1 dadishu2 dadishu3 dadishu4 eff_3 eff_4 fengmian suilie
    /// </summary>
    public AudioClip[] audioClipArr;

    void Awake()
    {
        GameData.Instance().soundOs = transform.GetComponent<SoundOs>();
    }

    void Start()
    {
        if (GameData.Instance().isHaveSound)
        {
            PlayYing();
        }
        else
        {
            Jinying();
        }
    }

    public void PlayBtnSound()
    {
        //if (!GameData.Instance().isHaveSound) return;
        //audioSource.Play();
    }

    public void PlayDishuSound()
    {
        if (!GameData.Instance().isHaveSound) return;
        dishuAudioSource.Play();
    }

    // 播放方块碎裂音效
    public void PlaySuilieSound()
    {
        if (!GameData.Instance().isHaveSound) return;
        SuilieSound.Play();
    }

    // 播放背景音乐
    public void PlayBgSound(int index)
    {
        BgSound.clip = audioClipArr[index];
        BgSound.Play();
    }
    // 停止播放背景音乐
    public void StopBgSound()
    {
        BgSound.Stop();
    }
    // 静音
    public void Jinying()
    {
        BgSound.volume = 0;
    }
    // 开启声音
    public void PlayYing()
    {
        BgSound.volume = 1;
    }
}
