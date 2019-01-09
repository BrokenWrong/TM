using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUIs : MonoBehaviour {
    public CanvasGroup canvasGroup;
    public GameManagers gameManagers;

    public GameObject LeftBtn;
    public GameObject RightBtn;

    public SoundOs soundOs;

    public GameObject SoundBtn;
    public GameObject SoundBtny;

    public void SetCanvasGroup(bool bl)
    {
        if(bl == true)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            bool lbl = (GameData.Instance().passCurr != 1);
            LeftBtn.SetActive(lbl);
            bool rbl = (GameData.Instance().passCurr != 10 && GameData.Instance().passCurr <= GameData.Instance().passAdopt);
            RightBtn.SetActive(rbl);
            RefreshSoundBtn();
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void MenuClick()
    {
        Debug.Log("Menu");
    }

    public void CgClick()
    {
        soundOs.PlayBtnSound();
        gameManagers.CgClick();
    }

    public void SoundClick()
    {
        GameData.Instance().isHaveSound = !GameData.Instance().isHaveSound;
        GameData.Instance().SaveFileData();
        RefreshSoundBtn();
    }
    private void RefreshSoundBtn()
    {
        SoundBtn.SetActive(!GameData.Instance().isHaveSound);
        SoundBtny.SetActive(GameData.Instance().isHaveSound);
    }

    public void AgainClick()
    {
        soundOs.PlayBtnSound();
        gameManagers.AgainClick();
    }

    public void Sp1Click()
    {

    }

    public void Sp2Click()
    {

    }

    public void Sp3Click()
    {

    }

    public void LeftClick()
    {
        if (GameData.Instance().passCurr == 1) return;
        soundOs.PlayBtnSound();
        GameData.Instance().passCurr--;
        gameManagers.OnPlay();
    }

    public void RightClick()
    {
        if (GameData.Instance().passCurr == 10) return;
        soundOs.PlayBtnSound();
        GameData.Instance().passCurr++;
        if(GameData.Instance().IsPassChooseSpot(GameData.Instance().spotCurr))
        {
            GameData.Instance().spotCurr = GameData.Instance().GetPassChooseSpot();
        }
        gameManagers.OnPlay();
    }
}
