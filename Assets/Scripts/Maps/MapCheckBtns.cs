/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     MapCheckBtns.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-28 16:10 
 *Description:  ¹Ø¿¨Ñ¡Ôñ°´Å¥
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCheckBtns : MonoBehaviour 
{
    private MapOs mapOs;

    public CanvasGroup canvasGroup;
    public Image BgImg;
    public Text LevelText;
    public Image StarImg;

    private bool isPlay = false;

    private Vector3 endVec3;
    private Vector3 moveVec3;
    private int count;
    private float speed = 0;
    private float add = 0;
    private bool isEnd;

    private int currCheck;

    public void OnCheck(int check)
    {
        currCheck = check;
        string checkStr = check.ToString();
        int isWin = GameData.Instance.PassData[check];
        string name = (isWin == 1) ? "nuImg" : "uImg";
        string file = GameData.Instance.GetPassConfigStr(checkStr, name);
        BgImg.overrideSprite = Resources.Load("Textures/CheckImg/" + file, typeof(Sprite)) as Sprite;

        LevelText.text = checkStr;

        if (isWin != 1)
        {
            file = (isWin == 4) ? "Textures/Maps/Icon_perfect_01" : "Textures/Maps/Icon_perfect_03";
            StarImg.overrideSprite = Resources.Load(file, typeof(Sprite)) as Sprite;
            StarImg.enabled = true;
            transform.GetComponent<Button>().interactable = true;
        }
    }

    private void RefresStarImg()
    {
    }

    void Update()
    {
        if (!isPlay) return;
        Move();
        if(canvasGroup.alpha < 1)
        {
            canvasGroup.alpha = canvasGroup.alpha + 0.06f;
        }
    }
    private void Move()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, moveVec3, (speed + add) * Time.deltaTime);
        add = add - 10;
        if(transform.localPosition.y == moveVec3.y)
        {
            isPlay = false;
            count++;
            SetMoveVec3();
        }
    }

    public void Play(Vector3 vec3, int i, Transform tf)
    {
        mapOs = tf.GetComponent<MapOs>();
        isEnd = (i == 4);
        endVec3 = vec3;
        count = 1;
        SetMoveVec3();
    }

    private void SetMoveVec3()
    {
        switch(count)
        {
            case 1:
                transform.localPosition -= new Vector3(0, 290, 0);
                moveVec3 = endVec3 + new Vector3(0, 110, 0);
                speed = 1800;
                add = 0;
                isPlay = true;
                break;
            case 2:
                moveVec3.y = moveVec3.y - 150;
                add = 0;
                isPlay = true;
                break;
            case 3:
                moveVec3 = endVec3;
                add = 0;
                isPlay = true;
                break;
            case 4:
                canvasGroup.alpha = 1;
                if (isEnd)
                {
                    mapOs.LoadUI();
                }
                break;
        }
    }

    public void MapCkeckClick()
    {
        GameData.Instance.CurrPlayCheck = currCheck;
        GameData.Instance.gameManagers.StartBattle();
    }
}
