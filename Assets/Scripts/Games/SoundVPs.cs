using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVPs : MonoBehaviour {

    public Image[] btnImgs;

    public Sprite[] sps;

    private SoundOs soundOs;

    public Slider[] Sliders;

    void Start()
    {
        soundOs = GameData.Instance.soundOs;

        if (GameData.Instance.czValue == 0)
        {
            btnImgs[0].overrideSprite = sps[1];
        }
        else
        {
            btnImgs[0].overrideSprite = sps[0];
        }
        Sliders[0].value = GameData.Instance.czValue;

        if (GameData.Instance.bgValue == 0)
        {
            btnImgs[1].overrideSprite = sps[3];
        }
        else
        {
            btnImgs[1].overrideSprite = sps[2];
        }
        Sliders[1].value = GameData.Instance.bgValue;

        if (GameData.Instance.rsValue == 0)
        {
            btnImgs[2].overrideSprite = sps[5];
        }
        else
        {
            btnImgs[2].overrideSprite = sps[4];
        }
        Sliders[2].value = GameData.Instance.rsValue;
    }

    public void BackClick()
    {
        GameData.Instance.SaveFileData();
        Destroy(transform.gameObject);
    }

    public void Btn1Click()
    {
        if(GameData.Instance.czValue == 0)
        {
            GameData.Instance.czValue = 1;
            btnImgs[0].overrideSprite = sps[0];
        }
        else
        {
            GameData.Instance.czValue = 0;
            btnImgs[0].overrideSprite = sps[1];
        }
        Sliders[0].value = GameData.Instance.czValue;
        soundOs.RefreshCzValue();
        GameData.Instance.SaveFileData();
    }
    public void Btn2Click()
    {
        if (GameData.Instance.bgValue == 0)
        {
            GameData.Instance.bgValue = 1;
            btnImgs[1].overrideSprite = sps[2];
        }
        else
        {
            GameData.Instance.bgValue = 0;
            btnImgs[1].overrideSprite = sps[3];
        }
        Sliders[1].value = GameData.Instance.bgValue;
        soundOs.RefreshBgValue();
        GameData.Instance.SaveFileData();
    }
    public void Btn3Click()
    {
        if (GameData.Instance.rsValue == 0)
        {
            GameData.Instance.rsValue = 1;
            btnImgs[2].overrideSprite = sps[4];
        }
        else
        {
            GameData.Instance.rsValue = 0;
            btnImgs[2].overrideSprite = sps[5];
        }
        Sliders[2].value = GameData.Instance.rsValue;
        soundOs.RefreshRsValue();
        GameData.Instance.SaveFileData();
    }

    public void Slider1Click()
    {
        GameData.Instance.czValue = Sliders[0].value;
        if (GameData.Instance.czValue == 0)
        {
            btnImgs[0].overrideSprite = sps[1];
        }
        else
        {
            btnImgs[0].overrideSprite = sps[0];
        }
        soundOs.RefreshCzValue();
    }
    public void Slider2Click()
    {
        GameData.Instance.bgValue = Sliders[1].value;
        if (GameData.Instance.bgValue == 0)
        {
            btnImgs[1].overrideSprite = sps[3];
        }
        else
        {
            btnImgs[1].overrideSprite = sps[2];
        }
        soundOs.RefreshBgValue();
    }
    public void Slider3Click()
    {
        GameData.Instance.rsValue = Sliders[2].value;
        if (GameData.Instance.rsValue == 0)
        {
            btnImgs[2].overrideSprite = sps[5];
        }
        else
        {
            btnImgs[2].overrideSprite = sps[4];
        }
        soundOs.RefreshRsValue();
    }
}
