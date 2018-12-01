/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     GameData.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-26 15:18 
 *Description:  游戏数据
 *History: 
*****************************************************************/

using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : YYSingleton<GameData> 
{
    public GameManagers gameManagers;

    // 背景音乐
    public float BgmValue { get; set; }

    // 音效
    public float EffValue { get; set; }

    /// <summary>
    ///界面语言
    /// 0    1        2        3    4    5      6    7    8      9        10     11     12   13   14
    /// 英文 简体中文 繁体中文 德语 法语 西班牙 丹麦 俄语 乌克兰 保加利亚 土耳其 匈牙利 希腊 挪威 捷克
    /// 15   16   17   18   19     20       21   22   23       24     25
    /// 日语 波兰 泰语 瑞典 意大利 罗马尼亚 芬兰 荷兰 葡萄牙语 阿拉伯 韩语
    /// </summary>
    // 游戏界面默认语言(英文)
    public int Language { get; set; }

    // 屏幕
    public bool ScreenMode { get; set; }

    // 语言配置
    private JsonData LanguageData;

    // 当前播放背景音乐
    public int CurrBgBgm { get; set; }

    /// <summary>
    /// 关卡本地存储数据
    /// 1 未解锁 2 已解锁未挑战 3 挑战失败 4 挑战成功
    /// </summary>
    public Dictionary<int, int> PassData = new Dictionary<int, int>();

    // 关卡配置数据
    private JsonData PassConfigData;

    // 当前正在闯的关
    public int CurrPlayCheck { get; set; }

    public void Init(Transform tf)
    {
        gameManagers = tf.GetComponent<GameManagers>();
        GetSaveData();
        ScreenMode = Screen.fullScreen;
        LanguageData = ConfigManager.Instance.ParseConfig("Configs/Language");
        PassConfigData = ConfigManager.Instance.ParseConfig("Configs/PassConfig");
        CurrBgBgm = -1;
    }

    // 获取本地存储数据
    public void GetSaveData()
    {
        Dictionary<string, string> _dict = new Dictionary<string, string>();
        string[] strArr1 = new string[] { "BgmValue", "EffValue", "Language", "PassData" };
        string[] strArr2 = new string[] { "0.5", "0.5", "0", PassDataToString() };
        _dict = GameSaveData.ObtainData("save.sav", strArr1, strArr2);
        BgmValue = float.Parse(_dict["BgmValue"]);
        EffValue = float.Parse(_dict["EffValue"]);
        Language = int.Parse(_dict["Language"]);
        StringToPassData(_dict["PassData"]);
    }
    // 存储本地数据
    public void SaveData()
    {
        string[] strArr1 = new string[] { "BgmValue", "EffValue", "Language", "PassData" };
        string[] strArr2 = new string[] { BgmValue.ToString(), EffValue.ToString(), Language.ToString(), SavePassDataToString() };
        GameSaveData.SaveData("save.sav", strArr1, strArr2);
    }
    private string PassDataToString()
    {
        string str = "2";
        for (int i = 1; i < 20; i++)
        {
            str = str + "+1";
        }
        return str;
    }
    private string SavePassDataToString()
    {
        string str = PassData[1].ToString();
        for (int i = 2; i < PassData.Count + 1; i++)
        {
            str = str + "+" + PassData[i].ToString();
        }
        return str;
    }
    private void StringToPassData(string str)
    {
        string[] arr = str.Split('+');
        for (int i = 0; i < arr.Length; i++)
        {
            PassData[i + 1] = int.Parse(arr[i]);
        }
    }

    // LanguageData
    public string GetLanguageStr(string str)
    {
        return LanguageData[str]["L_" + Language].ToString();
    }

    // PassConfigData 
    // nameText cgImg bgImg bgRole ePos eHp eImg zPos zImg ePng
    public string GetPassConfigStr(string check, string name)
    {
        return PassConfigData[check][name].ToString();
    }
    public string[] GetPassConfigSA(string check, string name)
    {
        return GetPassConfigStr(check, name).Split(';');
    }
    public string GetPassConfigStr(string name)
    {
        return PassConfigData[CurrPlayCheck.ToString()][name].ToString();
    }
    public string[] GetPassConfigSA(string name)
    {
        return GetPassConfigStr(name).Split(';');
    }
    public Vector3[] GetPassConfigVA(string name)
    {
        string[] sa = GetPassConfigStr(name).Split(';');
        Vector3[] vec = new Vector3[sa.Length];
        for (int i = 0; i < sa.Length; i++)
        {
            string[] str = sa[i].Split(',');
            vec[i] = new Vector3(float.Parse(str[0]), float.Parse(str[1]), 0);
        }
        return vec;
    }
    public int[] GetPassConfigIA(string name)
    {
        string[] sa = GetPassConfigStr(name).Split(';');
        int[] ia = new int[sa.Length];
        for (int i = 0; i < sa.Length; i++)
        {
            ia[i] = int.Parse(sa[i]);
        }
        return ia;
    }
}
