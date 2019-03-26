using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastImgs : MonoBehaviour {
    public GameObject HamsterBtn;
    private HamsterBtns[] hamsterBtns = new HamsterBtns[9];
    public Plays plays;
    public SoundOs soundOs;

    // 当前第几块
    public int kuaiI;

    // 当前显示的地鼠
    private int currHamster = 0;

    private bool isEnter = false;
    private int currTime = 0;
    private int displayTime = 20;
    private int hideTime = 100;
    private bool isDisplay = false;

    // 当前击中地鼠次数
    private int clickDs = 0;

    // 碎裂动画
    public GameObject SuilieAnim;

    // 锤子动画
    public ChuiAnims chuiAnims;

    // 地鼠坐标
    private Vector3[] dsVec3 =
    {
        new Vector3(-213.3f, 120, 0), new Vector3(0f, 120, 0), new Vector3(213.3f, 120, 0),
        new Vector3(-213.3f, 0, 0), new Vector3(0f, 0, 0), new Vector3(213.3f, 0, 0),
        new Vector3(-213.3f, -120, 0), new Vector3(0f, -120, 0), new Vector3(213.3f, -120, 0)
    };

    // 锤子坐标之差
    private Vector3[] czVec3 =
    {
        new Vector3(-640f, 360, 0), new Vector3(0f, 360, 0), new Vector3(640f, 360, 0),
        new Vector3(-640f, 0, 0), new Vector3(0f, 0, 0), new Vector3(640, 0, 0),
        new Vector3(-640, -360, 0), new Vector3(0f, -360, 0), new Vector3(640, -360, 0)
    };

    public void OnEnter()
    {
        isEnter = true;
        plays.scores.ClickToRefresh(clickDs, kuaiI, true);
    }
    public void OnExit()
    {
        isEnter = false;
        plays.scores.ClickToRefresh(clickDs, kuaiI, true);
    }

    void Start()
    {
        AddHamsterBtn();
        //plays.DisplayPlayUi();
        //transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if (clickDs == 3) return;
        if (!isEnter && !isDisplay) return;
        DisplayHamster();
    }

    private void AddHamsterBtn()
    {
        /*float x = -213.3f;
        float y = 120f;*/
        for (int i = 0; i < 9; i++)
        {
            Transform tf = Instantiate(HamsterBtn, transform).transform;
            tf.localPosition = dsVec3[i];
            hamsterBtns[i] = tf.GetComponent<HamsterBtns>();
            /*x = x + 213.3f;
            if(i == 2 || i == 5)
            {
                x = -213.3f;
                y = y - 120;
            }*/
        }
    }

    public void HamsterClick()
    {
        //clickDs++;
        plays.scores.ClickToRefresh(clickDs, kuaiI, false);
        //测试 3修改成1
        if (clickDs == 3)
        {
            Invoke("PlaySuilieAnim", 0.5f);
            //PlaySuilieAnim();
        }
    }

    // 显示地鼠
    private void DisplayHamster()
    {
        if(currTime == displayTime)
        {
            isDisplay = true;
            currHamster = UnityEngine.Random.Range(0, 9);
            soundOs.PlayDishuSound();
            hamsterBtns[currHamster].SetHamsterImgEnabled(true, 1);
        }
        else if (currTime == hideTime)
        {
            isDisplay = false;
            //hamsterBtns[currHamster].SetHamsterImgEnabled(false);
            currTime = -1;
        }
        currTime++;
    }

    public void InitDisplay()
    {
        isEnter = false;
        isDisplay = false;
        currTime = 0;
        clickDs = 0;
        //if (!hamsterBtns[0]) return;
        //for (int i = 0; i < hamsterBtns.Length; i++)
        //{
        //hamsterBtns[i].SetHamsterImgEnabled(false);
        //}
    }

    // 播放碎裂动画
    private void PlaySuilieAnim()
    {
        Transform tf = Instantiate(SuilieAnim, transform).transform;
        tf.GetComponent<SuilieAnims>().OnSuilieAnim(transform.GetComponent<FastImgs>());
    }

    // 碎裂动画后处理
    public void SuilieToFast()
    {
        transform.gameObject.SetActive(false);
        transform.GetComponent<Image>().enabled = true;
        plays.AddOpenShelter();
    }

    // 隐藏后板
    public void HideFastImg()
    {
        transform.GetComponent<Image>().enabled = false;
    }

    // 播放锤子动画
    public void PlayChuiAnim()
    {
        chuiAnims.Play(dsVec3[currHamster]+ czVec3[kuaiI - 1]);
    }

    // 加击中数
    public void AddClickNum()
    {
        clickDs++;
    }
}
