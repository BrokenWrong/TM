using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class MouseClicks : MonoBehaviour {
    public ChuiAnims chuiAnims;

    // 锤音效
    public AudioSource audioSource;

    public Transform CursorImg;

    //void Awake()
    //{
    //    Cursor.visible = false;
    //}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.volume = GameData.Instance.czValue;
            audioSource.Play();
            chuiAnims.Play(Input.mousePosition);
        }
    }

    //void OnGUI()
    //{
    //    Vector3 vec3 = Input.mousePosition;
    //    CursorImg.localPosition = vec3;
    //}
}
