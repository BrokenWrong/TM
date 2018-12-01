/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     ObstacleOs.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-30 17:10 
 *Description:  ’œ∞≠ŒÔ
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleOs : MonoBehaviour 
{
    public GameObject[] Obstacles;

    private Vector3[] zPosVA;
    private int[] zImgIA;

    void Awake()
    {
        zPosVA = GameData.Instance.GetPassConfigVA("zPos");
        zImgIA = GameData.Instance.GetPassConfigIA("zImg");
    }

    void Start()
    {
        LoadObstacle();
    }

    private void LoadObstacle()
    {
        for (int i = 0; i < zImgIA.Length; i++)
        {
            Transform tf = Instantiate(Obstacles[zImgIA[i]], transform).transform;
            tf.localPosition = zPosVA[i];
        }
    }
}
