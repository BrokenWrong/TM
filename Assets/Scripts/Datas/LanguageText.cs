/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     LanguageText.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-26 16:43 
 *Description:    
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageText : MonoBehaviour 
{
    public string nameStr;
    private Text text;

    void Awake()
    {
        TextObjects.AddTextList(transform.gameObject);
        text = transform.GetComponent<Text>();
        SetText();
    }

    public void SetText()
    {
        text.text = GameData.Instance.GetLanguageStr(nameStr);
    }

    public string NameStr
    {
        get
        {
            return nameStr;
        }
        set
        {
            nameStr = value;
            SetText();
        }
    }
}
