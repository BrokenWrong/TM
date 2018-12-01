/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     SoundOs.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-26 17:22 
 *Description:  ���ֲ��ſ���
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOs : MonoBehaviour 
{
    // ��������
    public AudioSource BgBgm;

    // ͨ�ð�ť��Ч
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
    /// ���ű�������
    /// 0 ��ս�����桢�������
    /// 1 ս������
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
    /// ���Ű�ť�����Ч
    /// 0 ��������ȥ
    /// 1 �������
    /// </summary>
    /// <param name="index"></param>
    public void PlayCurrencyBtnEff(int index)
    {
        BtnEff.clip = Resources.Load(GameMusicPath.EFF_CURRBTN_SA[index], typeof(AudioClip)) as AudioClip;
        BtnEff.Play();
    }
}
