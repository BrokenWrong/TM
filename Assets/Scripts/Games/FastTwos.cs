using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTwos : MonoBehaviour {

    // 地鼠
    public GameObject HamsterBtn;

    // 地鼠坐标
    private Vector3[] hamsterVec3 =
    {
        new Vector3(-640f, 360, 0), new Vector3(0f, 360, 0), new Vector3(640f, 360, 0),
        new Vector3(-640f, 0, 0), new Vector3(0f, 0, 0), new Vector3(640, 0, 0),
        new Vector3(-640, -360, 0), new Vector3(0f, -360, 0), new Vector3(640, -360, 0)
    };

    // 地鼠动画脚本
    private HamsterBtns[] hamsterBtns = new HamsterBtns[9];

    // 地鼠打击次数
    private int clickDs = 0;

    public Plays plays;
    public SoundOs soundOs;

    private int currTime = -50;
    private int displayTime = 20;
    private int hideTime = 100;

    // 是否开始玩法
    private bool isPlay = false;

    void Start()
    {
        AddHamster();
    }

    // 添加地鼠
    public void AddHamster()
    {
        for (int i = 0; i < 9; i++)
        {
            Transform tf = Instantiate(HamsterBtn, transform).transform;
            tf.localPosition = hamsterVec3[i];
            tf.localScale = new Vector3(2, 2, 0);
            hamsterBtns[i] = tf.GetComponent<HamsterBtns>();
        }
    }

    public void OnFastTwo()
    {
        soundOs.PlayRoleBgm();
        clickDs = 0;
        currTime = -50;
        isPlay = true;
    }
    public void SetIsPlay(bool bl)
    {
        isPlay = bl;
    }

    void Update()
    {
        if (clickDs == 5) return;
        if (isPlay == false) return;
        Appear();
    }

    // 地鼠出现
    private void Appear()
    {
        if (currTime == displayTime)
        {
            int num = UnityEngine.Random.Range(0, 9);
            soundOs.PlayDishuSound();
            hamsterBtns[num].SetHamsterImgEnabled(true, 2);
        }
        else if (currTime == hideTime)
        {
            currTime = -1;
        }
        currTime++;
    }

    // 地鼠打击
    public void HamsterClick()
    {
        //clickDs++;
        plays.scores.TwoRefreshScores(clickDs);
        if (clickDs == 5)
        {
            isPlay = false;
            clickDs = 0;
            //plays.TwoPlayEnd();
            Invoke("TwoPlayEnd", 0.5f);
        }
    }

    // 等待动画结束执行
    private void TwoPlayEnd()
    {
        plays.TwoPlayEnd();
    }

    // 加击中数
    public void AddClickNum()
    {
        clickDs++;
    }
}
