using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumClockAnimation : MonoBehaviour {
    float radian = 0; // 弧度
    float perRadian = 0.03f; // 每次变化的弧度
    float radius = 5f; // 半径
    Vector3 oldPos; // 开始时候的坐标
                    // Use this for initialization
    private bool isPlay = false;

    private CanvasGroup canvasGroup;

    void Start()
    {
        /*canvasGroup = transform.GetComponent<CanvasGroup>();
        oldPos = transform.localEulerAngles; // 将最初的位置保存到oldPos
        float t = UnityEngine.Random.Range(0, 200) * 0.01f;
        Invoke("SetIsPlay", t);*/
    }

    public void OnAnim()
    {
        canvasGroup = transform.GetComponent<CanvasGroup>();
        oldPos = transform.localEulerAngles; // 将最初的位置保存到oldPos
        float t = UnityEngine.Random.Range(0, 200) * 0.01f;
        Invoke("SetIsPlay", t);
    }

    private void SetIsPlay()
    {
        isPlay = true;
        canvasGroup.interactable = true;
        StartCoroutine("Display");
    }

    IEnumerator Display()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha = canvasGroup.alpha + 0.01f;
            yield return 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay == false) return;
        radian += perRadian; // 弧度每次加0.03
        float dy = Mathf.Cos(radian) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以
        transform.localEulerAngles = oldPos + new Vector3(0, 0, dy);
    }

    public void SetCanvasGroup()
    {
        canvasGroup = transform.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        oldPos = transform.localEulerAngles; // 将最初的位置保存到oldPos
        float t = UnityEngine.Random.Range(0, 60) * 0.01f;
        Invoke("SetIsPlay", t);
    }
}
