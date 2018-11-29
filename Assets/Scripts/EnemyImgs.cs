/****************************************************************
 *Copyright(C)  2018 by #COMPANY# All rights reserved. 
 *FileName:     #SCRIPTFULLNAME# 
 *Author:       Wen
 *Version:      #VERSION# 
 *UnityVersion: #UNITYVERSION# 
 *Date:         #DATE# 
 *Description:    
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyImgs : MonoBehaviour 
{
    public Text textE;
    public int hp;

    void Start()
    {
        UpdateTextE();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "B")
        {
            hp--;
            UpdateTextE();
        }
    }

    private void UpdateTextE()
    {
        textE.text = hp.ToString();
        if(hp <= 0)
        {
            Destroy(transform.gameObject);
        }
    }
}
