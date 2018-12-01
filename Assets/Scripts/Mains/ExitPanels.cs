/****************************************************************
 *Copyright(C)  2018 by YYGame All rights reserved. 
 *FileName:     ExitPanels.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-22 17:41 
 *Description:  退出游戏界面
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanels : MonoBehaviour 
{
    public void YesClick()
    {
        Application.Quit();
    }

    public void NoClick()
    {
        Destroy(transform.gameObject);
    }
}
