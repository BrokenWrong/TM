using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameData{
    private static GameData instance;
    public static GameData Instance()
    {
        if(instance == null)
        {
            instance = new GameData();
            instance.Init();
        }
        return instance;
    }

    // 关卡数
    public int passMax = 8;

    // 已通关关卡数
    public int passAdopt = 0;

    // 当前正在通关
    public int passCurr = 0;

    // 当前通关关卡选关点
    public ArrayList passChooseSpot = new ArrayList();

    // 当前正在通关的选关点
    public int spotCurr = 0;

    // 当前音效
    public bool isHaveSound = true;

    // 音乐
    public SoundOs soundOs;

    // 初始数据
    private JsonData initData;

    // 关卡数据
    private JsonData passData;

    // 初始化
    private void Init()
    {
        GetSaveFileData();
        ReadInitData();
        ReadPassData();
        InitGameData();
        //AddPassChooseSpot(0);
        //AddPassChooseSpot(1);
        //AddPassChooseSpot(2);
        //AddPassChooseSpot(3);
        //AddPassChooseSpot(4);
        //AddPassChooseSpot(5);
        //AddPassChooseSpot(6);
        //AddPassChooseSpot(7);
        //AddPassChooseSpot(8);
        //AddPassChooseSpot(9);
    }

    // 获取存档
    private void GetSaveFileData()
    {
        string[] strArr1 = new string[] { "passAdopt", "passChooseSpot", "isHaveSound" };
        string[] strArr2 = new string[] { "0", "n", "1"};
        Dictionary<string, string> dict = GameSaveData.ObtainData("save1_1", strArr1, strArr2);
        passAdopt = int.Parse(dict["passAdopt"]);
        isHaveSound = dict["isHaveSound"] == "1";
        string[] passChooseSpotA = dict["passChooseSpot"].Split(';');
        if (passChooseSpotA[0] == "n") return;
        for (int i = 0; i < passChooseSpotA.Length; i++)
        {
            passChooseSpot.Add(int.Parse(passChooseSpotA[i]));
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
        string[] strArr1 = new string[] { "passAdopt", "passChooseSpot", "isHaveSound" };
        string[] strArr2 = new string[] { passAdopt.ToString(), GetPassChooseSpotS(), isHaveSound ? "1" : "0" };
        GameSaveData.SaveData("save1_1", strArr1, strArr2);
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

    // 通关保存数据
    public void SaveData()
    {
        if (passCurr <= passAdopt) return;
        AddPassChooseSpot(spotCurr);
        passAdopt++;
        SaveFileData();
    }

    // initData
    private void ReadInitData()
    {
        StreamReader streamreader = new StreamReader(Application.dataPath + "/Resources/Config/InitData.json");
        JsonReader js = new JsonReader(streamreader);
        initData = JsonMapper.ToObject<JsonData>(js);
    }

    // passData
    private void ReadPassData()
    {
        StreamReader streamreader = new StreamReader(Application.dataPath + "/Resources/Config/PassData.json");
        JsonReader js = new JsonReader(streamreader);
        passData = JsonMapper.ToObject<JsonData>(js);
    }
    public Vector3 GetPinziPos(int index)
    {
        string[] strArr = passData[index]["pinziPos"].ToString().Split(',');
        return new Vector3(float.Parse(strArr[0]), float.Parse(strArr[1]), 0);
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
