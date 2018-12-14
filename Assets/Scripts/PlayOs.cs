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

public class PlayOs : MonoBehaviour 
{
    public GameObject ImgO;

    void Start()
    {
        int count = 1;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Transform tf = Instantiate(ImgO, transform).transform;
                tf.localPosition = new Vector3(-800 + j * 320, 405 - i * 270, 0);
                tf.Find("Img1").GetComponent<Image>().sprite = Resources.Load("Textures/sp" + count, typeof(Sprite)) as Sprite;
                count++;
            }
        }    
    }
}
