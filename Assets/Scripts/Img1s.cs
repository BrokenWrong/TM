using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Img1s : MonoBehaviour
{
    public int id;
    public Text teLevel;
    public int level = 1;
    public Image img1;

    private KuaiOs kuaiOs;


    private Transform target;
    private bool isMove = false;
    private float speed = 0.1f;
    private float distance;
    private bool isTouch = false;

    public void OnImg(int index, Transform tf)
    {
        kuaiOs = tf.GetComponent<KuaiOs>();
        id = index;

        UpDateTextLevel();
    }

    private void UpDateTextLevel()
    {
        img1.sprite = Resources.Load("Textures/" + level.ToString(), typeof(Sprite)) as Sprite;
        teLevel.text = level.ToString();
    }

    public void Move(Transform tf, bool bl)
    {
        isTouch = bl;
        target = tf;
        distance = Vector2.Distance(transform.localPosition, target.localPosition);
        isMove = true;
    }

    void Update()
    {
        OnMove();
    }
    private void OnMove()
    {
        if (!isMove) return;
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, target.localPosition, (distance / speed) * Time.deltaTime);
        if(transform.localPosition == target.localPosition)
        {
            isMove = false;
            if(isTouch)
            {
                kuaiOs.IsTouch = true;
            }
        }
    }
}
