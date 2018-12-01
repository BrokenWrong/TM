/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     CGSliderControl.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-26 19:00 
 *Description:  CG界面翻页
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGSliderControl : MonoBehaviour 
{
    public Scrollbar m_Scrollbar;

    private float mTargetValue;

    private bool mNeedMove = false;

    private const float MOVE_SPEED = 1F;

    private const float SMOOTH_TIME = 0.2F;

    private float mMoveSpeed = 0f;

    private bool isClick;

    public Button[] btns;

    private int btnValue;

    void Start()
    {
        isClick = false;
        btnValue = 0;
        SetBtnInteractable(0);
    }

    public void OnPointerDown()
    {
        mNeedMove = false;
    }

    public void OnPointerUp()
    {
        // 判断当前位于哪个区间，设置自动滑动至的位置
        if (m_Scrollbar.value <= 0.25f)
        {
            mTargetValue = 0;
            SetBtnInteractable(0);
        }
        else if (m_Scrollbar.value <= 0.75f)
        {
            mTargetValue = 0.5f;
            SetBtnInteractable(1);
        }
        else
        {
            mTargetValue = 1f;
            SetBtnInteractable(2);
        }

        mNeedMove = true;
        mMoveSpeed = 0;
    }

    public void OnButtonClick(int value)
    {
        SetBtnInteractable(value);
        isClick = true;
        switch (value)
        {
            case 0:
                mTargetValue = 0;
                break;
            case 1:
                mTargetValue = 0.5f;
                break;
            case 2:
                mTargetValue = 1;
                break;
        }
        mNeedMove = true;
    }

    private void SetBtnInteractable(int value)
    {
        btns[btnValue].interactable = true;
        btnValue = value;
        btns[btnValue].interactable = false;
    }

    private void KeyBoardInput()
    {
        //if (!GameInputStatic.IS_CG_PAGE) return;
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    OnButtonClick(btnValue == 0 ? 0 : btnValue - 1);
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    OnButtonClick(btnValue == 2 ? 2 : btnValue + 1);
        //}
    }

    void Update()
    {
        //KeyBoardInput();

        if (Input.GetMouseButtonUp(0) && !isClick)
        {
            OnPointerUp();
        }
        if (mNeedMove)
        {
            if (Mathf.Abs(m_Scrollbar.value - mTargetValue) < 0.01f)
            {
                m_Scrollbar.value = mTargetValue;
                mNeedMove = false;
                isClick = false;
                return;
            }
            m_Scrollbar.value = Mathf.SmoothDamp(m_Scrollbar.value, mTargetValue, ref mMoveSpeed, SMOOTH_TIME, 10, 0.016f);
        }
    }
}
