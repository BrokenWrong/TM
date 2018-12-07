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

public class KuaiImgs : MonoBehaviour 
{
    public int id;
    public Text NumText;
    public int num = 2;

    private KuaiOs kuaiOs;

    private Transform target;
    private bool isMove = false;
    private float speed = 0.05f;
    private float distance;
    private bool isTouch = false;

    public void OnKuai(int index, Transform tf)
    {
        kuaiOs = tf.GetComponent<KuaiOs>();
        id = index;

        UpDateTextLevel();
    }

    private void UpDateTextLevel()
    {
        NumText.text = num.ToString();
    }

    public void Move(Transform tf, bool bl, int i)
    {
        id = i;
        isTouch = bl;
        target = tf;
        distance = Vector2.Distance(transform.localPosition, target.localPosition);
        isMove = true;
    }

    void Update()
    {
        OnMove();
    }
    private void OnMove()
    {
        if (!isMove) return;
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, target.localPosition, (distance / speed) * Time.deltaTime);
        if (transform.localPosition == target.localPosition)
        {
            isMove = false;
            if (isTouch)
            {
                kuaiOs.IsTouch = true;
            }
        }
    }

    public int GetNum()
    {
        return num;
    }
    public void SetNum()
    {
        num = num * 2;
        Debug.Log(num);
    }
}
