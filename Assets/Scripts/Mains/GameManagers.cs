/****************************************************************
 *Copyright(C)  2018 by YYGame All rights reserved. 
 *FileName:     GameManagers.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-22 14:18 
 *Description:  ��Ϸ���߼�
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

    // ���ؿ�ʼ����
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

    // �����˳���Ϸ����
    public void LoadExitPanel()
    {
        GameObject go = Resources.Load("Prefabs/ExitPanel") as GameObject;
        Instantiate(go, UpCanvas);
    }

    // �������ý���
    public void LoadOptionO()
    {
        GameObject go = Resources.Load("Prefabs/OptionPanel") as GameObject;
        Instantiate(go, UpCanvas).GetComponent<OptionPanels>().OnOption(transform);
    }

    // ����CG����
    public void LoadCGO()
    {
        GameObject go = Resources.Load("Prefabs/CGPanel") as GameObject;
        Instantiate(go, UpCanvas);
    }

    // ����ѡ�ؽ���
    public void LoadMapO()
    {
        GameObject go = Resources.Load("Prefabs/MapO") as GameObject;
        MapO = Instantiate(go, UpCanvas);
    }
    private void DeleteMapO()
    {
        if (MapO) Destroy(MapO);
    }

    // ��ʼս��
    public void StartBattle()
    {
        DeleteMapO();
        LoadBattleO();
        LoadBattleUIO();
    }

    // ����ս������
    public void LoadBattleO()
    {
        GameObject go = Resources.Load("Prefabs/BattleO") as GameObject;
        BattleO = Instantiate(go, MainCanvas);
    }
    public void DeleteBattleO()
    {
        if (BattleO) Destroy(BattleO);
    }

    // ����ս������UI
    public void LoadBattleUIO()
    {
        GameObject go = Resources.Load("Prefabs/BattleUIO") as GameObject;
        BattleUIO = Instantiate(go, UpCanvas);
    }
    public void DeleteBattleUIO()
    {
        if (BattleUIO) Destroy(BattleUIO);
    }

    // �Ƴ�ս��
    public void RemoveBattle()
    {
        DeleteBattleO();
        DeleteBattleUIO();
    }
}
