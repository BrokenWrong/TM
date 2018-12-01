/****************************************************************
 *Copyright(C)  2018 by YYGame All rights reserved. 
 *FileName:     YYSingleton.cs 
 *Author:       Hoo
 *Version:      1.0 
 *UnityVersion: 2017.3.1f1 
 *Date:         2018-04-17 14:16 
 *Description:  单例模板  
 *History: 
*****************************************************************/

public class YYSingleton<T> where T : class, new() 
{
    private static T _instance;

    // 用于lock块的对象
    private static readonly object _synclock = new object();
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_synclock)
                {
                    if (_instance == null)
                    {
                        // 若T class具有私有构造函数，那么则无法使用YYSingleton<T>来实例化new T();
                        _instance = new T();
                    }
                }
            }
            return _instance;
        }
    }
}
