using System.Collections;
using System.Collections.Generic;
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
    public int passMax = 10;

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

    // 初始化
    private void Init()
    {
        GetSaveFileData();
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
}
