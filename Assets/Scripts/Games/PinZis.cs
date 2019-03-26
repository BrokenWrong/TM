using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinZis : MonoBehaviour {
    private int indexI;
    private Passs passs;
    public Image Img1;

    public void OnPinZi(Transform tf, int index)
    {
        passs = tf.GetComponent<Passs>();
        indexI = index;
        Img1.sprite = Resources.Load(GameData.Instance.GetPassStr(index - 1, "pinziImg"), typeof(Sprite)) as Sprite;
    }

    public void PinZiClick()
    {
        // 成就
        if(indexI < 9)
        {
            for (int i = 0; i < 3; i++)
            {
                int ii = indexI - 1;
                GameAchStatic.SetAchievement(ii * 3 + 3 + i);
            }

        }

        GameData.Instance.spotCurr = indexI - 1;
        GameData.Instance.passCurr = indexI;
        passs.PinZiClick();
    }

    // 鼠标进入播放声音
    public void OnEnter()
    {
        string str = GameData.Instance.GetPassStr(indexI - 1, "pzSound");
        GameData.Instance.soundOs.PlayPinziSound(str);
    }
    // 鼠标退出停止播放声音
    public void OnExit()
    {
        GameData.Instance.soundOs.StopPinziSound();
    }
}
