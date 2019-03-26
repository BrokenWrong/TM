using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuhuoImgs : MonoBehaviour {

    public Image cdImg;

    public Sprite[] spArr;

    // 播放速度
    private float bfSpeed = 2f;

    // 当前速度
    private float dqSpeed = 0;

    // 当前播放图片
    private int imgIndex = 0;

    // 当前分数位置
    private int scoresPos = 0;

    // 动画播放位置
    private Vector3[] vec3Arr =
    {
        new Vector3(-47, 505, 0),
        new Vector3(0, 505, 0),
        new Vector3(47, 505, 0),
        new Vector3(94, 505, 0),
        new Vector3(141, 505, 0)
    };

    private Scores scores;

    // 隐藏图片
    public void Hide()
    {
        cdImg.enabled = false;
    }

    // 显示图片
    public void Display()
    {
        cdImg.enabled = true;
    }

    // 刷新图片显示
    private void Refresh()
    {
        cdImg.overrideSprite = spArr[imgIndex];
    }

    // 播放图片
    public void Play(int i, Scores s)
    {
        scoresPos = i;
        scores = s;
        transform.localPosition = vec3Arr[i];
        imgIndex = 0;
        Refresh();
        Display();
        StartCoroutine("BHPlayCD");
    }

    // 停止播放
    public void Stop()
    {
        Hide();
        StopCoroutine("BHPlayCD");
    }

    IEnumerator BHPlayCD()
    {
        while (imgIndex < spArr.Length - 1)
        {
            dqSpeed++;
            if (dqSpeed == bfSpeed)
            {
                dqSpeed = 0;
                imgIndex++;
                Refresh();
                if(imgIndex == 6)
                {
                    AddScoresImg();
                }
            }
            yield return 0;
        }
        Hide();
    }

    // 添加分数图片
    private void AddScoresImg()
    {
        scores.DisplayScoresImg(scoresPos);
    }
}
