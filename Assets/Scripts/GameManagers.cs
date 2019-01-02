using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour {
    public GameObject Begin;
    public GameObject Pass;
    private Passs passs;
    // Use this for initialization

    void Awake()
    {
        passs = Pass.transform.GetComponent<Passs>();
    }

    void Start () {
        Begin.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BeginClick()
    {
        Begin.SetActive(false);
        Pass.SetActive(true);
    }
}
