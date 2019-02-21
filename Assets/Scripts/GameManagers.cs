using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour {
    public GameObject Begin;
    public GameObject Pass;
    public GameObject Play;
    public SoundOs soundOs;
    //private Passs passs;
    public MainVideos mainVideos;
    public CanvasGroup BeginGroup;

    void Awake()
    {
        GameData.Instance();
        //passs = Pass.transform.GetComponent<Passs>();
    }

    void Start () {
        // 播放背景音乐
        soundOs.PlayBgSound(19);
    }

    public void OnStart()
    {
        Begin.SetActive(true);
        StartCoroutine("DisplayBeginUI");
    }

    IEnumerator DisplayBeginUI()
    {
        BeginGroup.blocksRaycasts = true;
        while (BeginGroup.alpha < 1)
        {
            BeginGroup.alpha = BeginGroup.alpha + 0.01f;
            yield return 0;
        }
    }

    void Update () {
		
	}

    // 开始游戏按钮
    public void BeginClick()
    {
        // 隐藏视频播放
        mainVideos.HideVoide();
        mainVideos.gameObject.SetActive(false);
        BeginGroup.alpha = 0;
        BeginGroup.blocksRaycasts = false;

        soundOs.PlayBtnSound();
        Begin.SetActive(false);
        Pass.SetActive(true);
    }

    public void ExitClick()
    {
        soundOs.PlayBtnSound();
        Application.Quit();
    }

    public void OnPlay()
    {
        Pass.SetActive(false);
        Play.SetActive(true);
        Play.GetComponent<Plays>().OnPlay();
    }

    public void CgClick()
    {
        // 播放界面背景音乐
        soundOs.PlayBgSound(19);

        Play.SetActive(false);
        Pass.SetActive(true);
        Pass.GetComponent<Passs>().OnPass();
    }

    public void AgainClick()
    {
        Play.SetActive(true);
        Play.GetComponent<Plays>().AgainPlay();
    }

    public void LoadBegin()
    {
        Pass.SetActive(false);

        //Begin.SetActive(true);
        //StartCoroutine("DisplayBeginUI");

        mainVideos.gameObject.SetActive(true);
        mainVideos.PlayXunhuan();
    }
}
