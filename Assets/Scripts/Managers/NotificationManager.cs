/****************************************************************
 *Copyright(C)  2018 by YYGame All rights reserved. 
 *FileName:     NotificationManager.cs 
 *Author:       Hoo
 *Version:      1.0 
 *UnityVersion: 2017.3.1f1 
 *Date:         2018-04-20 11:03 
 *Description:  消息管理类
 *History: 
*****************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void NotificationEventHandler(Notification notification);

public class NotificationManager : YYSingleton<NotificationManager> 
{
    Dictionary<uint, NotificationEventHandler> _eventListeners = new Dictionary<uint, NotificationEventHandler>();

    /// <summary>
    /// 注册监听事件
    /// </summary>
    /// <param name="eventKey"></param>
    /// <param name="handler"></param>
    public void AddEventListener(uint eventKey, NotificationEventHandler handler)
    {
        if (!HasEventListener(eventKey))
        {
            NotificationEventHandler eventHandler = null;
            _eventListeners[eventKey] = eventHandler;
        }
        _eventListeners[eventKey] += handler;
    }

    /// <summary>
    /// 移除监听事件
    /// </summary>
    /// <param name="eventKey"></param>
    public void RemoveEventListener(uint eventKey)
    {
        _eventListeners.Remove(eventKey);
    }
    public void RemoveEventListener(uint eventKey, NotificationEventHandler handler)
    {
        if (!HasEventListener(eventKey))
            return;

        _eventListeners[eventKey] -= handler;

        if (_eventListeners[eventKey] == null)
            RemoveEventListener(eventKey);
    }

    /// <summary>
    /// 分发事件
    /// </summary>
    /// <param name="eventKey"></param>
    public void DispatchEvent(uint eventKey)
    {
        if (!HasEventListener(eventKey))
            return;
        _eventListeners[eventKey](new Notification());
    }
    public void DispatchEvent(uint eventKey, EventArgs args)
    {
        if (!HasEventListener(eventKey))
            return;
        _eventListeners[eventKey](new Notification(args));
    }
    public void DispatchEvent(uint eventKey, GameObject sender, EventArgs args)
    {
        if (!HasEventListener(eventKey))
            return;
        _eventListeners[eventKey](new Notification(sender, args));
    }

    /// <summary>
    /// 是否存在指定事件的监听器
    /// </summary>
    /// <param name="eventKey"></param>
    /// <returns></returns>
    public bool HasEventListener(uint eventKey)
    {
        return _eventListeners.ContainsKey(eventKey);
    }
}

public class Notification
{
    /// <summary>
    /// 消息发送者
    /// </summary>
    public GameObject sender;

    /// <summary>
    /// 消息内容
    /// </summary>
    public EventArgs args;

    public Notification()
    {
        this.sender = null;
        this.args = null;
    }
    public Notification(EventArgs _args)
    {
        this.sender = null;
        this.args = _args;
    }
    public Notification(GameObject _sender, EventArgs _args)
    {
        this.sender = _sender;
        this.args = _args;
    }
}