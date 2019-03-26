using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HamsterBtns : MonoBehaviour {
    public Image HamsterImg;
    public DishuSpines dishuSpines;
    public CanvasGroup canvasGroup;
    public CdAnims cdAnims;

    private bool isClick = false;

    // 玩法类型
    private int playType = 0;

    public void BtnClcik()
    {
        if (isClick == true) return;
        isClick = true;
        //transform.parent.GetComponent<FastImgs>().PlayChuiAnim();
        ClickAddNum();
        dishuSpines.Play03();
        Invoke("ClickDishu", 0.5f);

        //SetHamsterImgEnabled(false);
        //transform.parent.GetComponent<FastImgs>().HamsterClick();
    }

    // 击中地鼠计数
    public void ClickDishu()
    {
        if(playType == 1)
        {
            transform.parent.GetComponent<FastImgs>().HamsterClick();
        }
        else if(playType == 2)
        {
            transform.parent.GetComponent<FastTwos>().HamsterClick();
        }
    }

    // 击中地鼠加数
    private void ClickAddNum()
    {
        if (playType == 1)
        {
            transform.parent.GetComponent<FastImgs>().AddClickNum();
        }
        else if (playType == 2)
        {
            transform.parent.GetComponent<FastTwos>().AddClickNum();
        }
    }

    public void SetIsClick()
    {
        isClick = false;
    }

    public void SetHamsterImgEnabled(bool bl, int type)
    {
        playType = type;
        //HamsterImg.enabled = bl;
        Display();
        cdAnims.Play();
        //Invoke("PlayDishuSpine", 0.1f);
        PlayDishuSpine();
    }

    // 播放地鼠动画
    private void PlayDishuSpine()
    {
        dishuSpines.Display();
    }

    // 隐藏
    public void Hide()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }

    // 显示
    public void Display()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
}
