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

    private int[] leftIA;
    private int[] rightIA;

    private bool isMoveB = false;
    private int currTouchI = -1;
    private int shangciplayI = -2;
    private bool isXiao = false;

    public Image[] BgImgs;

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
        leftIA = new int[]
        {
            12, 8, 4, 0, 13, 9, 5, 1, 14, 10, 6, 2, 15, 11, 7, 3
        };
        rightIA = new int[]
        {
            3, 7, 11, 15, 2, 6, 10, 14, 1, 5, 9, 13, 0, 4, 8, 12
        };
    }

    void Start()
    {
        LoadKuai(4);
    }

    void Update()
    {
        InputKey();
    }

    private void InputKey()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log(111);
            UpMove();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
        }
    }
    private void Ss()
    {
        for (int i = 0; i < isHave.Length; i++)
        {
            //if(!isHave[i])
            //Debug.Log(i.ToString() + " : " + isHave[i]);
        }
    }
    private void UpMove()
    {
        int index = 0;
        bool isMove = false;
        for (int i = 4; i < 16; i++)
        {
            if (isHave[i])
            {
                index = i;
                isMove = false;
                while (index > 3)
                {
                    index = index - 4;
                    if (isHave[index])
                    {
                        index = index + 4;
                        break;
                    }
                    else
                    {
                        isMove = true;
                    }
                    kuaiTf[i].localPosition = vec3VS[index];
                }
                if(isMove)
                {
                    isMoveB = true;
                    Img1.GetComponent<Img1s>().id = index;
                    isHave[i] = false;
                    isHave[index] = true;
                    kuaiTf[index] = kuaiTf[i];
                }
            }
        }
    }
    private void DownMove()
    {
        int index = 0;
        bool isMove = false;
        for (int i = 11; i >= 0; i--)
        {
            if (isHave[i])
            {
                index = i;
                isMove = false;
                while (index < 12)
                {
                    index = index + 4;
                    if (isHave[index])
                    {
                        index = index - 4;
                        break;
                    }
                    else
                    {
                        isMove = true;
                    }
                    kuaiTf[i].localPosition = vec3VS[index];
                }
                if (isMove)
                {
                    isMoveB = true;
                    Img1.GetComponent<Img1s>().id = index;
                    isHave[i] = false;
                    isHave[index] = true;
                    kuaiTf[index] = kuaiTf[i];
                }
            }
        }
    }
    private void LeftMove()
    {
        int index = 0;
        bool isMove = false;
        for (int i = 4; i < leftIA.Length; i++)
        {
            int ia = leftIA[i];
            int eia = leftIA[i];
            if (isHave[ia])
            {
                index = i;
                isMove = false;
                while (index > 3)
                {
                    index = index - 4;
                    eia = leftIA[index];
                    if (isHave[eia])
                    {
                        index = index + 4;
                        eia = leftIA[index];
                        break;
                    }
                    else
                    {
                        isMove = true;
                    }
                    kuaiTf[ia].localPosition = vec3VS[eia];
                }
                if (isMove)
                {
                    isMoveB = true;
                    Img1.GetComponent<Img1s>().id = eia;
                    isHave[ia] = false;
                    isHave[eia] = true;
                    kuaiTf[eia] = kuaiTf[ia];
                }
            }
        }
    }
    private void RightMove()
    {
        int index = 0;
        bool isMove = false;
        for (int i = 4; i < rightIA.Length; i++)
        {
            int ia = rightIA[i];
            int eia = rightIA[i];
            if (isHave[ia])
            {
                index = i;
                isMove = true;
                while (index > 3)
                {
                    index = index - 4;
                    eia = rightIA[index];
                    if (isHave[eia])
                    {
                        index = index + 4;
                        eia = rightIA[index];
                        break;
                    }
                    else
                    {
                        isMove = true;
                    }
                    kuaiTf[ia].localPosition = vec3VS[eia];
                }
                if (isMove)
                {
                    isMoveB = true;
                    Img1.GetComponent<Img1s>().id = eia;
                    isHave[ia] = false;
                    isHave[eia] = true;
                    kuaiTf[eia] = kuaiTf[ia];
                }
            }
        }
    }
    private void UpHc()
    {
        UpAll(new int[] { 0, 4, 8, 12 });
        UpAll(new int[] { 1, 5, 9, 13 });
        UpAll(new int[] { 2, 6, 10, 14 });
        UpAll(new int[] { 3, 7, 11, 15 });
    }
    private void DwonHc()
    {
        UpAll(new int[] { 15, 11, 7, 3 });
        UpAll(new int[] { 14, 10, 6, 2 });
        UpAll(new int[] { 13, 9, 5, 1 });
        UpAll(new int[] { 12, 8, 4, 0 });
    }
    private void LeftHc()
    {
        UpAll(new int[] { 0, 1, 2, 3 });
        UpAll(new int[] { 4, 5, 6, 7 });
        UpAll(new int[] { 8, 9, 10, 11 });
        UpAll(new int[] { 12, 13, 14, 15 });
    }
    private void RightHc()
    {
        UpAll(new int[] { 3, 2, 1, 0 });
        UpAll(new int[] { 7, 6, 5, 4 });
        UpAll(new int[] { 11, 10, 9, 8 });
        UpAll(new int[] { 15, 14, 13, 12 });
    }
    private void UpAll(int[] all)
    {
        for (int i = 0; i < all.Length - 1; i++)
        {
            int id = all[i];
            int eid = all[i + 1];
            if (isHave[id])
            {
                if (isHave[eid])
                {
                    if (kuaiTf[id].GetComponent<Img1s>().level == kuaiTf[eid].GetComponent<Img1s>().level && kuaiTf[id].GetComponent<Img1s>().level < 16)
                    {
                        isMoveB = true;
                        isXiao = true;

                        Img1s img1 = kuaiTf[id].GetComponent<Img1s>();
                        img1.level++;
                        img1.UpDateTextLevel();

                        Destroy(kuaiTf[eid].gameObject);
                        isHave[eid] = false;

                        i++;
                    }
                }
                else
                {
                    return;
                }
            }
        }
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
    private void Play()
    {
        if (shangciplayI == currTouchI && !isXiao)
        {
            return;
        }
        shangciplayI = currTouchI;
        bool ish = false;
        for (int i = 0; i < 16; i++)
        {
            if(!isHave[i])
            {
                ish = true;
            }
        }
        if(!ish)
        {
            Debug.Log("end");
            return;
        }
        int index = UnityEngine.Random.Range(0, 16);
        while (isHave[index])
        {
            index = UnityEngine.Random.Range(0, 16);
        }
        LoadKuai(index);
    }

    private void LoadKuai(int i)
    {
        isMoveB = true;
        isHave[i] = true;
        Transform tf = Instantiate(Img1, transform).transform;
        tf.localPosition = vec3VS[i];
        tf.GetComponent<Img1s>().OnImg(i,transform);
        kuaiTf[i] = tf;
    }

    private void Handle()
    {
        bool isHandle = true;
        while (isHandle)
        {
            isHandle = ToHandle();
        }
        for (int i = 0; i < 16; i++)
        {
            if (isHave[i])
            {
                Img1s img = kuaiTf[i].GetComponent<Img1s>();
                if(img.UpDateTextLevel())
                {
                    isMoveB = true;
                    Handle();
                }
            }
        }
    }
    private bool ToHandle()
    {
        bool isHandle = false;
        for (int i = 0; i < 16; i++)
        {
            if (isHave[i])
            {
                Img1s img = kuaiTf[i].GetComponent<Img1s>();
                if (img.level - 1 == i)
                {
                    isHandle = true;
                    BgImgs[i].enabled = true;
                    img.UpDateTextLevel();
                    isMoveB = true;
                }
            }
        }
        return isHandle;
    }
}
