/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     StopPanels.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-29 15:20 
 *Description:  ‘›Õ£ΩÁ√Ê
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPanels : MonoBehaviour 
{
    private GameManagers gameManagers;

    void Awake()
    {
        gameManagers = GameData.Instance.gameManagers;
    }

    public void BackClick()
    {
        Destroy(transform.gameObject);
    }

    public void ResetClick()
    {
        gameManagers.RemoveBattle();
        gameManagers.StartBattle();
    }

    public void CGClick()
    {
        gameManagers.LoadCGO();
    }

    public void OptionsClick()
    {
        gameManagers.LoadOptionO();
    }

    public void ReturnClick()
    {
        gameManagers.RemoveBattle();
        gameManagers.LoadMapO();
    }
}
