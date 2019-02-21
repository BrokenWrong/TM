using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicks : MonoBehaviour {
    public ChuiAnims chuiAnims;

    // 锤音效
    public AudioSource audioSource;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            chuiAnims.Play(Input.mousePosition);
        }
    }
}
