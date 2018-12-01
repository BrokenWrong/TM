/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     CGSeeOs.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-28 14:25 
 *Description:  CG´óÍ¼¼øÉÍ
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGSeeOs : MonoBehaviour 
{
    public Image BgImg;
    public Image RoleImg;
    public CanvasGroup canvasGroup;
    public Button[] btns;

    private string[] bgRoleSA;
    private int currPageI;
    private int maxPageI;

    public void OnCG(string bgFile, string check, int currPage, int maxPage)
    {
        bgRoleSA = GameData.Instance.GetPassConfigSA(check.ToString(), "bgRole");
        currPageI = currPage;
        maxPageI = maxPage;

        BgImg.overrideSprite = Resources.Load("Textures/Bgs/" + bgFile, typeof(Sprite)) as Sprite;
        RefreshRoleImg();
        RefreshBtns();
    }

    private void RefreshRoleImg()
    {
        RoleImg.overrideSprite = Resources.Load("Textures/Roles/" + bgRoleSA[currPageI], typeof(Sprite)) as Sprite;
    }
    private void RefreshBtns()
    {
        if (currPageI == 0)
        {
            btns[0].interactable = false;
            btns[1].interactable = (currPageI != maxPageI - 1);
        }
        else if (currPageI == maxPageI - 1)
        {
            btns[1].interactable = false;
            btns[0].interactable = true;
        }
        else
        {
            btns[0].interactable = true;
            btns[1].interactable = true;
        }
    }

    public void BackClick()
    {
        Destroy(transform.gameObject);
    }
    public void OnEnter()
    {
        canvasGroup.alpha = 1;
    }
    public void OnExit()
    {
        canvasGroup.alpha = 0;
    }
    public void LeftClick()
    {
        currPageI--;
        RefreshBtns();
        RefreshRoleImg();
    }
    public void RightClick()
    {
        currPageI++;
        RefreshBtns();
        RefreshRoleImg();
    }
}
