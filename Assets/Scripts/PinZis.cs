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
        Img1.sprite = Resources.Load(GameData.Instance().GetPassStr(index - 1, "pinziImg"), typeof(Sprite)) as Sprite;
    }

    public void PinZiClick()
    {
        GameData.Instance().spotCurr = indexI - 1;
        GameData.Instance().passCurr = indexI;
        passs.PinZiClick();
    }
}
