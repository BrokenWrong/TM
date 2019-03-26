using System.Collections;
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

    public Scores scores;

    public SoundOs soundOs;

    // 地鼠第二玩法
    public FastTwos fastTwos;

    void Update()
    {
        MouseClick();
    }

    private void PlayBattleSound()
    {
        int index = UnityEngine.Random.Range(13, 16);
        soundOs.PlayBgSound(index);
    }

    public void OnPlay()
    {
        // 播放音乐
        PlayBattleSound();
        openShelter = 0;
        bool bl = GameData.Instance.passCurr > GameData.Instance.passAdopt;
        for (int i = 0; i < FastImgs.Length; i++)
        {
            FastImgs[i].SetActive(bl);
            FastImgs[i].GetComponent<FastImgs>().InitDisplay();
        }
        isUiEnabled = !bl;

        string str = GameData.Instance.GetCurrPassStr("bgImg");
        BgImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;
        str = GameData.Instance.GetCurrPassStr("roleImg");
        RoleImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;

        playUIs.SetCanvasGroup(!bl);

        // 进战斗界面刷新分数显示
        scores.Refresh(!bl);
    }
    public void OnPlay(int i)
    {
        OnPlay();
        switch (i)
        {
            case 1:
                playUIs.Sp1Click();
                break;
            case 2:
                playUIs.Sp2Click();
                break;
            case 3:
                playUIs.Sp3Click();
                break;
        }
    }

    public void AgainPlay()
    {
        openShelter = 0;
        fastTwos.SetIsPlay(false);
        for (int i = 0; i < FastImgs.Length; i++)
        {
            FastImgs[i].SetActive(true);
            FastImgs[i].GetComponent<FastImgs>().InitDisplay();
        }
        isUiEnabled = false;
        playUIs.SetCanvasGroup(false);

        string str = GameData.Instance.GetCurrPassStr("bgImg");
        BgImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;
        str = GameData.Instance.GetCurrPassStr("roleImg");
        RoleImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;

        // 重新开始刷新分数
        scores.Init();
    }

    // 隐藏地鼠快显示
    public void HideDishu()
    {
        fastTwos.SetIsPlay(false);
        for (int i = 0; i < FastImgs.Length; i++)
        {
            FastImgs[i].SetActive(false);
            FastImgs[i].GetComponent<FastImgs>().InitDisplay();
        }
    }

    private void MouseClick()
    {
        if(Input.GetMouseButtonDown(1))
        {
            SetPlayUiEnabled();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPlayUiEnabled();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playUIs.OnLeftArrow();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playUIs.OnRightArrow();
        }
    }

    private void SetPlayUiEnabled()
    {
        isUiEnabled = !isUiEnabled;
        playUIs.RightSetCanvasGroup(isUiEnabled);
    }

    // 显示
    public void DisplayPlayUi()
    {
        isUiEnabled = true;
        playUIs.SetCanvasGroup(isUiEnabled);
    }

    // 延迟播放击碎人声
    private void PlayJisuiRSound()
    {
        soundOs.PlayJisuiRSound();
    }

    public void AddOpenShelter()
    {
        openShelter++;
        if(openShelter == 2)
        {
            soundOs.PlayJisuiRSound();
        }

        if (openShelter == 9)
        {
            /*if(GameData.Instance.isPatch == false)
            {
                GameData.Instance.SaveData();
                DisplayPlayUi();

                // 通关隐藏分数
                scores.SetScoresGroup(0);

                string str = GameData.Instance.GetCurrPassStr("roleAnim");
                if(str != "-1")
                {
                    playUIs.Sp3Click();
                }
            }
            else
            {*/
                scores.HandlePlayerDisplayUI(2);
                fastTwos.OnFastTwo();
            //}
        }
    }

    // 二玩法结束
    public void TwoPlayEnd()
    {
        GameData.Instance.SaveData();
        DisplayPlayUi();

        // 通关隐藏分数
        scores.SetScoresGroup(0);

        // 直接显示动图
        playUIs.SetCurrOpenType(1);
        playUIs.Sp3Click();
    }
}
