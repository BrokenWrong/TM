/****************************************************************
 *Copyright(C)  2018 by YYGame All rights reserved. 
 *FileName:     MainOs.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-22 17:05 
 *Description:  游戏开始界面
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainOs : MonoBehaviour 
{
    public CanvasGroup canvasGroup;
    public float speed = 0;

    public Image BtnDownImg;
    private Vector3[] btnVec3;

    private GameManagers gameManagers;

    void Awake()
    {
        btnVec3 = new Vector3[] {
            new Vector3(744, 207, 0), new Vector3(744, 121.5f, 0),
            new Vector3(744, 40.5f, 0), new Vector3(744, -40.5f, 0)
        };
    }

    public void OnMain(Transform tf)
    {
        gameManagers = tf.GetComponent<GameManagers>();
    }

    void Start()
    {
        gameManagers.soundOs.PlayBgm(0);
        StartCoroutine("Display");
    }

    IEnumerator Display()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += speed;
            yield return 0;
        }
    }

    public void OnBtnEnterListener(int i)
    {
        BtnDownImg.transform.localPosition = btnVec3[i];
        BtnDownImg.enabled = true;
    }
    public void OnBtnExitListener()
    {
        BtnDownImg.enabled = false;
    }

    public void PlayClick()
    {
        gameManagers.DeleteMainO();
        gameManagers.LoadMapO();
    }

    public void CGClick()
    {
        gameManagers.LoadCGO();
    }

    public void OptionClick()
    {
        gameManagers.LoadOptionO();
    }

    public void ExitClick()
    {
        gameManagers.LoadExitPanel();
    }
}
