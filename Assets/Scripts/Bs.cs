/****************************************************************
 *Copyright(C)  2018 by #COMPANY# All rights reserved. 
 *FileName:     #SCRIPTFULLNAME# 
 *Author:       Wen
 *Version:      #VERSION# 
 *UnityVersion: #UNITYVERSION# 
 *Date:         #DATE# 
 *Description:    
 *History: 
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bs : MonoBehaviour 
{
    public Rigidbody2D r2D;

    public Transform[] Walls;

    public Vector2 vec2 = new Vector2(0, 0);

    public Transform RoleWallO;
    public GameObject RoleWallImg;

    public float tileF = 0;

    public float touchF = 0;
    public float ctouchF = 0;

    public GameObject EnemyImg2;

    void Start()
    {
        r2D.velocity = vec2;
    }

    void Update()
    {
        InputTouch();
        UpdateR2d();
    }

    private void UpdateR2d()
    {
        float x = (r2D.velocity.x > 0) ? vec2.x : -vec2.x;
        float y = (r2D.velocity.y > 0) ? vec2.y : -vec2.y;
        r2D.velocity = new Vector2(x, y);
    }

    private void InputTouch()
    {
        /*if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            WallMove(0);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            WallMove(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            WallMove(2);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            WallMove(3);
        }*/



        ctouchF = ctouchF + Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && ctouchF >= touchF)
        {
            ctouchF = 0;
            AddRoleWall();
        }
    }

    private void AddRoleWall()
    {
        //GameObject go = Instantiate(RoleWallImg, RoleWallO);
        //go.transform.localPosition = Input.mousePosition - new Vector3(960, 540, 0);
        //Destroy(go, tileF);

        GameObject go = Instantiate(EnemyImg2, RoleWallO);
        //go.transform.localPosition = Input.mousePosition - new Vector3(960, 540, 0);
        go.GetComponent<EnemyImg2s>().OnEnemy(Input.mousePosition);
        Destroy(go, tileF);
    }

    public void WallMove(int index)
    {
        float x = transform.localPosition.x;
        float y = transform.localPosition.y;

        switch (index)
        {
            case 0:
                y += 20;
                y = (y > 545) ? 545 : y;
                break;
            case 1:
                y -= 20;
                y = (y < -545) ? -545 : y;
                break;
            case 2:
                x -= 20;
                x = (x < -965) ? -965 : x;
                break;
            case 3:
                x += 20;
                x = (x > 965) ? 965 : x;
                break;
        }

        Walls[index].localPosition = new Vector3(x, y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Walls[0].localPosition = new Vector3(0, 545, 0);
        Walls[1].localPosition = new Vector3(0, -545, 0);
        Walls[2].localPosition = new Vector3(-965, 0, 0);
        Walls[3].localPosition = new Vector3(965, 0, 0);
    }
}
