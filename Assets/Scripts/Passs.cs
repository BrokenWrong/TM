using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passs : MonoBehaviour {
    public GameManagers gameManagers;

    private Vector3[] checkVA =
    {
        new Vector3(-630, -70, 0), new Vector3(-581, -370, 0), new Vector3(-279, -65, 0),
        new Vector3(11, -88, 0), new Vector3(42, 259, 0), new Vector3(108, -335, 0),
        new Vector3(436, 366, 0), new Vector3(716, 148, 0), new Vector3(695, -195, 0),
        new Vector3(472, -437, 0),
    };
    private Vector3[] pinZiVA =
    {
        new Vector3(-794, 327, 0), new Vector3(-661, 190, 0), new Vector3(-526, 290, 0),
        new Vector3(-364, 207, 0), new Vector3(-213, 307, 0), new Vector3(-67, 207, 0),
        new Vector3(74, 307, 0), new Vector3(211, 207, 0), new Vector3(352, 307, 0),
        new Vector3(498, 207, 0),
    };
    public GameObject CheckBtn;
    public Transform Check;
    public GameObject PinZi;
    public GameObject PinZiNot;

    void Start () {
        LoadPinZi();
        LoadPinZiNot();
        LoadCheckBtn();
    }
	
	void Update () {
		
	}

    private void LoadPinZi()
    {
        if (GameData.Instance().passChooseSpot.Count == 0) return;
        for (int i = 0; i < GameData.Instance().passChooseSpot.Count; i++)
        {
            Transform tf = Instantiate(PinZi, Check).transform;
            tf.localPosition = pinZiVA[i];
            tf.GetComponent<PinZis>().OnPinZi(transform, i + 1);
        }
    }

    private void LoadPinZiNot()
    {
        if (GameData.Instance().passChooseSpot.Count == GameData.Instance().passMax) return;
        Transform tf = Instantiate(PinZiNot, Check).transform;
        tf.localPosition = pinZiVA[GameData.Instance().passAdopt];
        tf.GetComponent<PinZiNots>().OnPinZi(transform, GameData.Instance().passAdopt + 1);
    }

    private void LoadCheckBtn()
    {
        for (int i = 0; i < checkVA.Length; i++)
        {
            if(!GameData.Instance().IsPassChooseSpot(i))
            {
                Transform tf = Instantiate(CheckBtn, Check).transform;
                tf.localPosition = checkVA[i];
                tf.GetComponent<CheckBtns>().OnCheck(transform, i + 1);
            }
        }
    }

    public void CheckClick()
    {
        gameManagers.OnPlay();
        Debug.Log(GameData.Instance().passCurr);
    }

    public void PinZiClick()
    {
        gameManagers.OnPlay();
        Debug.Log(GameData.Instance().passCurr);
    }
}
