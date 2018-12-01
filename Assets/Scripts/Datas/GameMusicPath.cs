/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     GameMusicPath.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-26 18:09 
 *Description:  音乐文件路径整理
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicPath : MonoBehaviour 
{
    // BGM资源路径
    private static string BGMPath = "Sounds/BGM/";
    // 音效路径
    private static string EffectPath = "Sounds/Effect/";

    /// <summary>
    /// BGM音乐,结算界面静音
    /// </summary>
    // 除战斗界面、结算界面
    public static string BGM_1 = BGMPath + "bgm_1";

    // 战斗界面
    public static string BGM_2 = BGMPath + "bgm_2";

    /// <summary>
    /// 音效
    /// </summary>
    // 按钮触摸
    public static string EFF_1 = EffectPath + "eff_1";

    // 按钮点击
    public static string EFF_2 = EffectPath + "eff_2";

    // 球体碰撞障碍物
    public static string EFF_3 = EffectPath + "eff_3";

    // 球死亡
    public static string EFF_4 = EffectPath + "eff_4";

    // 结算胜利
    public static string EFF_5 = EffectPath + "eff_5";

    // 结算失败
    public static string EFF_6 = EffectPath + "eff_6";

    public static string[] BGM_PATH_SA = { BGM_1, BGM_2 };
    public static string[] EFF_CURRBTN_SA = { EFF_1, EFF_2 };
    public static string[] EFF_END_SA = { EFF_5, EFF_6 };
}
