using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishuSpines : MonoBehaviour {
    public SkeletonGraphic skeletonGraphic;
    public HamsterBtns hamsterBtns;

    private string animName;
    private Spine.AnimationState animState;

    void Start()
    {
        animState = skeletonGraphic.AnimationState;
        // 01chudong 02rudong 03zhuazhu daiji
        animName = "01chudong";
        animState.Complete += End01;
        animState.SetAnimation(0, animName, false);
    }

    // 动作1播放结束
    private void End01(Spine.TrackEntry trackEntry)
    {
        switch (animName)
        {
            case "01chudong":
                PlayAnim("02rudong");
                break;
            case "02rudong":
                Hide();
                break;
            case "03zhuazhu":
                PlayAnim("daiji");
                hamsterBtns.ClickDishu();
                break;
            case "daiji":
                Hide();
                //PlayAnim("02rudong");
                hamsterBtns.SetIsClick();
                break;
        }
    }

    // 播放指定动画
    private void PlayAnim(string name)
    {
        animName = name;
        animState.SetAnimation(0, animName, false);
    }

    // 播放3动画
    public void Play03()
    {
        RefreshPose();
        PlayAnim("03zhuazhu");
        //Invoke("Chui", 0.2f);
    }

    // 锤击做延迟
    private void Chui()
    {
        PlayAnim("03zhuazhu");
    }

    // 消除动画影响
    private void RefreshPose()
    {
        skeletonGraphic.Skeleton.SetToSetupPose();
        //animState.SetEmptyAnimations(1);
        animState.ClearTracks();
    }

    // 隐藏地鼠
    public void Hide()
    {
        hamsterBtns.Hide();
    }

    // 显示地鼠
    public void Display()
    {
        //RefreshPose();
        //animState.SetEmptyAnimations(1);
        //animState.ClearTracks();
        //hamsterBtns.Display();
        PlayAnim("01chudong");
    }
}
