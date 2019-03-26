using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MainVideos : MonoBehaviour {
    public GameManagers gameManagers;

    public VideoPlayer playVideo1;
    public VideoPlayer playVideo2;

    public VideoClip Xunhuan;

    public CanvasGroup canvasGroup;

    //void Start () {
    //    playVideo1.loopPointReached += EndReached;
    //    playVideo1.Play();

    //    // 开始播放背景音乐
    //    Invoke("PlayBgSound", 2f);

    //    // 测试8改1
    //    Invoke("DisplayUI", 8f);
    //}

    public void OnMainVido()
    {
        playVideo1.loopPointReached += EndReached;
        playVideo1.Play();

        // 开始播放背景音乐
        Invoke("PlayBgSound", 2f);

        // 测试8改1
        Invoke("DisplayUI", 8f);
    }

    private void PlayBgSound()
    {
        gameManagers.PlayBgSound();
    }

    // 显示UI
    private void DisplayUI()
    {
        gameManagers.OnStart();
    }

    // 监听视频播放完毕
    private void EndReached(VideoPlayer vPlayer)
    {
        playVideo1.loopPointReached -= EndReached;
        playVideo2.Play();
    }

    // 隐藏视频
    public void HideVoide()
    {
        playVideo2.targetCameraAlpha = 0;
    }

    // 重新播放循环视频
    public void PlayXunhuan()
    {
        playVideo2.Play();
        StartCoroutine("DisplayXunhuan");
        Invoke("DisplayUI", 1f);
    }

    IEnumerator DisplayXunhuan()
    {
        while (playVideo2.targetCameraAlpha < 1)
        {
            playVideo2.targetCameraAlpha = playVideo2.targetCameraAlpha + 0.01f;
            yield return 0;
        }
    }
}
