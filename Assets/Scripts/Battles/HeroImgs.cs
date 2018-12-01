/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     HeroImgs.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-29 18:43 
 *Description:  Çò
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroImgs : MonoBehaviour 
{
    public Rigidbody2D r2D;
    public Vector2 vec2 = new Vector2(0, 0);

    void Start()
    {
        r2D.velocity = vec2;
    }

    void Update()
    {
        UpdateR2d();
    }

    private void UpdateR2d()
    {
        float x = (r2D.velocity.x > 0) ? vec2.x : -vec2.x;
        float y = (r2D.velocity.y > 0) ? vec2.y : -vec2.y;
        r2D.velocity = new Vector2(x, y);
    }
}
