/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     CgObjects.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-27 11:11 
 *Description:  当前CG组
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CgObjects : MonoBehaviour
{
    private Transform cgPanels;

    public Image Image1;
    public Text CheckOut;
    public Text NameText;
    public GameObject CgBtn;
    public Image CgImg;
    public Button[] btns;
    public GameObject ImgOb;
    public Button[] pageBtns;
    public GameObject CGSeeO;

    private string[] cgImgSA;
    private int currCgI;
    private int pageI;
    private string currCheckStr;

    /// <summary>
    /// isEdge:true 上   false 下
    /// </summary>
    /// <param name="isEdge"></param>
    public void OnCg(bool isEdge, int check, int page, Transform tf)
    {
        cgPanels = tf;
        currCheckStr = check.ToString();
        if (!isEdge)
        {
            ResreshImage1();
            RefreshCgBtn();
        }
        CheckOut.text = currCheckStr;
        NameText.text = GameData.Instance.GetPassConfigStr(currCheckStr, "nameText");

        if (page == 0)
        {
            CgBtn.GetComponent<Button>().interactable = false;
            return;
        }
        cgImgSA = GameData.Instance.GetPassConfigSA(currCheckStr, "cgImg");
        currCgI = 0;
        RefreshCgImg();
        CgImg.gameObject.SetActive(true);
        pageI = page;
        RefreshBtns();
        btns[0].gameObject.SetActive(true);
        btns[1].gameObject.SetActive(true);
        ImgOb.SetActive(true);
        DisplayPageBtns();
        RefreshPageBtns(0);
    }

    private void ResreshImage1()
    {
        Image1.overrideSprite = Resources.Load("Textures/CGuis/Panel_cg_03", typeof(Sprite)) as Sprite;
    }
    private void RefreshCgBtn()
    {
        CgBtn.GetComponent<Image>().sprite = Resources.Load("Textures/CGuis/Btn_cg_02_01", typeof(Sprite)) as Sprite;
        Button btn = CgBtn.GetComponent<Button>();
        SpriteState state = btn.spriteState;
        state.highlightedSprite = Resources.Load("Textures/CGuis/Btn_cg_02_02", typeof(Sprite)) as Sprite;
        btn.spriteState = state;
    }
    private void RefreshCgImg()
    {
        CgImg.overrideSprite = Resources.Load("Textures/CGMenu/" + cgImgSA[currCgI], typeof(Sprite)) as Sprite;
    }
    private void RefreshBtns()
    {
        if(currCgI == 0)
        {
            btns[0].interactable = false;
            btns[1].interactable = (currCgI != pageI - 1);
        }
        else if(currCgI == pageI - 1)
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
    private void DisplayPageBtns()
    {
        for (int i = 0; i < pageI; i++)
        {
            pageBtns[i].gameObject.SetActive(true);
        }
    }
    private void RefreshPageBtns(int i)
    {
        pageBtns[currCgI].interactable = true;
        currCgI = i;
        pageBtns[currCgI].interactable = false;
    }

    public void OnBtnEnter()
    {
        btns[0].GetComponent<Image>().enabled = true;
        btns[1].GetComponent<Image>().enabled = true;
    }
    public void OnBtnExit()
    {
        btns[0].GetComponent<Image>().enabled = false;
        btns[1].GetComponent<Image>().enabled = false;
    }
    public void LeftClick()
    {
        RefreshPageBtns(currCgI - 1);
        RefreshBtns();
        RefreshCgImg();
    }
    public void RightClick()
    {
        RefreshPageBtns(currCgI + 1);
        RefreshBtns();
        RefreshCgImg();
    }
    public void PageBtnClick(int i)
    {
        RefreshPageBtns(i);
        RefreshBtns();
        RefreshCgImg();
    }
    public void CgBtnClick()
    {
        string bgFile = GameData.Instance.GetPassConfigStr(currCheckStr, "bgImg");
        Instantiate(CGSeeO, cgPanels).GetComponent<CGSeeOs>().OnCG(bgFile, currCheckStr, currCgI, pageI);
    }
}
