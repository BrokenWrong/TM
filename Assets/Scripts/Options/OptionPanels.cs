/****************************************************************
 *Copyright(C)  2018 by YYGame All rights reserved. 
 *FileName:     OptionPanels.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-22 18:38 
 *Description:  …Ë÷√ΩÁ√Ê
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanels : MonoBehaviour 
{
    private GameManagers gameManagers;

    public void OnOption(Transform tf)
    {
        gameManagers = tf.GetComponent<GameManagers>();
    }

    public void BackClick()
    {
        GameData.Instance.SaveData();
        Destroy(transform.gameObject);
    }

    public void SetBgmVolume()
    {
        gameManagers.soundOs.SetBgBgmVolume();
    }

    public void SetEffVolume()
    {
        gameManagers.soundOs.SetBtnEffVolume();
    }
}
