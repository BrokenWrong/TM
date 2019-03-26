using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleAnimOs : MonoBehaviour {

    // 当前展示动画
    private int currI = -1;

    public void OnAnim()
    {
        GameData.Instance.soundOs.PlayRoleBgm();
        if(currI != GameData.Instance.passCurr)
        {
            currI = GameData.Instance.passCurr;
            DestoryAnim();
            CreateAnim();
        }
    }

    // 消毁动画
    public void DestoryAnim()
    {
        if (transform.childCount == 0) return;
        Destroy(transform.Find("RoleAnim").gameObject);
    }

    // 创建动画
    private void CreateAnim()
    {
        /*if(GameData.Instance.isPatch == false)
        {
            CreateCloneAnim();
            return;
        }*/
        string str = "roleCloneAnim";
        if(GameData.Instance.isPatch == true)
        {
            str = "roleAnim";
        }
        string roleAnim = GameData.Instance.GetCurrPassStr(str);
        GameObject go = Resources.Load(roleAnim, typeof(GameObject)) as GameObject;
        Transform tf = Instantiate(go, transform).transform;
        tf.name = "RoleAnim";
    }

    private void CreateCloneAnim()
    {
        string roleAnim = GameData.Instance.GetCurrPassStr("roleAnim");
        if (roleAnim == "-1") return;
        GameObject go = Resources.Load(roleAnim, typeof(GameObject)) as GameObject;
        Transform tf = Instantiate(go, transform).transform;
        tf.name = "RoleAnim";
    }
}
