﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plays : MonoBehaviour {
    public PlayUIs playUIs;
    private bool isUiEnabled = false;

    public GameObject[] FastImgs;
    public Image BgImg;
    public Image RoleImg;

    // 当前已打开遮挡快
    private int openShelter = 0;

    void Update()
    {
        MouseClick();
    }

    public void OnPlay()
    {
        openShelter = 0;
        bool bl = GameData.Instance().passCurr > GameData.Instance().passAdopt;
        for (int i = 0; i < FastImgs.Length; i++)
        {
            FastImgs[i].SetActive(bl);
            FastImgs[i].GetComponent<FastImgs>().InitDisplay();
        }
        isUiEnabled = !bl;
        playUIs.SetCanvasGroup(!bl);

        string str = "Textures/roles/" + GameData.Instance().passCurr.ToString() + "A";
        BgImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;
        str = "Textures/roles/" + GameData.Instance().passCurr.ToString() + "B";
        RoleImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;
    }

    public void AgainPlay()
    {
        openShelter = 0;
        for (int i = 0; i < FastImgs.Length; i++)
        {
            FastImgs[i].SetActive(true);
            FastImgs[i].GetComponent<FastImgs>().InitDisplay();
        }
        isUiEnabled = false;
        playUIs.SetCanvasGroup(false);

        string str = "Textures/roles/" + GameData.Instance().passCurr.ToString() + "A";
        BgImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;
        str = "Textures/roles/" + GameData.Instance().passCurr.ToString() + "B";
        RoleImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;
    }

    private void MouseClick()
    {
        if(Input.GetMouseButtonDown(1))
        {
            SetPlayUiEnabled();
        }
    }

    private void SetPlayUiEnabled()
    {
        isUiEnabled = !isUiEnabled;
        playUIs.SetCanvasGroup(isUiEnabled);
    }

    // 显示
    public void DisplayPlayUi()
    {
        isUiEnabled = true;
        playUIs.SetCanvasGroup(isUiEnabled);
    }

    public void AddOpenShelter()
    {
        openShelter++;
        if(openShelter == 9)
        {
            GameData.Instance().SaveData();
            DisplayPlayUi();
        }
    }
}
