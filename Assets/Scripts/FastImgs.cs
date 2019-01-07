using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastImgs : MonoBehaviour {
    public GameObject HamsterBtn;
    private HamsterBtns[] hamsterBtns = new HamsterBtns[9];
    public Plays plays;

    // 当前显示的地鼠
    private int currHamster = 0;

    private bool isEnter = false;
    private int currTime = 0;
    private int displayTime = 20;
    private int hideTime = 100;
    private bool isDisplay = false;

    public void OnEnter()
    {
        isEnter = true;
    }
    public void OnExit()
    {
        isEnter = false;
    }

    void Start()
    {
        AddHamsterBtn();
        //plays.DisplayPlayUi();
        //transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isEnter && !isDisplay) return;
        DisplayHamster();
    }

    private void AddHamsterBtn()
    {
        float x = -213.3f;
        float y = 120f;
        for (int i = 0; i < 9; i++)
        {
            Transform tf = Instantiate(HamsterBtn, transform).transform;
            tf.localPosition = new Vector3(x, y, 0);
            hamsterBtns[i] = tf.GetComponent<HamsterBtns>();
            x = x + 213.3f;
            if(i == 2 || i == 5)
            {
                x = -213.3f;
                y = y - 120;
            }
        }
    }

    public void HamsterClick()
    {
        transform.gameObject.SetActive(false);
        plays.AddOpenShelter();
    }

    // 显示地鼠
    private void DisplayHamster()
    {
        if(currTime == displayTime)
        {
            isDisplay = true;
            currHamster = UnityEngine.Random.Range(0, 9);
            hamsterBtns[currHamster].SetHamsterImgEnabled(true);
        }
        else if (currTime == hideTime)
        {
            isDisplay = false;
            hamsterBtns[currHamster].SetHamsterImgEnabled(false);
            currTime = -1;
        }
        currTime++;
    }
}
