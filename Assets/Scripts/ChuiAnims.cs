using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuiAnims : MonoBehaviour {
    public SkeletonGraphic skeletonGraphic;
    public CanvasGroup canvasGroup;

    private Spine.AnimationState animState;

    void Start()
    {
        animState = skeletonGraphic.AnimationState;
        animState.Complete += End;
    }

    public void Play(Vector3 vec3)
    {
        transform.localPosition = vec3 + new Vector3(15, 10, 0);

        skeletonGraphic.Skeleton.SetToSetupPose();
        animState.ClearTracks();
        canvasGroup.alpha = 1;
        animState.SetAnimation(0, "animation", false);
    }

    // 动作1播放结束
    private void End(Spine.TrackEntry trackEntry)
    {
        canvasGroup.alpha = 0;
    }
}
