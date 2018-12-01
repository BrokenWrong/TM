/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     EnemyOs.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-30 12:31 
 *Description:  Ä¿±êµã
 *History: 
*****************************************************************/

using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOs : MonoBehaviour 
{
    public GameObject[] Enemys;

    private Vector3[] ePosVA;
    private int[] eHpIA;
    private int[] eImgIA;

    void Awake()
    {
        ePosVA = GameData.Instance.GetPassConfigVA("ePos");
        eHpIA = GameData.Instance.GetPassConfigIA("eHp");
        eImgIA = GameData.Instance.GetPassConfigIA("eImg");
    }

    void Start()
    {
        LoadEnemys();
    }

    private void LoadEnemys()
    {
        for (int i = 0; i < eImgIA.Length; i++)
        {
            Transform tf = Instantiate(Enemys[eImgIA[i]], transform).transform;
            tf.localPosition = ePosVA[i];
        }
    }
}
