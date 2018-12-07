using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScreen : MonoBehaviour
{
    private float width = 720f;
    private float height = 1280f;

    void Awake()
    {
        UpdateCanvasScreen();
    }

    public void UpdateCanvasScreen()
    {
        Vector3 vec3 = transform.localScale;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        vec3.x = vec3.y * (screenWidth / width) / (screenHeight / height);
        transform.localScale = vec3;
    }
}
