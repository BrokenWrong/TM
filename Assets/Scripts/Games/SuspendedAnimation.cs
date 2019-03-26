using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspendedAnimation : MonoBehaviour {

    float radian = 0; // 弧度
    float perRadian = 0.02f; // 每次变化的弧度
    float radius = 30f; // 半径
    Vector3 oldPos; // 开始时候的坐标
                    // Use this for initialization
    private bool isPlay = false;

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = transform.GetComponent<CanvasGroup>();
        oldPos = transform.localPosition; // 将最初的位置保存到oldPos
        float t = UnityEngine.Random.Range(0, 200) * 0.01f;
        Invoke("SetIsPlay", t);
    }

    private void SetIsPlay()
    {
        isPlay = true;
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
    }

    private Vector3 CalcPosition(float r, float i, int cnt, int selectIndex)
    {
        Vector3 pos = new Vector3();
        float f = (-2.0f * i / cnt - 0.5f) * Mathf.PI + 2 * Mathf.PI * selectIndex / cnt;
        pos.x = r * Mathf.Cos(f);
        pos.z = r * Mathf.Sin(f);
        //
        pos.y = transform.position.y;
        return pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay == false) return;
        radian += perRadian; // 弧度每次加0.03
        float dy = Mathf.Cos(radian) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以
        float dx = Mathf.Cos(radian * 2) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以
        transform.localPosition = oldPos + new Vector3(dx, dy, 0);
        //transform.localPosition = CalcPosition(100, 100, 100, 100);
    }
}
