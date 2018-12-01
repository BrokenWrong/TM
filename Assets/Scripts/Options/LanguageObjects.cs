/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     LanguageObjects.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-26 17:41 
 *Description:  ”Ô—‘…Ë÷√
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageObjects : MonoBehaviour 
{
    public void LeftClick()
    {
        GameData.Instance.Language = (GameData.Instance.Language == 0) ? 25 : GameData.Instance.Language - 1;
        TextObjects.RefreshText();
    }

    public void RightClick()
    {
        GameData.Instance.Language = (GameData.Instance.Language == 25) ? 0 : GameData.Instance.Language + 1;
        TextObjects.RefreshText();
    }
}
