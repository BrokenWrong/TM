using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HamsterBtns : MonoBehaviour {
    public Image HamsterImg;

    public void BtnClcik()
    {
        transform.parent.GetComponent<FastImgs>().HamsterClick();
    }

    public void SetHamsterImgEnabled(bool bl)
    {
        HamsterImg.enabled = bl;
    }
}
