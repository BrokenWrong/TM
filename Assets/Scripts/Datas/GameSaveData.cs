/****************************************************************
 *Copyright(C)  2018 by YYGame All rights reserved. 
 *FileName:     GameSaveData.cs 
 *Author:       Wen
 *Version:      1.0 
 *UnityVersion: 2017.4.0f1 
 *Date:         2018-11-23 15:48 
 *Description:  游戏存档
 *History: 
*****************************************************************/

using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
//using UnityEditor;
using UnityEngine;

public static class GameSaveData
{
    public static void Save(FileInfo fileInfo, Dictionary<string, string> dict)
    {
        StreamWriter sw = fileInfo.CreateText();
        string json = JsonMapper.ToJson(dict);

        // 加密
        //json = Encrypt(json);

        sw.WriteLine(json);
        sw.Close();
        sw.Dispose();

        //AssetDatabase.Refresh();
    }
    public static void SaveData(string file, string[] strArr1, string[] strArr2)
    {
        Dictionary<string, string> _dict = new Dictionary<string, string>();
        string filePath = Application.persistentDataPath + "/" + file;
        FileInfo fileInfo = new FileInfo(filePath);
        for (int i = 0; i < strArr1.Length; i++)
        {
            _dict[strArr1[i]] = strArr2[i];
        }
        Save(fileInfo, _dict);
    }

    public static Dictionary<string, string> ObtainData(string file, string[] strArr1, string[] strArr2)
    {
        Dictionary<string, string> _dict = new Dictionary<string, string>();
        string filePath = Application.persistentDataPath + "/" + file;
        FileInfo fileInfo = new FileInfo(filePath);
        if (!fileInfo.Exists)
        {
            for (int i = 0; i < strArr1.Length; i++)
            {
                _dict[strArr1[i]] = strArr2[i];
            }
            Save(fileInfo, _dict);
            return _dict;
        }

        byte[] _byData;
        FileStream aFile = fileInfo.OpenRead();
        _byData = new byte[fileInfo.Length];
        aFile.Seek(0, SeekOrigin.Begin);
        aFile.Read(_byData, 0, (int)fileInfo.Length);
        aFile.Close();
        string _str = Encoding.Default.GetString(_byData);

        // 解密
        /*try
        {
            _str = Decrypt(_str);
        }
        catch (Exception)
        {
            for (int i = 0; i < strArr1.Length; i++)
            {
                _dict[strArr1[i]] = strArr2[i];
            }
            Save(fileInfo, _dict);
            return _dict;
        }*/

        JsonData jsdata3 = new JsonData();

        try
        {
            jsdata3 = JsonMapper.ToObject(_str);
        }
        catch (Exception)
        {
            for (int i = 0; i < strArr1.Length; i++)
            {
                _dict[strArr1[i]] = strArr2[i];
            }
            Save(fileInfo, _dict);
            return _dict;
        }

        try
        {
            for (int i = 0; i < strArr1.Length; i++)
            {
                _dict[strArr1[i]] = jsdata3[strArr1[i]].ToString();

            }
        }
        catch (Exception)
        {
            for (int i = 0; i < strArr1.Length; i++)
            {
                _dict[strArr1[i]] = strArr2[i];
            }
            Save(fileInfo, _dict);
            return _dict;
        }
        return _dict;
    }

    // 加密
    private static string Encrypt(string str)
    {
        DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();
        byte[] key = Encoding.Unicode.GetBytes("Yygm");
        byte[] data = Encoding.Unicode.GetBytes(str);
        MemoryStream MStream = new MemoryStream();
        CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);
        CStream.Write(data, 0, data.Length);
        CStream.FlushFinalBlock();
        return Convert.ToBase64String(MStream.ToArray());
    }
    // 解密
    private static string Decrypt(string str)
    {
        DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();
        byte[] key = Encoding.Unicode.GetBytes("Yygm");
        byte[] data = Convert.FromBase64String(str);
        MemoryStream MStream = new MemoryStream();
        CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
        CStream.Write(data, 0, data.Length);
        CStream.FlushFinalBlock();
        return Encoding.Unicode.GetString(MStream.ToArray());
    }
}
