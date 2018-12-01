/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     BgmObjects.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-26 16:40 
 *Description:  ±≥æ∞“Ù¿÷“Ù¡ø
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmObjects : MonoBehaviour 
{
    public OptionPanels optionPanels;

    public Slider SoundSlider;

    void Start()
    {
        SoundSlider.value = GameData.Instance.BgmValue;
    }

    public void SoundSliderClick()
    {
        GameData.Instance.BgmValue = SoundSlider.value;
        optionPanels.SetBgmVolume();
    }

    public void LeftClick()
    {
        SoundSlider.value -= 0.1f;
        SoundSliderClick();
    }

    public void RightClick()
    {
        SoundSlider.value += 0.1f;
        SoundSliderClick();
    }
}
