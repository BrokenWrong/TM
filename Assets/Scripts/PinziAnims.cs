using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinziAnims : MonoBehaviour
{
    public Image cdImg;

    public Sprite[] spArr;

    // 播放速度
    private float bfSpeed = 2f;

    // 当前速度
    private float dqSpeed = 0;

    // 当前播放图片
    private int imgIndex = 0;

    private Passs passs;

    // 瓶子索引
    private int pinziI;

    // 隐藏图片
    public void Hide()
    {
        Destroy(transform.gameObject);
        passs.CreatePinzi(pinziI);
        /*else if(pinziType == 2)
        {
            passs.CreatePinziNot();
        }*/
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

    public void OnPinziAnim(Vector3 vec3, Passs scripts, int i)
    {
        transform.localPosition = vec3;
        passs = scripts;
        pinziI = i;
        Play();
    }

    // 播放图片
    public void Play()
    {
        imgIndex = 0;
        Refresh();
        Display();
        StartCoroutine("PlayPinzi");
    }

    IEnumerator PlayPinzi()
    {
        while (imgIndex < spArr.Length - 1)
        {
            dqSpeed++;
            if (dqSpeed == bfSpeed)
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
