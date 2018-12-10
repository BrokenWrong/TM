/****************************************************************
 *Copyright(C)  2018 by #COMPANY# All rights reserved. 
 *FileName:     #SCRIPTFULLNAME# 
 *Author:       Wen
 *Version:      #VERSION# 
 *UnityVersion: #UNITYVERSION# 
 *Date:         #DATE# 
 *Description:    
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour 
{
    public GameObject MainO;
    public GameObject PlayO;
    public GameObject EndO;

    public Transform canvasTf;

    private GameObject playG;

    void Start()
    {
        MainO.SetActive(true);
    }

    public void StartClick()
    {
        MainO.SetActive(false);

        playG = Instantiate(PlayO, canvasTf);
        playG.transform.Find("KuaiO").GetComponent<KuaiOs>().OnPlay(transform);
    }

    public void RetryClick()
    {
        EndO.SetActive(false);

        playG = Instantiate(PlayO, canvasTf);
        playG.transform.Find("KuaiO").GetComponent<KuaiOs>().OnPlay(transform);
    }

    public void LoadEndO()
    {
        EndO.SetActive(true);
    }
}
