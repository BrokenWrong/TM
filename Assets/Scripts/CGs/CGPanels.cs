/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     CGPanels.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-26 19:04 
 *Description:  CGº¯…ÕΩÁ√Ê
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGPanels : MonoBehaviour 
{
    // ¥Ê∑≈CG
    public Transform[] PanelTf;

    private static Vector3[] CGIMG_VEC3_VA = {
        new Vector3(-660, 163, 0), new Vector3(-220, 163, 0), new Vector3(220, 163, 0),
        new Vector3(660, 163, 0), new Vector3(-660, -170, 0), new Vector3(-220, -170, 0),
        new Vector3(220, -170, 0), new Vector3(660, -170, 0)
    };

    private Dictionary<int, int> CgData = new Dictionary<int, int>();

    void Awake()
    {
        CgDataInfo();
    }

    private void CgDataInfo()
    {
        for (int i = 0; i < 20; i++)
        {
            CgData[i + 1] = 0;
        }
        for (int i = 0; i < 20; i++)
        {
            int check = i + 1;
            int value = GameData.Instance.PassData[check];
            if(value == 4)
            {
                CgData[check] = 3;
            }
            else if(value == 3)
            {
                CgData[check] = 1;
                return;
            }
            else if (value == 1 || value == 2) return;
        }
    }

    void Start()
    {
        CreateCgObject();
    }

    private void CreateCgObject()
    {
        GameObject go = Resources.Load("Prefabs/CgObject") as GameObject;
        int count = 1;
        for (int i = 0; i < 20; i++)
        {
            Transform tf = Instantiate(go, PanelTf[i / 8]).transform;
            tf.localPosition = CGIMG_VEC3_VA[count - 1];

            bool isEdge = count <= 4;
            int check = i + 1;
            tf.GetComponent<CgObjects>().OnCg(isEdge, check, CgData[check], transform);

            count = (count == 8) ? 1 : count + 1;
        }
    }

    public void BackClick()
    {
        Destroy(transform.gameObject);
    }
}
