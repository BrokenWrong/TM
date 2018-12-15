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

    private ImgOs[] imgs;

    private int clickId1;
    private int clickId2;

    private int moveCount;

    private bool isPlay = false;

    private int[] IArr = new int[]
    {
        //12, 10, 6, 15, 8, 1, 19, 3, 14, 4, 7, 9, 17, 20, 11, 16, 21, 2, 18, 0, 22, 13, 5, 23
        1, 0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23
    };

    void Awake()
    {
        imgs = new ImgOs[24];
        clickId1 = -1;
        clickId2 = -1;
        moveCount = 0;
    }

    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < 100; i++)
            {
                int a = UnityEngine.Random.Range(0, 24);
                int b = UnityEngine.Random.Range(0, 24);
                int c = IArr[a];
                int d = IArr[b];
                IArr[a] = d;
                IArr[b] = c;
            }
            string str = IArr[0].ToString();
            for (int i = 1; i < IArr.Length; i++)
            {
                str = str + ", " + IArr[i];
            }
            Debug.Log(str);
        }*/
    }

    void Start()
    {
        int count = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Transform tf = Instantiate(ImgO, transform).transform;
                tf.localPosition = new Vector3(-800 + j * 320, 405 - i * 270, 0);

                imgs[count] = tf.GetComponent<ImgOs>();
                imgs[count].OnImg(transform, count, IArr[count]);

                count++;
            }
        }    
        isPlay = true;
    }

    public void CurrClickId(int id)
    {
        if (!isPlay) return;
        if(clickId1 == -1)
        {
            clickId1 = id;
            imgs[clickId1].Img2Enabled(true);
        }
        else if(clickId2 == -1)
        {
            clickId2 = id;
            ImgMove();
        }
    }

    private void ImgMove()
    {
        isPlay = false;

        Vector3 vec1 = imgs[clickId1].transform.localPosition;
        Vector3 vec2 = imgs[clickId2].transform.localPosition;
        int posId1 = imgs[clickId1].GetPosId();
        int posId2 = imgs[clickId2].GetPosId();
        imgs[clickId1].Img2Enabled(false);
        imgs[clickId1].Move(vec2, posId2);
        imgs[clickId2].Move(vec1, posId1);
    }

    private void HandleMoveCount()
    {
        if (moveCount != 2) return;
        moveCount = 0;
        clickId1 = -1;
        clickId2 = -1;

        bool bl = true;
        for (int i = 0; i < imgs.Length; i++)
        {
            if(!imgs[i].IsIdentical())
            {
                bl = false;
            }
        }

        if(!bl)
        {
            isPlay = true;
        }
        else
        {
            Hide();
        }

    }

    private void Hide()
    {
        for (int i = 0; i < imgs.Length; i++)
        {
            imgs[i].Hide();
        }
    }

    public int MoveCount
    {
        get
        {
            return moveCount;
        }
        set
        {
            moveCount = value;
            HandleMoveCount();
        }
    }
}
