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
    private Transform kuaiImgs;

    private Transform target;
    private bool isMove = false;
    private float speed = 0.05f;
    private float distance;
    private bool isTouch = false;
    private bool isDelete = false;

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

    public void Move(Transform tf, bool bl, int i, bool de)
    {
        id = i;
        isTouch = bl;
        target = tf;
        isDelete = de;
        distance = Vector2.Distance(transform.localPosition, target.localPosition);
        isMove = true;
    }

    public void Add(Transform tf, bool bl, int i, Transform k, bool de)
    {
        id = i;
        isTouch = bl;
        target = tf;
        kuaiImgs = k;
        isDelete = de;
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
            if(kuaiOs.IsTouch == 2 && isDelete)
            {
                Destroy(kuaiImgs.gameObject);
                num = num * 2;
                UpDateTextLevel();
            }
            if(isTouch == true)
            {
                isTouch = false;
                switch (kuaiOs.IsTouch)
                {
                    case 1:
                        kuaiOs.KuaiToAdd();
                        break;
                    case 2:
                        kuaiOs.KuaiToMove();
                        break;
                    case 3:
                        kuaiOs.KuaiToEnd();
                        break;
                }
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
    }
}
