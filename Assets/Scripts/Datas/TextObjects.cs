/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     TextObjects.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-26 16:41 
 *Description:    
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextObjects
{
    private static ArrayList textList = new ArrayList();

    public static void AddTextList(GameObject go)
    {
        textList.Add(go);
    }

    public static void RefreshText()
    {
        for (int i = textList.Count; i > 0; i--)
        {
            int index = i - 1;
            GameObject go = (GameObject)textList[index];
            if (go == null)
            {
                textList.RemoveAt(index);
            }
            else
            {
                go.GetComponent<LanguageText>().SetText();
            }
        }
    }
}
