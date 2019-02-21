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

    public void BtnClcik()
    {
        if (isClick == true) return;
        isClick = true;
        //transform.parent.GetComponent<FastImgs>().PlayChuiAnim();
        dishuSpines.Play03();

        //SetHamsterImgEnabled(false);
        //transform.parent.GetComponent<FastImgs>().HamsterClick();
    }

    // 击中地鼠计数
    public void ClickDishu()
    {
        transform.parent.GetComponent<FastImgs>().HamsterClick();
    }

    public void SetIsClick()
    {
        isClick = false;
    }

    public void SetHamsterImgEnabled(bool bl)
    {
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
