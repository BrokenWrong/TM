/****************************************************************
 *Copyright(C)  2018 by YYGame All rights reserved. 
 *FileName:     ConfigManager.cs 
 *Author:       Hoo
 *Version:      1.0 
 *UnityVersion: 2017.3.1f1 
 *Date:         2018-04-17 14:24 
 *Description:  配置文件管理类  
 *History: 
*****************************************************************/

using LitJson;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigManager : YYSingleton<ConfigManager> 
{
    private Dictionary<string, JsonData> _configDict = new Dictionary<string, JsonData>();

    /// <summary>
    /// 解析配置文件
    /// </summary>
    /// <param name="name">配置文件路径</param>
    /// <returns></returns>
    public JsonData ParseConfig(string name)
    {
        if (!_configDict.ContainsKey(name))
        {
            //TextAsset _textAsset = Resources.Load<TextAsset>(name);
            //if (_textAsset != null)
            //{
            //    using (StreamReader sr = new StreamReader(new MemoryStream(_textAsset.bytes)))
            //    {
            //        string json = sr.ReadToEnd();
            //        JsonData _data = JsonMapper.ToObject(json);
            //        _configDict[name] = _data;
            //        Debug.Log(JsonMapper.ToJson(_data));
            //        sr.Close();
            //        return _data;
            //    }
            //}

            TextAsset _textAsset = Resources.Load<TextAsset>(name);
            JsonData _data = JsonMapper.ToObject(_textAsset.text);
            _configDict[name] = _data;
            return _data;
        }

        return _configDict[name];
    }

    /// <summary>
    /// 缓存中是否有此配置
    /// </summary>
    /// <param name="name">配置文件名</param>
    /// <returns></returns>
    public bool HasConfig(string name)
    {
        return _configDict.ContainsKey(name);
    }
}
