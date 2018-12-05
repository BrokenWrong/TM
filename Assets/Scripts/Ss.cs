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

public class Ss : MonoBehaviour 
{
    public Transform target;//目标位置
    public float distance;//两个物体的距离
    void Start()
    {
        distance = Vector2.Distance(transform.position, target.position);
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, (distance / 1f) * Time.deltaTime);
    }
}
