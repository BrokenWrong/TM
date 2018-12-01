/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     GameMusicPath.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-26 18:09 
 *Description:  �����ļ�·������
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicPath : MonoBehaviour 
{
    // BGM��Դ·��
    private static string BGMPath = "Sounds/BGM/";
    // ��Ч·��
    private static string EffectPath = "Sounds/Effect/";

    /// <summary>
    /// BGM����,������澲��
    /// </summary>
    // ��ս�����桢�������
    public static string BGM_1 = BGMPath + "bgm_1";

    // ս������
    public static string BGM_2 = BGMPath + "bgm_2";

    /// <summary>
    /// ��Ч
    /// </summary>
    // ��ť����
    public static string EFF_1 = EffectPath + "eff_1";

    // ��ť���
    public static string EFF_2 = EffectPath + "eff_2";

    // ������ײ�ϰ���
    public static string EFF_3 = EffectPath + "eff_3";

    // ������
    public static string EFF_4 = EffectPath + "eff_4";

    // ����ʤ��
    public static string EFF_5 = EffectPath + "eff_5";

    // ����ʧ��
    public static string EFF_6 = EffectPath + "eff_6";

    public static string[] BGM_PATH_SA = { BGM_1, BGM_2 };
    public static string[] EFF_CURRBTN_SA = { EFF_1, EFF_2 };
    public static string[] EFF_END_SA = { EFF_5, EFF_6 };
}
