/****************************************************************
 *Copyright(C)  2018 by YeYingGame All rights reserved. 
 *FileName:     YYSingletonMono.cs 
 *Author:       Hoo 
 *Version:      1.0 
 *UnityVersion: 2017.3.0f3 
 *Date:         2018-02-06 14:20
 *Description:  单例类(MonoBehaviour)  
 *History: 
*****************************************************************/

using UnityEngine;

public class YYSingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
                if (_instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    _instance = (T)obj.AddComponent(typeof(T));
                }
            }
            return _instance;
        }
    }
}