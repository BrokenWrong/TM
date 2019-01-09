/****************************************************************
 *Copyright(C)  2018 by YYGame All rights reserved. 
 *FileName:     CanvasScreen.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-22 15:37 
 *Description:  画布规模与屏幕分辨率适配
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScreen : MonoBehaviour 
{
    // 游戏分辨率
    private float width = 1920f;
    private float height = 1080f;

    private void Awake()
    {
        UpDateCanvasScreen();
    }

    public void UpDateCanvasScreen()
    {
        Vector3 vec3 = transform.localScale;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        vec3.x = vec3.y * (screenWidth / screenHeight) / (width / height);
        transform.localScale = vec3;
    }
}
