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

    private bool isB = false;

    public void OnImg(int index, Transform tf)
    {
        kuaiOs = tf.GetComponent<KuaiOs>();
        id = index;

        UpDateTextLevel();
    }

    public bool Handle()
    {
        isB = false;
        teLevel.text = level.ToString();
        UpDateImg();
        return isB;
    }

    public bool UpDateTextLevel()
    {
        return Handle();
    }

    private void UpDateImg()
    {
        img1.sprite = Resources.Load("Textures/" + level.ToString(), typeof(Sprite)) as Sprite;
    }
}
