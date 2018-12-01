/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     SoundOs.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-26 17:22 
 *Description:  音乐播放控制
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOs : MonoBehaviour 
{
    // 背景音乐
    public AudioSource BgBgm;

    // 通用按钮音效
    public AudioSource BtnEff;

    public void OnStart()
    {
        SetBgBgmVolume();
        SetBtnEffVolume();
    }

    public void SetBgBgmVolume()
    {
        BgBgm.volume = GameData.Instance.BgmValue;
    }

    public void SetBtnEffVolume()
    {
        BtnEff.volume = GameData.Instance.EffValue;
    }

    /// <summary>
    /// 播放背景音乐
    /// 0 除战斗界面、结算界面
    /// 1 战斗界面
    /// </summary>
    /// <param name="index"></param>
    public void PlayBgm(int index)
    {
        if (GameData.Instance.CurrBgBgm == index) return;
        GameData.Instance.CurrBgBgm = index;
        BgBgm.clip = Resources.Load(GameMusicPath.BGM_PATH_SA[index], typeof(AudioClip)) as AudioClip;
        BgBgm.Play();
    }

    /// <summary>
    /// 播放按钮点击音效
    /// 0 当鼠标放上去
    /// 1 当鼠标点击
    /// </summary>
    /// <param name="index"></param>
    public void PlayCurrencyBtnEff(int index)
    {
        BtnEff.clip = Resources.Load(GameMusicPath.EFF_CURRBTN_SA[index], typeof(AudioClip)) as AudioClip;
        BtnEff.Play();
    }
}
