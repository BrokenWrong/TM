/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     ClothesOs.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-30 17:45 
 *Description:  ÒÂ·þ
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesOs : MonoBehaviour 
{
    public GameObject ClothesImg;

    private string[] ePngSA;

    void Awake()
    {
        ePngSA = GameData.Instance.GetPassConfigSA("ePng");
    }

    void Start()
    {
        LoadClothes();
    }

    private void LoadClothes()
    {
        for (int i = 0; i < ePngSA.Length; i++)
        {
            GameObject go = Instantiate(ClothesImg, transform);
            go.GetComponent<Image>().overrideSprite = Resources.Load("Textures/Roles/" + ePngSA[i], typeof(Sprite)) as Sprite;
        }
    }
}
