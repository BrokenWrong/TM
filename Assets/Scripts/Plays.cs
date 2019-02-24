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
        bool bl = GameData.Instance().passCurr > GameData.Instance().passAdopt;
        for (int i = 0; i < FastImgs.Length; i++)
        {
            FastImgs[i].SetActive(bl);
            FastImgs[i].GetComponent<FastImgs>().InitDisplay();
        }
        isUiEnabled = !bl;
        playUIs.SetCanvasGroup(!bl);

        string str = GameData.Instance().GetCurrPassStr("bgImg");
        BgImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;
        str = GameData.Instance().GetCurrPassStr("roleImg");
        RoleImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;

        // 进战斗界面刷新分数显示
        scores.Refresh(!bl);
    }

    public void AgainPlay()
    {
        openShelter = 0;
        for (int i = 0; i < FastImgs.Length; i++)
        {
            FastImgs[i].SetActive(true);
            FastImgs[i].GetComponent<FastImgs>().InitDisplay();
        }
        isUiEnabled = false;
        playUIs.SetCanvasGroup(false);

        string str = "Textures/roles/" + GameData.Instance().passCurr.ToString() + "A";
        BgImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;
        str = "Textures/roles/" + GameData.Instance().passCurr.ToString() + "B";
        RoleImg.sprite = Resources.Load(str, typeof(Sprite)) as Sprite;

        // 重新开始刷新分数
        scores.Init();
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
            GameData.Instance().SaveData();
            DisplayPlayUi();

            // 通关隐藏分数
            scores.SetScoresGroup(0);
        }
    }
}
