/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     BattleOs.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-29 14:28 
 *Description:  ’Ω∂∑ΩÁ√Ê
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleOs : MonoBehaviour 
{
    public Image BgImg;
    public Image RoleImg;

    private string[] bgRoleSA;

    void Awake()
    {
        bgRoleSA = GameData.Instance.GetPassConfigSA("bgRole");
    }

    void Start()
    {
        LoadUI();
    }

    private void LoadUI()
    {
        RefreshBgImg();
        RefreshRoleImg(1);
    }

    private void RefreshBgImg()
    {
        string file = "Textures/Bgs/" + GameData.Instance.GetPassConfigStr("bgImg");
        BgImg.overrideSprite = Resources.Load(file, typeof(Sprite)) as Sprite;
    }
    private void RefreshRoleImg(int index)
    {
        string file = "Textures/Roles/" + bgRoleSA[index];
        RoleImg.overrideSprite = Resources.Load(file, typeof(Sprite)) as Sprite;
    }
}
