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

public class ImgOs : MonoBehaviour 
{
    public GameObject Btn1;
    public Image Img1;
    public Image Img2;
    public CanvasGroup canvasGroup;

    private PlayOs playOs;
    private int StartId;
    private int PosId;
    private int SpId;

    private float speed;
    private Vector3 moveVec3;
    private float alphaSpdde;

    void Awake()
    {
        speed = 5000;
        alphaSpdde = 0.01f;
    }

    public void OnImg(Transform tf, int posId, int spId)
    {
        playOs = tf.GetComponent<PlayOs>();
        StartId = posId;
        PosId = posId;
        SpId = spId;

        Btn1.GetComponent<Image>().sprite = Resources.Load("Textures/Pass/sp" + SpId, typeof(Sprite)) as Sprite;
    }

    public void BtnClick()
    {
        transform.SetAsLastSibling();
        playOs.CurrClickId(StartId);
    }

    public void Img2Enabled(bool bl)
    {
        Img2.enabled = bl;
    }

    public void Move(Vector3 vec3, int posId)
    {
        moveVec3 = vec3;
        PosId = posId;
        StartCoroutine("OnMove");
    }

    IEnumerator OnMove()
    {
        while (transform.localPosition != moveVec3)
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, moveVec3, speed * Time.deltaTime);
            yield return 0;
        }
        playOs.MoveCount++;
    }

    public int GetPosId()
    {
        return PosId;
    }

    public bool IsIdentical()
    {
        return PosId == SpId;
    }

    public void Hide()
    {
        StartCoroutine("OnHide");
    }

    IEnumerator OnHide()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= alphaSpdde;
            yield return 0;
        }
    }
}
