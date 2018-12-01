/****************************************************************
 *Copyright(C)  2018 by YYGame All rights reserved. 
 *FileName:     GameManagers.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-22 14:18 
 *Description:  游戏主逻辑
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour 
{
    public SoundOs soundOs;
    public Transform MainCanvas;
    public Transform UpCanvas;

    private GameObject MainO;
    private GameObject MapO;
    private GameObject BattleO;
    private GameObject BattleUIO;

    void Start()
    {
        GameData.Instance.Init(transform);
        soundOs.OnStart();
        LoadMainO();
    }

    // 加载开始界面
    public void LoadMainO()
    {
        GameObject go = Resources.Load("Prefabs/MainO") as GameObject;
        MainO = Instantiate(go, MainCanvas);
        MainO.GetComponent<MainOs>().OnMain(transform);
    }
    public void DeleteMainO()
    {
        if (MainO) Destroy(MainO);
    }

    // 加载退出游戏界面
    public void LoadExitPanel()
    {
        GameObject go = Resources.Load("Prefabs/ExitPanel") as GameObject;
        Instantiate(go, UpCanvas);
    }

    // 加载设置界面
    public void LoadOptionO()
    {
        GameObject go = Resources.Load("Prefabs/OptionPanel") as GameObject;
        Instantiate(go, UpCanvas).GetComponent<OptionPanels>().OnOption(transform);
    }

    // 加载CG界面
    public void LoadCGO()
    {
        GameObject go = Resources.Load("Prefabs/CGPanel") as GameObject;
        Instantiate(go, UpCanvas);
    }

    // 加载选关界面
    public void LoadMapO()
    {
        GameObject go = Resources.Load("Prefabs/MapO") as GameObject;
        MapO = Instantiate(go, UpCanvas);
    }
    private void DeleteMapO()
    {
        if (MapO) Destroy(MapO);
    }

    // 开始战斗
    public void StartBattle()
    {
        DeleteMapO();
        LoadBattleO();
        LoadBattleUIO();
    }

    // 加载战斗界面
    public void LoadBattleO()
    {
        GameObject go = Resources.Load("Prefabs/BattleO") as GameObject;
        BattleO = Instantiate(go, MainCanvas);
    }
    public void DeleteBattleO()
    {
        if (BattleO) Destroy(BattleO);
    }

    // 加载战斗界面UI
    public void LoadBattleUIO()
    {
        GameObject go = Resources.Load("Prefabs/BattleUIO") as GameObject;
        BattleUIO = Instantiate(go, UpCanvas);
    }
    public void DeleteBattleUIO()
    {
        if (BattleUIO) Destroy(BattleUIO);
    }

    // 移除战斗
    public void RemoveBattle()
    {
        DeleteBattleO();
        DeleteBattleUIO();
    }
}
