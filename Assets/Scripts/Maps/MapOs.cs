/****************************************************************
 *Copyright(C)  2018 by Biubiubiu All rights reserved. 
 *FileName:     MapOs.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-28 15:19 
 *Description:  选关界面
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapOs : MonoBehaviour 
{
    public Transform[] Panels;
    public CanvasGroup canvasGroup;
    public GameObject[] btns;

    private MapCheckBtns[] CheckBtns = new MapCheckBtns[5];

    private static Vector3[] MAPCHECK_VEC3_VA = {
        new Vector3(-607, 0, 0), new Vector3(-303, -75, 0), new Vector3(-16, -45, 0),
        new Vector3(275, 29, 0), new Vector3(590, 14, 0)
    };

    private int currPage = 1;

    public SliderControl sliderControl;

    void Start()
    {
        RefreshBtns();
        LoadMapCheckBtn();
    }

    private void LoadMapCheckBtn()
    {
        GameObject go = Resources.Load("Prefabs/MapCheckBtn") as GameObject;
        for (int i = 0; i < 20; i++)
        {
            int page = i / 5;
            MapCheckBtns mapCheckBtns = Instantiate(go, Panels[page]).GetComponent<MapCheckBtns>();
            mapCheckBtns.transform.localPosition = MAPCHECK_VEC3_VA[i - page * 5];
            if(page == 0)
            {
                CheckBtns[i] = mapCheckBtns;
            }
            else
            {
                mapCheckBtns.canvasGroup.alpha = 1;
            }
            mapCheckBtns.OnCheck(i + 1);
        }
        EnterAnim();
    }

    public void LoadUI()
    {
        StartCoroutine(OnUICanvasGE());
    }
    IEnumerator OnUICanvasGE()
    {
        while (canvasGroup.alpha != 1)
        {
            canvasGroup.alpha = canvasGroup.alpha + 0.05f;
            yield return 0;
        }
    }

    private void EnterAnim()
    {
        StartCoroutine(CreateAllChip());
    }
    IEnumerator CreateAllChip()
    {
        for (int i = 0; i < 5; i++)
        {
            CheckBtns[i].Play(MAPCHECK_VEC3_VA[i], i, transform);
            yield return new WaitForSeconds(0.08f);
        }

    }

    private void RefreshBtns()
    {
        if(currPage == 1)
        {
            btns[0].SetActive(false);
        }
        else if(currPage == 4)
        {
            btns[1].SetActive(false);
        }
        else
        {
            btns[0].SetActive(true);
            btns[1].SetActive(true);
        }
    }

    public void BackClick()
    {
        Destroy(transform.gameObject);
        GameData.Instance.gameManagers.LoadMainO();
    }
    
    public void LeftClick()
    {
        currPage--;
        RefreshBtns();
        sliderControl.OnButtonClick(currPage);
    }

    public void RightClick()
    {
        currPage++;
        RefreshBtns();
        sliderControl.OnButtonClick(currPage);
    }
}
