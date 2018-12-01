/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     PlayCurrencyBtnEff.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-26 18:18 
 *Description:  ����ͨ�ð�ť�����Ч
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayCurrencyBtnEff : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    private Button btn;
    private SoundOs soundOs;

    void Awake()
    {
        btn = transform.GetComponent<Button>();
        soundOs = GameData.Instance.gameManagers.soundOs;
    }

    // ������ʱ
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!btn.interactable) return;
        soundOs.PlayCurrencyBtnEff(0);
    }

    // �����ʱ
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!btn.interactable) return;
        soundOs.PlayCurrencyBtnEff(1);
    }
}
