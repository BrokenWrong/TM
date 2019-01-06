using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plays : MonoBehaviour {
    public PlayUIs playUIs;
    private bool isUiEnabled = false;

    // 当前已打开遮挡快
    private int openShelter = 0;

    void Update()
    {
        MouseClick();
    }

    public void OnPlay()
    {
        //Debug.Log("onplay");
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
            SetPlayUiEnabled();
        }
    }
}
