using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour {
    public GameObject Begin;
    public GameObject Pass;
    public GameObject Play;
    //private Passs passs;

    void Awake()
    {
        //passs = Pass.transform.GetComponent<Passs>();
    }

    void Start () {
        Begin.SetActive(true);
    }

    void Update () {
		
	}

    public void BeginClick()
    {
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
}
