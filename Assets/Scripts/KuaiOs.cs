using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KuaiOs : MonoBehaviour
{
    private Vector3[] vec3VS;
    public GameObject Img1;
    private bool[] isHave;

    private Transform[] kuaiTf;

    public Image[] BgImgs;

    int[][] upArr = new int[][]
    {
        new int[]{ 0, 4, 8, 12 },
        new int[]{ 1, 5, 9, 13 },
        new int[]{ 2, 6, 10, 14 },
        new int[]{ 3, 7, 11, 15 }
    };
    int[][] downArr = new int[][]
    {
        new int[]{ 12, 8, 4, 0 },
        new int[]{ 13, 9, 5, 1 },
        new int[]{ 14, 10, 6, 2 },
        new int[]{ 15, 11, 7, 3 }
    };
    int[][] leftArr = new int[][]
    {
        new int[]{ 0, 1, 2, 3 },
        new int[]{ 4, 5, 6, 7 },
        new int[]{ 8, 9, 10, 11 },
        new int[]{ 12, 13, 14, 15 }
    };
    int[][] rightArr = new int[][]
    {
        new int[]{ 3, 2, 1, 0 },
        new int[]{ 7, 6, 5, 4 },
        new int[]{ 11, 10, 9, 8 },
        new int[]{ 15, 14, 13, 12 }
    };

    public bool IsTouch { get; set; }

    void Awake()
    {
        vec3VS = new Vector3[] 
        {
            new Vector3(-720,  405, 0), new Vector3(-240,  405, 0), new Vector3(240,  405, 0), new Vector3(720,  405, 0),
            new Vector3(-720,  135, 0), new Vector3(-240,  135, 0), new Vector3(240,  135, 0), new Vector3(720,  135, 0),
            new Vector3(-720, -135, 0), new Vector3(-240, -135, 0), new Vector3(240, -135, 0), new Vector3(720, -135, 0),
            new Vector3(-720, -405, 0), new Vector3(-240, -405, 0), new Vector3(240, -405, 0), new Vector3(720, -405, 0)
        };
        isHave = new bool[] 
        {
            false, false, false, false,
            false, false, false, false,
            false, false, false, false,
            false, false, false, false
        };
        kuaiTf = new Transform[16];
        IsTouch = true;
    }

    void Start()
    {
        Begin();
    }

    void Update()
    {
        InputKey();
    }

    private void InputKey()
    {
        if (!IsTouch) return;
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            OnDwon();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnRight();
        }
    }
    private void Ss()
    {
        for (int i = 0; i < isHave.Length; i++)
        {
            if(!isHave[i])
            Debug.Log(i.ToString() + " : " + isHave[i]);
        }
    }
    private void OnUp()
    {
        ToMove(upArr);
    }
    private void OnDwon()
    {
        ToMove(downArr);
    }
    private void OnLeft()
    {
        ToMove(leftArr);
    }
    private void OnRight()
    {
        ToMove(rightArr);
    }

    private void ToMove(int[][] iArr)
    {
        IsTouch = false;
        ArrayList list = new ArrayList();
        for (int i = 0; i < iArr.Length; i++)
        {
            int index = 0;
            for (int j = 0; j < iArr[i].Length; j++)
            {
                if (isHave[iArr[i][j]])
                {
                    if (j != index)
                    {
                        list.Add(iArr[i][j].ToString() + ";" + iArr[i][index].ToString());
                        isHave[iArr[i][j]] = false;
                        isHave[iArr[i][index]] = true;
                    }
                    index++;
                }
            }
        }
        if(list.Count == 0)
        {
            IsTouch = true;
            return;
        }
        Img1Move(list);
    }

    private void Img1Move(ArrayList list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string[] arr = list[i].ToString().Split(';');
            int i1 = int.Parse(arr[0]);
            int i2 = int.Parse(arr[1]);
            kuaiTf[i1].GetComponent<Img1s>().Move(BgImgs[i2].transform, i == list.Count - 1);
            kuaiTf[i2] = kuaiTf[i1];
        }

        AddKuai();
    }

    private void Begin()
    {
        int i1 = UnityEngine.Random.Range(0, 16);
        LoadKuai(i1);

        int i2 = UnityEngine.Random.Range(0, 16);
        if(isHave[i2])
        {
            i2 = (i2 + 1 == 16) ? i2 - 1 : i2 + 1;
        }
        LoadKuai(i2);
    }

    private void AddKuai()
    {
        ArrayList list = new ArrayList();
        for (int i = 0; i < isHave.Length; i++)
        {
            if(!isHave[i])
            {
                list.Add(i);
            }
        }
        if (list.Count == 0)
        {

        }
        int index = UnityEngine.Random.Range(0, list.Count);
        LoadKuai(index);
    }
   
    private void LoadKuai(int i)
    {
        isHave[i] = true;
        Transform tf = Instantiate(Img1, transform).transform;
        tf.localPosition = vec3VS[i];
        tf.GetComponent<Img1s>().OnImg(i,transform);
        kuaiTf[i] = tf;
    }
}
