/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     BattleUIOs.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-29 14:40 
 *Description:  ’Ω∂∑ΩÁ√ÊUI
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUIOs : MonoBehaviour 
{
    public void StopClick()
    {
        GameObject go = Resources.Load("Prefabs/StopPanel") as GameObject;
        Instantiate(go, transform);
    }
}
