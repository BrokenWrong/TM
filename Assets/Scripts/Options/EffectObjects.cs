/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     EffectObjects.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-26 17:32 
 *Description:  “Ù–ß“Ù¡ø
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectObjects : MonoBehaviour 
{
    public OptionPanels optionPanels;

    public Slider SoundSlider;

    void Start()
    {
        SoundSlider.value = GameData.Instance.EffValue;
    }

    public void SoundSliderClick()
    {
        GameData.Instance.EffValue = SoundSlider.value;
        optionPanels.SetEffVolume();
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
