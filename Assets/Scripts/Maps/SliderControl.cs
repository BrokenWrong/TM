/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     SliderControl.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-28 15:31 
 *Description:  选关界面翻页
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour 
{
    public Scrollbar m_Scrollbar;

    private float mTargetValue;

    private bool mNeedMove = false;

    private const float MOVE_SPEED = 1F;

    private const float SMOOTH_TIME = 0.2F;

    private float mMoveSpeed = 0f;

    private bool isClick;

    private float basicsValue = 1f / 6f;

    void Start()
    {
        isClick = false;
    }

    public void OnPointerDown()
    {
        mNeedMove = false;
    }

    public void OnPointerUp()
    {
        // 判断当前位于哪个区间，设置自动滑动至的位置
        if (m_Scrollbar.value <= basicsValue)
        {
            mTargetValue = 0;
        }
        else if (m_Scrollbar.value <= basicsValue * 3)
        {
            mTargetValue = basicsValue * 2;
        }
        else if (m_Scrollbar.value <= basicsValue * 5)
        {
            mTargetValue = basicsValue * 4;
        }
        else
        {
            mTargetValue = 1f;
        }

        mNeedMove = true;
        mMoveSpeed = 0;
    }

    public void OnButtonClick(int value)
    {
        isClick = true;
        switch (value)
        {
            case 1:
                mTargetValue = 0;
                break;
            case 2:
                mTargetValue = basicsValue * 2;
                break;
            case 3:
                mTargetValue = basicsValue * 4;
                break;
            case 4:
                mTargetValue = 1f;
                break;
        }
        mNeedMove = true;
    }

    void Update()
    {
        if (!isClick)
        {
            //OnPointerUp();
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
            m_Scrollbar.value = Mathf.SmoothDamp(m_Scrollbar.value, mTargetValue, ref mMoveSpeed, SMOOTH_TIME);
        }
    }
}
