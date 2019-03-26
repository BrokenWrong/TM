using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUIs : MonoBehaviour {
    public CanvasGroup canvasGroup;
    public GameManagers gameManagers;

    public GameObject LeftBtn;
    public GameObject RightBtn;

    public SoundOs soundOs;

    public GameObject SoundBtn;
    public GameObject SoundBtny;

    public GameObject Sp1Btn;
    public GameObject Sp2Btn;
    public GameObject Sp3Btn;

    // 当前观看状态 1 全图 2 裸图 3 动图
    private int currOpenType = 1;

    // 背景
    public Image BgImg;

    // 角色
    public Image RoleImg;

    // 角色动图层
    public RoleAnimOs roleAnimOs;

    public Plays plays;

    // 闪光
    public FlashLights flashLights;

    // 音量控制
    public Transform SoundHendle;

    // 音量控制弹窗
    public GameObject SoundVP;

    public void SetCanvasGroup(bool bl)
    {
        if(bl == true)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            bool lbl = (GameData.Instance.passCurr != 1);
            LeftBtn.SetActive(lbl);
            bool rbl = (GameData.Instance.passCurr != GameData.Instance.passMax && GameData.Instance.passCurr <= GameData.Instance.passAdopt);
            RightBtn.SetActive(rbl);

            if(/*GameData.Instance.isPatch == true && */GameData.Instance.IsPassSpotArr() == true)
            {
                Sp1Btn.SetActive(true);
                Sp2Btn.SetActive(true);
                Sp3Btn.SetActive(true);
            }
            else
            {
                Sp1Btn.SetActive(false);
                Sp2Btn.SetActive(false);
                Sp3Btn.SetActive(false);
            }

            if(currOpenType == 1)
            {
                SisplaySp1();
            }
            else if (currOpenType == 2)
            {
                SisplaySp2();
            }
            else if (currOpenType == 3)
            {
                SisplaySp3();
            }
        }
        else
        {
            CgrToSp1();
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    // 右键点击
    public void RightSetCanvasGroup(bool bl)
    {
        if (bl == true)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            bool lbl = (GameData.Instance.passCurr != 1);
            LeftBtn.SetActive(lbl);
            bool rbl = (GameData.Instance.passCurr != GameData.Instance.passMax && GameData.Instance.passCurr <= GameData.Instance.passAdopt);
            RightBtn.SetActive(rbl);

            if (/*GameData.Instance.isPatch == true && */GameData.Instance.IsPassSpotArr() == true)
            {
                Sp1Btn.SetActive(true);
                Sp2Btn.SetActive(true);
                Sp3Btn.SetActive(true);
            }
            else
            {
                Sp1Btn.SetActive(false);
                Sp2Btn.SetActive(false);
                Sp3Btn.SetActive(false);
            }
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
        soundOs.StopJisuiRSound();
        soundOs.StopDtSound();
        // 成就
        GameAchStatic.SetAchievement(33);
        GameAchStatic.SetAchievement(34);
        GameAchStatic.SetAchievement(35);

        gameManagers.CgClick();
    }

    public void SoundClick()
    {
        AddSoundVP();
    }

    public void AgainClick()
    {
        soundOs.StopJisuiRSound();
        soundOs.StopDtSound();
        // 成就
        GameAchStatic.SetAchievement(30);
        GameAchStatic.SetAchievement(31);
        GameAchStatic.SetAchievement(32);

        soundOs.PlaytBgSound();
        gameManagers.AgainClick();
    }

    private void CgrToSp1()
    {
        if (currOpenType == 1) return;
        currOpenType = 1;
        string str = GameData.Instance.GetCurrPassStr("roleImg");
        RoleImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;
        BgImg.enabled = true;
        RoleImg.enabled = true;

        roleAnimOs.transform.gameObject.SetActive(false);
    }

    public void Sp1Click()
    {
        if (currOpenType == 1) return;
        SisplaySp1();
    }
    private void SisplaySp1()
    {
        soundOs.PlayJisuiRSound();
        currOpenType = 1;
        string str = GameData.Instance.GetCurrPassStr("roleImg");
        RoleImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;
        BgImg.enabled = true;
        RoleImg.enabled = true;

        roleAnimOs.transform.gameObject.SetActive(false);
    }

    public void Sp2Click()
    {
        if (currOpenType == 2) return;
        SisplaySp2();
    }
    private void SisplaySp2()
    {
        soundOs.PlayDtSound();
        HideDishu();
        currOpenType = 2;
        string str = GameData.Instance.GetCurrPassStr("role3Img");
        RoleImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;
        BgImg.enabled = true;
        RoleImg.enabled = true;

        roleAnimOs.transform.gameObject.SetActive(false);
    }

    public void Sp3Click()
    {
        if (currOpenType == 3) return;

        flashLights.OnFlashImg();
        SisplaySp3();
    }
    private void SisplaySp3()
    {
        soundOs.PlayDtSound();
        HideDishu();
        currOpenType = 3;
        BgImg.enabled = false;
        RoleImg.enabled = false;

        roleAnimOs.transform.gameObject.SetActive(true);
        roleAnimOs.OnAnim();
    }

    // 隐藏地鼠快显示
    private void HideDishu()
    {
        plays.HideDishu();
    }

    public void OnLeftArrow()
    {
        bool lbl = (GameData.Instance.passCurr != 1);
        if (lbl == false) return;
        LeftClick();
    }
    public void OnRightArrow()
    {
        bool rbl = (GameData.Instance.passCurr != GameData.Instance.passMax && GameData.Instance.passCurr <= GameData.Instance.passAdopt);
        if (rbl == false) return;
        RightClick();
    }

    public void LeftClick()
    {
        if (GameData.Instance.passCurr == 1) return;
        /*if (GameData.Instance.isPatch == false)
        {
            SisplaySp1();
        }*/
        GameData.Instance.passCurr--;
        gameManagers.OnPlay();

        // 成就
        GameAchStatic.SetAchievement(36);
        GameAchStatic.SetAchievement(37);
    }

    public void RightClick()
    {
        if (GameData.Instance.passCurr == GameData.Instance.passMax) return;
        /*if (GameData.Instance.isPatch == false)
        {
            SisplaySp1();
        }*/
        GameData.Instance.passCurr++;
        if(GameData.Instance.IsPassChooseSpot(GameData.Instance.spotCurr))
        {
            GameData.Instance.spotCurr = GameData.Instance.GetPassChooseSpot();
        }
        gameManagers.OnPlay();

        // 成就
        GameAchStatic.SetAchievement(38);
        GameAchStatic.SetAchievement(39);
    }

    public void ExitClick()
    {
        Application.Quit();
    }

    public void SetCurrOpenType(int value)
    {
        currOpenType = value;
    }

    // 创建音量控制弹窗
    public void AddSoundVP()
    {
        Instantiate(SoundVP, SoundHendle);
    }
}
