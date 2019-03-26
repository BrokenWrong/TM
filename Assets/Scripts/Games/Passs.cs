using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passs : MonoBehaviour {
    public GameManagers gameManagers;
    public SoundOs soundOs;

    private Vector3[] checkVA =
    {
        new Vector3(-776.5f, -20, 0), new Vector3(-749, -282, 0), new Vector3(-508.5f, -8, 0),
        new Vector3(-508.5f, -204, 0), new Vector3(-346.5f, -394, 0), new Vector3(-184.5f, -20, 0),
        new Vector3(132, -183, 0), new Vector3(393, -316, 0), new Vector3(396.5f, -11.5f, 0),
        new Vector3(629.5f, 20, 0), new Vector3(820, -43, 0), new Vector3(764.5f, -406, 0)
    };
    //private Vector3[] pinZiVA =
    //{
    //    new Vector3(-794, 327, 0), new Vector3(-661, 190, 0), new Vector3(-526, 290, 0),
    //    new Vector3(-364, 207, 0), new Vector3(-213, 307, 0), new Vector3(-67, 207, 0),
    //    new Vector3(74, 307, 0), new Vector3(211, 207, 0), new Vector3(352, 307, 0),
    //    new Vector3(498, 207, 0),// 647, 307      789, 216
    //};
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
        //passAdopt = GameData.Instance.passAdopt;
        //LoadPinZi();
        //LoadPinZiNot();
        //LoadCheckBtn();
    }

    public void SetPassAdopt(int i)
    {
        passAdopt = i;
    }

    public void OnPass()
    {
        RefreshBtn();
        //Invoke("RefreshPass", 0.5f);
    }

    // 刷新关卡显示
    private void RefreshPass()
    {
        //PlayCheckAnim(GameData.Instance.spotCurr);
        //PlayPinziAnim();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            soundOs.StopPinziSound();
            DetelePinzi();
            gameManagers.LoadBegin();
        }
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    PlayCheckAnim();
        //}
    }

    private void LoadPinZi()
    {
        if (GameData.Instance.passChooseSpot.Count == 0) return;
        for (int i = 0; i < GameData.Instance.passChooseSpot.Count; i++)
        {
            if (GameData.Instance.HandleIsHavePass(i) == false) return;
            if(passAdopt < i)
            {
                PlayPinziAnim(i);
                //CreatePinzi(i);
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
        if (GameData.Instance.passAdopt == GameData.Instance.passMax) return;
        Transform tf = Instantiate(PinZiNot, Check).transform;
        tf.localPosition = pinZiVA[GameData.Instance.passAdopt];
        tf.GetComponent<PinZiNots>().OnPinZi(transform, GameData.Instance.passAdopt + 1);
    }*/

    private void LoadCheckBtn()
    {
        for (int i = 0; i < GameData.Instance.passMax; i++)
        {
            if (!GameData.Instance.IsPassChooseSpot(i))
            {
                Transform tf = Instantiate(CheckBtn, Check).transform;
                tf.localPosition = checkVA[i];
                tf.GetComponent<CheckBtns>().OnCheck(transform, i + 1);
                checkBtnsDict[i] = tf.GetComponent<CheckBtns>();
            }
        }
        /*for (int i = 0; i < 12; i++)
        {
                Transform tf = Instantiate(CheckBtn, Check).transform;
                tf.localPosition = checkVA[i];
                tf.GetComponent<CheckBtns>().OnCheck(transform, i + 1);
                checkBtnsDict[i] = tf.GetComponent<CheckBtns>();
        }*/
    }

    public void CheckClick()
    {
        gameManagers.Play.GetComponent<Plays>().playUIs.SetCurrOpenType(1);
        soundOs.StopPinziSound();
        DetelePinzi();
        gameManagers.OnPlay();
    }

    public void PinZiClick()
    {
        gameManagers.Play.GetComponent<Plays>().playUIs.SetCurrOpenType(1);
        soundOs.StopPinziSound();
        DetelePinzi();
        gameManagers.OnPlay();
    }

    private void RefreshBtn()
    {
        //if (GameData.Instance.passAdopt == passAdopt) return;
        for (int i = 0; i < Check.childCount; i++)
        {
            Transform tf = Check.GetChild(i);
            Destroy(tf.gameObject);
        }
        LoadPinZi();
        //LoadPinZiNot();
        LoadCheckBtn();
        //passAdopt = GameData.Instance.passAdopt;
    }

    // 删除所有瓶子和点
    private void DetelePinzi()
    {
        for (int i = 0; i < Check.childCount; i++)
        {
            Transform tf = Check.GetChild(i);
            Destroy(tf.gameObject);
        }
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
        Vector3 vec3 = GameData.Instance.GetPinziPos(i);
        Passs scripts = transform.GetComponent<Passs>();
        tf.GetComponent<PinziAnims>().OnPinziAnim(vec3, scripts, i);
    }

    // 创建空瓶子出现动画
    /*private void PlayPinziNotAnim()
    {
        Transform tf = Instantiate(PinziAnim, Check).transform;
        Vector3 vec3 = pinZiVA[GameData.Instance.passCurr];
        Passs scripts = transform.GetComponent<Passs>();
        tf.GetComponent<PinziAnims>().OnPinziAnim(vec3, scripts, GameData.Instance.passCurr, 2);
    }*/

    // 创建瓶子
    public void CreatePinzi(int i)
    {
        Transform tf = Instantiate(PinZi, Check).transform;
        tf.localPosition = GameData.Instance.GetPinziPos(i);
        tf.GetComponent<PinZis>().OnPinZi(transform, i + 1);
        tf.GetComponent<PendulumClockAnimation>().OnAnim();
    }

    // 动画创建瓶子
    public void AnimCreatePinzi(int i)
    {
        Transform tf = Instantiate(PinZi, Check).transform;
        tf.localPosition = GameData.Instance.GetPinziPos(i);
        tf.GetComponent<PinZis>().OnPinZi(transform, i + 1);
        tf.GetComponent<PendulumClockAnimation>().SetCanvasGroup();
    }

    // 创建空瓶子
    /*public void CreatePinziNot()
    {
        Transform tf = Instantiate(PinZiNot, Check).transform;
        tf.localPosition = pinZiVA[GameData.Instance.passAdopt];
        tf.GetComponent<PinZiNots>().OnPinZi(transform, GameData.Instance.passAdopt + 1);
    }*/
}
