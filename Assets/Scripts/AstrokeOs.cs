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

public class AstrokeOs : MonoBehaviour 
{
    public Transform BgO;
    public GameObject AstrokeBgImg;

    private int beginI = 4;

    private Vector3[] vec3A = new Vector3[]
    {
        new Vector3(0, 175, 0), new Vector3(175, 175, 0),
        new Vector3(-350, 0, 0), new Vector3(-175, 0, 0), new Vector3(0, 0, 0), new Vector3(175, 0, 0),
        new Vector3(-350, -175, 0), new Vector3(-175, -175, 0), new Vector3(0, -175, 0), new Vector3(175, -175, 0),
    };

    void Awake()
    {
    }

    void Start()
    {
        LoadAstrokeBgImg();
    }

    private void LoadAstrokeBgImg()
    {
        for (int i = 0; i < vec3A.Length; i++)
        {
            Transform tf = Instantiate(AstrokeBgImg, BgO).transform;
            tf.localPosition = vec3A[i];
        }
    }
}
