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
    public int passAdopt = 5;

    // 当前正在通关
    public int passCurr = 0;

    // 当前通关关卡选关点
    public ArrayList passChooseSpot = new ArrayList();

    // 当前正在通关的选关点
    public int spotCurr = 0;

    // 初始化
    private void Init()
    {
        AddPassChooseSpot(0);
        AddPassChooseSpot(1);
        AddPassChooseSpot(2);
        AddPassChooseSpot(3);
        AddPassChooseSpot(4);
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
}
