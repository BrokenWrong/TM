using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour {
    public GameObject Begin;
    public GameObject Pass;
    public GameObject Play;
    public SoundOs soundOs;
    //private Passs passs;

    void Awake()
    {
        GameData.Instance();
        //passs = Pass.transform.GetComponent<Passs>();
    }

    void Start () {
        Begin.SetActive(true);
    }

    void Update () {
		
	}

    public void BeginClick()
    {
        soundOs.PlayBtnSound();
        Begin.SetActive(false);
        Pass.SetActive(true);
    }

    public void OnPlay()
    {
        Pass.SetActive(false);
        Play.SetActive(true);
        Play.GetComponent<Plays>().OnPlay();
    }

    public void CgClick()
    {
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
        Begin.SetActive(true);
    }
}
