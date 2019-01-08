using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBtns : MonoBehaviour {
    private Passs passs;
    private int indexI;

    public void OnCheck(Transform tf, int index)
    {
        passs = tf.GetComponent<Passs>();
        indexI = index;
    }

    public void CheckClick()
    {
        GameData.Instance().spotCurr = indexI - 1;
        GameData.Instance().passCurr = GameData.Instance().passAdopt + 1;
        passs.CheckClick();
    }
}
