using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameData : YYSingleton<GameData>
{
    // 关卡数
    public int passMax;

    // 已通关关卡数
    public int passAdopt;

    // 当前正在通关
    public int passCurr;

    // 当前通关关卡选关点
    public ArrayList passChooseSpot = new ArrayList();

    // 当前通关关卡
    public ArrayList passSpotArr = new ArrayList();

    // 当前正在通关的选关点
    public int spotCurr;

    // 音乐
    public SoundOs soundOs;

    // 初始数据
    private JsonData initData;

    // 关卡数据
    private JsonData passData;

    // 是否打了补丁
    public bool isPatch;

    // 游戏分辨率比例
    public float gameScreen = 1920f / Screen.width;

    public JsonData PatchData;

    // 存档名
    private string saveName = "save1_4.sav";

    // 锤子音量
    public float czValue;
    // 背景音量
    public float bgValue;
    // 人声音量
    public float rsValue;

    // 初始化
    public void InitData()
    {
        // 补丁
        ReadPatch();

        // 存档
        GetSaveFileData();

        // 数据
        ReadInitData();
        ReadPassData();
        InitGameData();
    }

    // 是否打补丁
    private void ReadPatch()
    {
        PatchData = ConfigManager.Instance.ParseConfig("Config/Patch");
        isPatch = (PatchData["patch"].ToString() == "1") ? true : false;
    }

    // 获取存档
    private void GetSaveFileData()
    {
        string[] strArr1 = new string[] { "passAdopt", "passChooseSpot", "isHaveSound", "passSpotArr" };
        //测试 音乐1修改成0
        string[] strArr2 = new string[] { "0", "n", "1;1;1", "n"};
        Dictionary<string, string> dict = GameSaveData.ObtainData(saveName, strArr1, strArr2);
        passAdopt = int.Parse(dict["passAdopt"]);

        // 存档音量处理
        SoundToValue(dict["isHaveSound"]);

        string[] passChooseSpotA = dict["passChooseSpot"].Split(';');
        if (passChooseSpotA[0] == "n") return;
        for (int i = 0; i < passChooseSpotA.Length; i++)
        {
            passChooseSpot.Add(int.Parse(passChooseSpotA[i]));
        }

        string[] passSpotArrS = dict["passSpotArr"].Split(';');
        for (int i = 0; i < passSpotArrS.Length; i++)
        {
            if (passSpotArr.Contains(int.Parse(passSpotArrS[i])) == false)
            {
                passSpotArr.Add(int.Parse(passSpotArrS[i]));
            }
        }
    }

    // 存档音量转换
    private void SoundToValue(string str)
    {
        if (str == "0" || str == "1")
        {
            czValue = 1;
            bgValue = 1;
            rsValue = 1;
        }
        else
        {
            string[] strArr = str.Split(';');
            czValue = float.Parse(strArr[0]);
            bgValue = float.Parse(strArr[1]);
            rsValue = float.Parse(strArr[2]);
        }
    }

    // 初始化数据
    private void InitGameData()
    {
        passMax = int.Parse(initData["passMax"].ToString());
    }

    // 保存存档
    public void SaveFileData()
    {
        string[] strArr1 = new string[] { "passAdopt", "passChooseSpot", "isHaveSound", "passSpotArr" };
        string[] strArr2 = new string[] { passAdopt.ToString(), GetPassChooseSpotS(), GetSoundToValue(), GetPassSpotArr() };
        GameSaveData.SaveData(saveName, strArr1, strArr2);
    }
    public string GetSoundToValue()
    {
        string str = czValue.ToString() + ";" + bgValue.ToString() + ";" + rsValue.ToString();
        return str;
    }
    private string GetPassChooseSpotS()
    {
        string passChooseSpotS = "";
        if(passChooseSpot.Count == 0)
        {
            return "n";
        }
        passChooseSpotS = passChooseSpot[0].ToString();
        for (int i = 1; i < passChooseSpot.Count; i++)
        {
            passChooseSpotS = passChooseSpotS + ";" + passChooseSpot[i].ToString();
        }
        return passChooseSpotS;
    }
    private string GetPassSpotArr()
    {
        string passSpotArrS = "";
        if(passSpotArr.Count == 0)
        {
            return "n";
        }
        passSpotArrS = passSpotArr[0].ToString();
        for (int i = 0; i < passSpotArr.Count; i++)
        {
            passSpotArrS = passSpotArrS + ";" + passSpotArr[i].ToString();
        }
        return passSpotArrS;
    }

    // 添加关卡选关点
    public void AddPassChooseSpot(int i)
    {
        passChooseSpot.Add(i);
    }

    // 判断是否通关选关点
    public bool IsPassChooseSpot(int i)
    {
        return passChooseSpot.Contains(i);
    }

    // 选出没通过的选关点
    public int GetPassChooseSpot()
    {
        int index = 0;
        for (int i = 0; i < passMax; i++)
        {
            if(!IsPassChooseSpot(i))
            {
                index = i;
                break;
            }
        }
        return index;
    }

    // 添加通关关卡
    private void AddPassSpotArr(int i)
    {
        if (passSpotArr.Contains(i) == true) return;
        passSpotArr.Add(i);
        GameAchStatic.SetAchievement(GetPassStr(i - 1, "ach"));
    }

    // 判断是否通过此关
    public bool IsPassSpotArr()
    {
        return passSpotArr.Contains(passCurr);
    }

    // 通关保存数据
    public void SaveData()
    {
        if (passCurr <= passAdopt) return;
        AddPassChooseSpot(spotCurr);
        AddPassSpotArr(passCurr);
        passAdopt++;
        SaveFileData();
    }

    // initData
    private void ReadInitData()
    {
        //string str = "Config/InitData";
        //if (isPatch == true)
        //{
        //    str = "Config/InitDataPatch";
        //}
        initData = ConfigManager.Instance.ParseConfig("Config/InitDataPatch");
    }

    // passData
    private void ReadPassData()
    {
        //string str = "Config/PassData";
        //if (isPatch == true)
        //{
        //    str = "Config/PassDataPatch";
        //}
        passData = ConfigManager.Instance.ParseConfig("Config/PassDataPatch");
    }
    public Vector3 GetPinziPos(int index)
    {
        string[] strArr = passData[index]["pinziPos"].ToString().Split(',');
        return new Vector3(float.Parse(strArr[0]), float.Parse(strArr[1]), 0);
    }
    // 判断是否有此关
    public bool HandleIsHavePass(int index)
    {
        bool bl = (index < passData.Count);
        return bl;
    }
    public string GetPassStr(int index, string name)
    {
        return passData[index][name].ToString();
    }
    public string GetCurrPassStr(string name)
    {
        return passData[passCurr - 1][name].ToString();
    }
}
