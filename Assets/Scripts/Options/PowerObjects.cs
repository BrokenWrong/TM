/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     PowerObjects.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-26 17:36 
 *Description:  фад╩дёй╫
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerObjects : MonoBehaviour 
{
    public LanguageText TableText;

    void Start()
    {
        TableText.NameStr = (GameData.Instance.ScreenMode) ? "full screen" : "window";
    }

    public void Click()
    {
        GameData.Instance.ScreenMode = !GameData.Instance.ScreenMode;
        TableText.NameStr = (GameData.Instance.ScreenMode) ? "full screen" : "window";
    }
}
