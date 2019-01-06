using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinZiNots : MonoBehaviour {
    private int indexI;
    private Passs passs;

    public void OnPinZi(Transform tf, int index)
    {
        passs = tf.GetComponent<Passs>();
        indexI = index;
    }

    public void PinZiClick()
    {
        GameData.Instance().spotCurr = indexI;
        GameData.Instance().passCurr = GameData.Instance().passAdopt + 1;
        passs.PinZiClick();
    }
}
