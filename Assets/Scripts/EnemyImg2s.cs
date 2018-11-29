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

public class EnemyImg2s : MonoBehaviour 
{
    public Image img;

    public BoxCollider2D b2D;

    private bool isTouch;

    private Vector3 touchPos;

    private bool isPlay;

    public float timeF = 0;

    public float MaxX;

    public void OnEnemy(Vector3 vec3)
    {
        touchPos = vec3;
        transform.localPosition = Input.mousePosition - new Vector3(960, 540, 0);
        transform.localScale = new Vector3(0.01f, 0.01f, 0);
        img.enabled = true;
        b2D.enabled = true;
        isTouch = true;
        isPlay = true;
    }

    private void Awake()
    {
        isTouch = false;
        img.enabled = false;
        b2D.enabled = false;
        isPlay = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "B")
        {
            Destroy(transform.gameObject);
            //isTouch = false;
            //img.enabled = false;
            //b2D.enabled = false;
        }
    }
    void Update()
    {
        if (!isPlay) return;
        InputTouch();
        EnemyImg();
    }

    private void InputTouch()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    touchPos = Input.mousePosition;
        //    transform.localPosition = Input.mousePosition - new Vector3(960, 540, 0);
        //    transform.localScale = new Vector3(0.01f, 0.01f, 0);
        //    img.enabled = true;
        //    b2D.enabled = true;
        //    isTouch = true;
        //}
        //else 
        if (Input.GetMouseButtonUp(0))
        {
            isPlay = false;
            Invoke("Hide", timeF);
        }
    }

    private void Hide()
    {
        Destroy(transform.gameObject);
        //img.enabled = false;
        //b2D.enabled = false;
        //isTouch = false;
        //isPlay = true;
    }

    private void EnemyImg()
    {
        if (!isTouch) return;
        Vector3 vec3 = Input.mousePosition - touchPos;
        float r = GetAngle(vec3.x, vec3.y);
        transform.eulerAngles = new Vector3(0, 0, r);
        float x = GetScaleX(touchPos, Input.mousePosition);
        if(x > MaxX)
        {
            x = MaxX;
        }
        transform.localScale = new Vector3(x, 0.01f, 1);
    }

    private float GetAngle(float x, float y)
    {
        float a = Mathf.Atan2(y, x);
        float ret = a * 180 / Mathf.PI;
        if (ret > 360)
        {
            ret -= 360;
        }
        if (ret < 0)
        {
            ret += 360;
        }
        return ret;
    }

    private float GetScaleX(Vector3 vec1, Vector3 vec2)
    {
        float x = Mathf.Sqrt((vec1.x - vec2.x) * (vec1.x - vec2.x) + (vec1.y - vec2.y) * (vec1.y - vec2.y));
        x = 0.01f * x;
        return x;
    }
}
