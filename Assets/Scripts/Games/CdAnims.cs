using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CdAnims : MonoBehaviour {

    public Image cdImg;

    public Sprite[] spArr;

    // 播放速度
    private float bfSpeed = 2f;

    // 当前速度
    private float dqSpeed = 0;

    // 当前播放图片
    private int imgIndex = 0;

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
    public void Play()
    {
        imgIndex = 0;
        Refresh();
        Display();
        StartCoroutine("PlayCD");
    }

    IEnumerator PlayCD()
    {
        while (imgIndex < spArr.Length - 1)
        {
            dqSpeed++;
            if(dqSpeed == bfSpeed)
            {
                dqSpeed = 0;
                imgIndex++;
                Refresh();
            }
            yield return 0;
        }
        Hide();
    }
}
