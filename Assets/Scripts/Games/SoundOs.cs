
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOs : MonoBehaviour 
{
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


    // 当前播放的背景音乐
    private int currPlaySoundI = -1;

    // 瓶子音效
    public AudioSource PinziSound;

    // 气泡音效
    public AudioSource CheckSound;

    // 击碎音效
    public AudioSource JisuiSound;
    public AudioClip[] jisuiClipArr;
    private int currJisui = 0;

    // 击碎后人声
    public AudioSource JisuiRSound;
    private int currJsR = -1;

    // 动图人声
    public AudioSource DtSound;
    private int currDt = -1;

    void Awake()
    {
        GameData.Instance.soundOs = transform.GetComponent<SoundOs>();
    }

    void Start()
    {
        RefreshCzValue();
        RefreshBgValue();
        RefreshRsValue();
    }

    // 刷新音效音量
    public void RefreshCzValue()
    {
        dishuAudioSource.volume = GameData.Instance.czValue;
        SuilieSound.volume = GameData.Instance.czValue;
        CheckSound.volume = GameData.Instance.czValue;
    }
    // 刷新背景音量
    public void RefreshBgValue()
    {
        BgSound.volume = GameData.Instance.bgValue;
    }
    // 刷新人声音量
    public void RefreshRsValue()
    {
        PinziSound.volume = GameData.Instance.rsValue;
        JisuiSound.volume = GameData.Instance.rsValue;
        JisuiRSound.volume = GameData.Instance.rsValue;
        DtSound.volume = GameData.Instance.rsValue;
    }

    public void PlayDishuSound()
    {
        dishuAudioSource.Play();
    }

    // 播放方块碎裂音效
    public void PlaySuilieSound()
    {
        SuilieSound.Play();
    }

    // 播放背景音乐
    public void PlayBgSound(int index)
    {
        StopDtSound();
        StopJisuiRSound();
        currPlaySoundI = index;
        BgSound.clip = audioClipArr[index];
        BgSound.Play();
    }
    public void PlaytBgSound()
    {
        int index = UnityEngine.Random.Range(13, 16);
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
    //  播放角色声音
    public void PlayRoleBgm()
    {
        if (GameData.Instance.passCurr - 1 == currPlaySoundI) return;
        currPlaySoundI = GameData.Instance.passCurr - 1;

        string str = GameData.Instance.GetPassStr(currPlaySoundI, "roleClip");
        BgSound.clip = Resources.Load(str, typeof(AudioClip)) as AudioClip;
        BgSound.Play();

        //StopJisuiRSound();
    }

    // 播放瓶子音效
    public void PlayPinziSound(string str)
    {
        PinziSound.clip = Resources.Load(str, typeof(AudioClip)) as AudioClip;
        PinziSound.Play();
    }
    // 停止播放瓶子音效
    public void StopPinziSound()
    {
        PinziSound.Stop();
    }

    // 播放气泡音效
    public void PlayCheckSound()
    {
        CheckSound.Play();
    }

    // 播放击碎音效
    public void PlayJisuiSound()
    {
        JisuiSound.clip = jisuiClipArr[currJisui];
        JisuiSound.Play();
        currJisui++;
        if(currJisui >= 3)
        {
            currJisui = 0;
        }
    }

    // 播放击碎后人声
    public void PlayJisuiRSound()
    {
        StopDtSound();
        if (GameData.Instance.isPatch == false) return;
        if (currJsR == GameData.Instance.passCurr) return;
        currJsR = GameData.Instance.passCurr;
        string str = GameData.Instance.GetCurrPassStr("JisuiRSound");
        JisuiRSound.clip = Resources.Load(str, typeof(AudioClip)) as AudioClip;
        JisuiRSound.Play();
    }
    // 停止击碎后人声
    public void StopJisuiRSound()
    {
        JisuiRSound.Stop();
        currJsR = -1;
    }

    // 播放动图人声
    public void PlayDtSound()
    {
        StopJisuiRSound();
        if (GameData.Instance.isPatch == false) return;
        if (currDt == GameData.Instance.passCurr) return;
        currDt = GameData.Instance.passCurr;
        string str = GameData.Instance.GetCurrPassStr("dtSound");
        DtSound.clip = Resources.Load(str, typeof(AudioClip)) as AudioClip;
        DtSound.Play();
    }
    // 停止播放动图人声
    public void StopDtSound()
    {
        DtSound.Stop();
        currDt = -1;
    }
}
