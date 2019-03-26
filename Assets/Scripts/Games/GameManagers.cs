using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        GameData.Instance.InitData();
    }

    void Start()
    {
        mainVideos.OnMainVido();
    }

    // 播放背景音乐
    public void PlayBgSound()
    {
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

    // 开始游戏按钮
    public void BeginClick()
    {
        // 成就
        GameAchStatic.SetAchievement(0);
        GameAchStatic.SetAchievement(1);
        GameAchStatic.SetAchievement(2);

        // 隐藏视频播放
        mainVideos.HideVoide();
        mainVideos.gameObject.SetActive(false);
        BeginGroup.alpha = 0;
        BeginGroup.blocksRaycasts = false;

        Begin.SetActive(false);
        Pass.SetActive(true);
        Pass.GetComponent<Passs>().SetPassAdopt(GameData.Instance.passChooseSpot.Count - 1);
        Pass.GetComponent<Passs>().OnPass();
    }

    public void ExitClick()
    {
        Application.Quit();
    }

    public void OnPlay()
    {
        Pass.SetActive(false);
        Play.SetActive(true);
        Play.GetComponent<Plays>().OnPlay();
    }

    // 已通过后点击图类型
    public void OnPlay(int i)
    {
        Pass.SetActive(false);
        Play.SetActive(true);
        Play.GetComponent<Plays>().OnPlay(i);
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
