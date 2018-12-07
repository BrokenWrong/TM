﻿/****************************************************************
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

public class KuaiOs : MonoBehaviour 
{
    private Vector3[] vec3VA = new Vector3[]
    {
        new Vector3(-244.5f, 373.5f, 0), new Vector3(-82.5f, 373.5f, 0), new Vector3(80f, 373.5f, 0), new Vector3(241.5f, 373.5f, 0),
        new Vector3(-244.5f, 212f, 0), new Vector3(-82.5f, 212f, 0), new Vector3(80f, 212f, 0), new Vector3(241.5f, 212f, 0),
        new Vector3(-244.5f, 49f, 0), new Vector3(-82.5f, 49f, 0), new Vector3(80f, 49f, 0), new Vector3(241.5f, 49f, 0),
        new Vector3(-244.5f, -113f, 0), new Vector3(-82.5f, -113f, 0), new Vector3(80f, -113f, 0), new Vector3(241.5f, -113f, 0)

    };

    private int[][] upArr = new int[][]
    {
        new int[]{ 0, 4, 8, 12 },
        new int[]{ 1, 5, 9, 13 },
        new int[]{ 2, 6, 10, 14 },
        new int[]{ 3, 7, 11, 15 }
    };
    private int[][] downArr = new int[][]
    {
        new int[]{ 12, 8, 4, 0 },
        new int[]{ 13, 9, 5, 1 },
        new int[]{ 14, 10, 6, 2 },
        new int[]{ 15, 11, 7, 3 }
    };
    private int[][] leftArr = new int[][]
    {
        new int[]{ 0, 1, 2, 3 },
        new int[]{ 4, 5, 6, 7 },
        new int[]{ 8, 9, 10, 11 },
        new int[]{ 12, 13, 14, 15 }
    };
    private int[][] rightArr = new int[][]
    {
        new int[]{ 3, 2, 1, 0 },
        new int[]{ 7, 6, 5, 4 },
        new int[]{ 11, 10, 9, 8 },
        new int[]{ 15, 14, 13, 12 }
    };
    private ArrayList listArr;


    public GameObject KuaiImg;
    private bool[] isHave;
    public Image[] BgImgs;

    private KuaiImgs[] kuaiImgsA;
    public int IsTouch { get; set; }

    private int touchI = -1;

    void Awake()
    {
        isHave = new bool[]
        {
            false, false, false, false,
            false, false, false, false,
            false, false, false, false,
            false, false, false, false
        };
        kuaiImgsA = new KuaiImgs[16];
        listArr = new ArrayList();
        listArr.Add(upArr);
        listArr.Add(downArr);
        listArr.Add(leftArr);
        listArr.Add(rightArr);

        IsTouch = 0;
    }

    void Start()
    {
        Begin();
        //LoadKuai(0);
        //LoadKuai(4);
        //LoadKuai(8);
        //LoadKuai(12);
        //Ss();
    }

    void Update()
    {
        InputKey();
    }

    private void InputKey()
    {
        if (IsTouch != 0) return;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            touchI = 0;
            IsTouch = 1;
            ToMove((int[][])listArr[touchI]);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            touchI = 1;
            IsTouch = 1;
            ToMove((int[][])listArr[touchI]);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            touchI = 2;
            IsTouch = 1;
            ToMove((int[][])listArr[touchI]);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            touchI = 3;
            IsTouch = 1;
            ToMove((int[][])listArr[touchI]);
        }
    }
    private void Ss()
    {
        for (int i = 0; i < isHave.Length; i++)
        {
            if (isHave[i])
                Debug.Log(i.ToString() + " : " + isHave[i]);
        }
    }

    private void ToMove(int[][] iArr)
    {
        ArrayList list = new ArrayList();
        for (int i = 0; i < iArr.Length; i++)
        {
            int index = 0;
            for (int j = 0; j < iArr[i].Length; j++)
            {
                if (isHave[iArr[i][j]])
                {
                    if(!isHave[iArr[i][index]] && j != index)
                    {
                        list.Add(iArr[i][j].ToString() + ";" + iArr[i][index].ToString());
                        isHave[iArr[i][j]] = false;
                        isHave[iArr[i][index]] = true;
                    }
                    index++;
                }
            }
        }
        if (list.Count == 0)
        {
            if(IsTouch == 1)
            {
                KuaiToAdd();
                return;
            }
            KuaiToEnd();
            return;
        }
        KuaiMove(list);
    }

    private void ToAdd(int[][] iArr)
    {
        ArrayList list = new ArrayList();
        for (int i = 0; i < iArr.Length; i++)
        {
            int index = 0;
            if(!isHave[iArr[i][index]])
            {
                continue;
            }
            for (int j = 1; j < iArr[i].Length; j++)
            {
                if(isHave[iArr[i][j]])
                {
                    if(isHave[iArr[i][index]])
                    {
                        if(kuaiImgsA[iArr[i][j]].GetNum() == kuaiImgsA[iArr[i][index]].GetNum())
                        {
                            list.Add(iArr[i][j].ToString() + ";" + iArr[i][index].ToString());
                            isHave[iArr[i][j]] = false;
                            isHave[iArr[i][index]] = true;
                            index++;
                            j++;
                        }
                        index++;
                    }
                }
            }
        }
        if (list.Count == 0)
        {
            KuaiToEnd();
            return;
        }
        KuaiAdd(list);
    }

    public void KuaiToAdd()
    {
        IsTouch = 2;
        ToAdd((int[][])listArr[touchI]);
    }
    public void KuaiToMove()
    {
        IsTouch = 3;
        ToMove((int[][])listArr[touchI]);
    }
    public void KuaiToEnd()
    {
        AddKuai();
        IsTouch = 0;
    }

    private void KuaiMove(ArrayList list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string[] arr = list[i].ToString().Split(';');
            int i1 = int.Parse(arr[0]);
            int i2 = int.Parse(arr[1]);
            kuaiImgsA[i1].Move(BgImgs[i2].transform, i == list.Count - 1, i1, false);
            kuaiImgsA[i2] = kuaiImgsA[i1];
        }
    }
    private void KuaiAdd(ArrayList list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string[] arr = list[i].ToString().Split(';');
            int i1 = int.Parse(arr[0]);
            int i2 = int.Parse(arr[1]);
            kuaiImgsA[i1].Add(BgImgs[i2].transform, i == list.Count - 1, i1, kuaiImgsA[i2].transform, true);
            kuaiImgsA[i2] = kuaiImgsA[i1];
        }
    }

    private void Begin()
    {
        int i1 = UnityEngine.Random.Range(0, 16);
        LoadKuai(i1);

        int i2 = UnityEngine.Random.Range(0, 16);
        if (isHave[i2])
        {
            i2 = (i2 + 1 == 16) ? i2 - 1 : i2 + 1;
        }
        LoadKuai(i2);
    }

    private void AddKuai()
    {
        ArrayList list = new ArrayList();
        for (int i = 0; i < isHave.Length; i++)
        {
            if (!isHave[i])
            {
                list.Add(i);
            }
        }
        if (list.Count == 0)
        {
            Debug.Log("end");
            return;
        }
        int index = UnityEngine.Random.Range(0, list.Count);
        LoadKuai((int)list[index]);
    }

    private void LoadKuai(int i)
    {
        isHave[i] = true;
        Transform tf = Instantiate(KuaiImg, transform).transform;
        tf.localPosition = vec3VA[i];
        tf.GetComponent<KuaiImgs>().OnKuai(i, transform);
        kuaiImgsA[i] = tf.GetComponent<KuaiImgs>();
    }
}
