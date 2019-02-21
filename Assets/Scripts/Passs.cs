using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passs : MonoBehaviour {
    public GameManagers gameManagers;
    public SoundOs soundOs;

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

    // 进关按钮
    private Dictionary<int, CheckBtns> checkBtnsDict = new Dictionary<int, CheckBtns>();

    // 通关关数保留
    private int passAdopt = -1;

    // 瓶子动画
    public GameObject PinziAnim;

    void Start () {
        //passAdopt = GameData.Instance().passAdopt;
        LoadPinZi();
        //LoadPinZiNot();
        LoadCheckBtn();
    }

    public void OnPass()
    {
        RefreshBtn();
        //Invoke("RefreshPass", 0.5f);
    }

    // 刷新关卡显示
    private void RefreshPass()
    {
        //PlayCheckAnim(GameData.Instance().spotCurr);
        //PlayPinziAnim();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManagers.LoadBegin();
        }
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    PlayCheckAnim();
        //}
    }

    private void LoadPinZi()
    {
        if (GameData.Instance().passChooseSpot.Count == 0) return;
        for (int i = 0; i < GameData.Instance().passChooseSpot.Count; i++)
        {
            if(passAdopt < i)
            {
                PlayPinziAnim(i);
            }
            else
            {
                CreatePinzi(i);
            }
            //CreatePinzi(i);
            /*Transform tf = Instantiate(PinZi, Check).transform;
            tf.localPosition = pinZiVA[i];
            tf.GetComponent<PinZis>().OnPinZi(transform, i + 1);*/
        }
    }

    /*private void LoadPinZiNot()
    {
        if (GameData.Instance().passAdopt == GameData.Instance().passMax) return;
        Transform tf = Instantiate(PinZiNot, Check).transform;
        tf.localPosition = pinZiVA[GameData.Instance().passAdopt];
        tf.GetComponent<PinZiNots>().OnPinZi(transform, GameData.Instance().passAdopt + 1);
    }*/

    private void LoadCheckBtn()
    {
        for (int i = 0; i < checkVA.Length; i++)
        {
            if(!GameData.Instance().IsPassChooseSpot(i))
            {
                Transform tf = Instantiate(CheckBtn, Check).transform;
                tf.localPosition = checkVA[i];
                tf.GetComponent<CheckBtns>().OnCheck(transform, i + 1);
                checkBtnsDict[i] = tf.GetComponent<CheckBtns>();
            }
        }
    }

    public void CheckClick()
    {
        gameManagers.OnPlay();
    }

    public void PinZiClick()
    {
        soundOs.PlayBtnSound();
        gameManagers.OnPlay();
    }

    private void RefreshBtn()
    {
        soundOs.PlayBtnSound();
        //if (GameData.Instance().passAdopt == passAdopt) return;
        for (int i = 0; i < Check.childCount; i++)
        {
            Transform tf = Check.GetChild(i);
            Destroy(tf.gameObject);
        }
        LoadPinZi();
        //LoadPinZiNot();
        LoadCheckBtn();
        //passAdopt = GameData.Instance().passAdopt;
    }

    // 播放选关点爆破动画
    private void PlayCheckAnim(int index)
    {
        foreach (KeyValuePair<int, CheckBtns> item in checkBtnsDict)
        {
            if(item.Key == index)
            {
                item.Value.Play();
                return;
            }
        }
    }

    // 播放瓶子出现动画
    private void PlayPinziAnim(int i)
    {
        passAdopt = i;
        Transform tf = Instantiate(PinziAnim, Check).transform;
        Vector3 vec3 = pinZiVA[i];
        Passs scripts = transform.GetComponent<Passs>();
        tf.GetComponent<PinziAnims>().OnPinziAnim(vec3, scripts, i);
    }

    // 创建空瓶子出现动画
    /*private void PlayPinziNotAnim()
    {
        Transform tf = Instantiate(PinziAnim, Check).transform;
        Vector3 vec3 = pinZiVA[GameData.Instance().passCurr];
        Passs scripts = transform.GetComponent<Passs>();
        tf.GetComponent<PinziAnims>().OnPinziAnim(vec3, scripts, GameData.Instance().passCurr, 2);
    }*/

    // 创建瓶子
    public void CreatePinzi(int i)
    {
        Transform tf = Instantiate(PinZi, Check).transform;
        tf.localPosition = pinZiVA[i];
        tf.GetComponent<PinZis>().OnPinZi(transform, i + 1);
    }

    // 创建空瓶子
    /*public void CreatePinziNot()
    {
        Transform tf = Instantiate(PinZiNot, Check).transform;
        tf.localPosition = pinZiVA[GameData.Instance().passAdopt];
        tf.GetComponent<PinZiNots>().OnPinZi(transform, GameData.Instance().passAdopt + 1);
    }*/
}
