using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {

    public CanvasGroup canvasGroup;

    public Image[] imgArr;

    // 当前鼠标在哪块
    private int currMousePos = 0;

    // 捕获动画
    public BuhuoImgs buhuoImgs;

    // 记录鼠标改变前
    private float mouseF = 0;

    // 背景图片
    public Image[] ScoreImg;

    // 控制分数显示
    public void SetScoresGroup(float f)
    {
        canvasGroup.alpha = f;
    }

    // 初始化
    public void Init()
    {
        imgArr[0].enabled = false;
        imgArr[1].enabled = false;
        imgArr[2].enabled = false;
        imgArr[3].enabled = false;
        imgArr[4].enabled = false;
        ScoreImg[3].enabled = false;
        ScoreImg[4].enabled = false;
        canvasGroup.alpha = 1;
    }

    // 进战斗界面刷新分数显示
    public void Refresh(bool bl)
    {
        if(bl == true)
        {
            canvasGroup.alpha = 0;
        }
        else
        {
            Init();
        }
    }

    // 显示图片
    public void DisplayScoresImg(int index)
    {
        imgArr[index].enabled = true;
    }

    // 点击刷新分数显示
    public void ClickToRefresh(int i, int index, bool bl)
    {
        if (currMousePos != index && bl == false) return;
        bool isBH = (currMousePos == index && bl == false);
        if(isBH == false)
        {
            buhuoImgs.Stop();
        }
        currMousePos = index;
        if (i == 0)
        {
            imgArr[0].enabled = false;
            imgArr[1].enabled = false;
            imgArr[2].enabled = false;
        }
        else if(i == 1)
        {
            /*imgArr[0].enabled = true;
            imgArr[1].enabled = false;
            imgArr[2].enabled = false;*/
            if(isBH == true)
            {
                buhuoImgs.Play(0, transform.GetComponent<Scores>());
            }
            else
            {
                imgArr[0].enabled = true;
                imgArr[1].enabled = false;
                imgArr[2].enabled = false;
            }
        }
        else if (i == 2)
        {
            /*imgArr[0].enabled = true;
            imgArr[1].enabled = true;
            imgArr[2].enabled = false;*/
            if (isBH == true)
            {
                buhuoImgs.Play(1, transform.GetComponent<Scores>());
            }
            else
            {
                imgArr[0].enabled = true;
                imgArr[1].enabled = true;
                imgArr[2].enabled = false;
            }
        }
        else if (i == 3)
        {
            /*imgArr[0].enabled = true;
            imgArr[1].enabled = true;
            imgArr[2].enabled = true;*/
            if (isBH == true)
            {
                buhuoImgs.Play(2, transform.GetComponent<Scores>());
            }
            else
            {
                imgArr[0].enabled = true;
                imgArr[1].enabled = true;
                imgArr[2].enabled = true;
            }
        }
    }

    // 玩法二刷新分数显示
    public void TwoRefreshScores(int num)
    {
        buhuoImgs.Play(num - 1, transform.GetComponent<Scores>());
        //imgArr[0].enabled = (num > 0);
        //imgArr[1].enabled = (num > 1);
        //imgArr[2].enabled = (num > 2);
        //imgArr[3].enabled = (num > 3);
        //imgArr[4].enabled = (num > 4);
    }

    // 鼠标进入
    public void MouseEnter()
    {
        mouseF = canvasGroup.alpha;
        if (mouseF == 0) return;
        canvasGroup.alpha = 0.3f;
    }
    // 鼠标出去
    public void MouseExit()
    {
        canvasGroup.alpha = mouseF;
    }

    // 判断玩法显示UI
    public void HandlePlayerDisplayUI(int type)
    {
        imgArr[0].enabled = false;
        imgArr[1].enabled = false;
        imgArr[2].enabled = false;
        imgArr[3].enabled = false;
        imgArr[4].enabled = false;
        ScoreImg[0].enabled = true;
        ScoreImg[1].enabled = true;
        ScoreImg[2].enabled = true;
        if(type == 2)
        {
            ScoreImg[3].enabled = true;
            ScoreImg[4].enabled = true;
        }
        canvasGroup.alpha = 1;
    }

}
