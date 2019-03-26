using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuilieAnims : MonoBehaviour {

    public Image cdImg;

    public Sprite[] spArr;

    // 播放速度
    private float bfSpeed = 2f;

    // 当前速度
    private float dqSpeed = 0;

    // 当前播放图片
    private int imgIndex = 0;

    private FastImgs fastImgs;

    // 隐藏图片
    public void Hide()
    {
        Destroy(transform.gameObject);
        fastImgs.SuilieToFast();
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

    public void OnSuilieAnim(FastImgs scripts)
    {
        fastImgs = scripts;
        Play();
    }

    // 播放图片
    public void Play()
    {
        // 播放方块碎裂音效
        GameData.Instance.soundOs.PlaySuilieSound();
        Invoke("PlayJisuiSound", 0.1f);

        imgIndex = 0;
        Refresh();
        Display();
        StartCoroutine("PlaySuilie");
    }

    // 延迟播放击碎声音
    private void PlayJisuiSound()
    {
        GameData.Instance.soundOs.PlayJisuiSound();
    }

    IEnumerator PlaySuilie()
    {
        while (imgIndex < spArr.Length - 1)
        {
            dqSpeed++;
            if (dqSpeed == bfSpeed)
            {
                dqSpeed = 0;
                imgIndex++;
                Refresh();
                if(imgIndex == 2)
                {
                    // 隐藏后板
                    fastImgs.HideFastImg();
                }
            }
            yield return 0;
        }
        Hide();
    }
}
