using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passs : MonoBehaviour {
    private Vector3[] vec3VA =
    {
        new Vector3(-630, -70, 0), new Vector3(-581, -370, 0), new Vector3(-279, -65, 0),
        new Vector3(11, -88, 0), new Vector3(42, 259, 0), new Vector3(108, -335, 0),
        new Vector3(436, 366, 0), new Vector3(716, 148, 0), new Vector3(695, -195, 0),
        new Vector3(472, -437, 0),
    };
    public GameObject CheckBtn;
    public Transform Check;

    // Use this for initialization
    void Start () {
        LoadCheckBtn();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadCheckBtn()
    {
        for (int i = 0; i < vec3VA.Length; i++)
        {
            Transform tf = Instantiate(CheckBtn, Check).transform;
            tf.localPosition = vec3VA[i];
        }
    }
}
