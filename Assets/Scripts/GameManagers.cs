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

    public Transform Play;

    private GameObject playG;

    private int timeI = 0;

    public GameObject QuitText;
    public Transform canvasTf;
    private GameObject qText;

    void Start()
    {
        MainO.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadQuitText();
            if(timeI > 0 && timeI < 100)
            {
                Application.Quit();
            }
            timeI = 1;
        }
        if(timeI > 0)
        {
            timeI++;
        }
    }

    private void LoadQuitText()
    {
        if (qText != null) return;
        GameObject go = Instantiate(QuitText, canvasTf);
        qText = go;
        Destroy(go, 1);
    }

    public void StartClick()
    {
        MainO.SetActive(false);

        playG = Instantiate(PlayO, Play);
        playG.transform.Find("KuaiO").GetComponent<KuaiOs>().OnPlay(transform);
    }

    public void RetryClick()
    {
        Destroy(playG);

        EndO.SetActive(false);

        playG = Instantiate(PlayO, Play);
        playG.transform.Find("KuaiO").GetComponent<KuaiOs>().OnPlay(transform);
    }

    public void LoadEndO()
    {
        EndO.SetActive(true);
    }
}
