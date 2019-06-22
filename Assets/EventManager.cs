using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 事件参数
/// </summary>
/// <param name="key"></param>
/// <param name="param"></param>
public delegate void EventMgr(params object[] param);

/// <summary>
/// 成员方法接口
/// </summary>
public interface IEventMgr
{
    void Register(int key, EventMgr eventMgr);//注册事件

    void UnRegister(int key);//解绑事件

    void ClearAll();//解绑所有事件

    bool IsRegisterName(int key);//key值是否被注册

    bool IsRegisterFunc(EventMgr eventMgr);//eventMgr是否被注册

    void Invoke(int key, params object[] param);//调用
}



/// <summary>
/// time:2019/6/7 22:14
/// author:Sun
/// des:事件管理
///
/// github:https://github.com/KingSun5
/// csdn:https://blog.csdn.net/Mr_Sun88
/// </summary>
public class EventManager:IEventMgr
{
    
    /// <summary>
    /// 存储注册好的事件
    /// </summary>
    protected readonly Dictionary<int,EventMgr> EventListerDict = new Dictionary<int, EventMgr>();

    /// <summary>
    /// 是否暂停所有的事件
    /// </summary>
    public bool IsPause = false;

    /// <summary>
    /// 注册事件
    /// </summary>
    /// <param name="key"></param>
    /// <param name="eventMgr"></param>
    public void Register(int key, EventMgr eventMgr)
    {
        if (EventListerDict.ContainsKey(key))
        {
            Debug.LogError("Key:"+key +"已存在！");
        }
        else
        {
            EventListerDict.Add(key,eventMgr);
        }
    }
    
    /// <summary>
    /// 取消事件绑定
    /// </summary>
    /// <param name="key"></param>
    public void UnRegister(int key)
    {
        if (EventListerDict!=null&&EventListerDict.ContainsKey(key))
        {
            EventListerDict.Remove(key);
            Debug.Log("移除事件："+key);
        }
        else
        {
            Debug.LogError("Key:"+key +"不存在！");
        }
    }
    
    /// <summary>
    /// 取消所有事件绑定
    /// </summary>
    public  void ClearAll()
    {
        if (EventListerDict!=null)
        {
            EventListerDict.Clear();
            Debug.Log("清空注册事件！");
        }
    }

    /// <summary>
    /// ID是否注册过
    /// </summary>
    /// <param name="key"></param>
    public bool IsRegisterName(int key)
    {
        if (EventListerDict!=null&&EventListerDict.ContainsKey(key))
        {
            EventListerDict.Remove(key);
            Debug.Log("事件："+key +"已注册！");
            return true;
        }
        Debug.Log("事件："+key +"未注册！");
        return false;
    }

    /// <summary>
    /// 方法是否注册过
    /// </summary>
    /// <param name="eventMgr"></param>
    public bool IsRegisterFunc(EventMgr eventMgr)
    {
        if (EventListerDict!=null&&EventListerDict.ContainsValue(eventMgr))
        {
            Debug.Log("事件已注册！");
            return true;
        }
        Debug.Log("事件未注册！");
        return false;
    }

    /// <summary>
    /// 调用事件
    /// </summary>
    /// <param name="key"></param>
    /// <param name="param"></param>
    public void Invoke(int key,params object[] param)
    {
        if (!IsPause)
        {
            if (EventListerDict.ContainsKey(key))
            {
                EventListerDict[key].Invoke(param);
            }
            else
            {
                Debug.LogError("事件："+key +"未注册！");
            }
        }
        else
        {
            Debug.LogError("所有事件已暂停！"); 
        }
      
    }


    #region 待做

    /*
	//    public delegate void OnEvent<in T1, in T2>();


    /// <summary>
    /// 保存注册好的事件
    /// </summary>
//    protected Dictionary<string,Action> ActionDict0 = new Dictionary<string, Action>();
//    protected Dictionary<string,Action<T>> ActionDict1 = new Dictionary<string, Action<T>>();
//    protected Dictionary<string,Action> ActionDict2 = new Dictionary<string, Action>();

    /// <summary>
    /// 是否暂停所有的事件
    /// </summary>
    public static bool IsPause = false;


    /// <summary>
    /// 注册事件无参数
    /// </summary>
    /// <param name="eventName"></param> 事件名
    /// <param name="func"></param> 方法
    /// <typeparam name="T"></typeparam>
    public static void Register(string eventName, Action func)
    {
        
    }
    
    /// <summary>
    /// 注册事件一个参数
    /// </summary>
    /// <param name="eventName"></param> 事件名
    /// <param name="func"></param> 方法
    /// <typeparam name="T"></typeparam>
    public static void Register<T>(string eventName, Action<T> func)
    {
    }
    
    /// <summary>
    /// 注册事件两个参数
    /// </summary>
    /// <param name="eventName"></param> 事件名
    /// <param name="func"></param> 方法
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public static void Register<T1,T2>(string eventName, Action<T1,T2> func)
    {
       
    }


    /// <summary>
    /// 注册事件,带返回值，无参数
    /// </summary>
    /// <param name="eventName"></param> 事件名
    /// <param name="func"></param> 方法
    /// <typeparam name="T"></typeparam>
    public static void Register<T>(string eventName, Func<T> func)
    {
       
    }
    
    /// <summary>
    /// 注册事件，带返回值，1个参数
    /// </summary>
    /// <param name="eventName"></param> 事件名
    /// <param name="func"></param> 方法
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public static void Register<T1,T2>(string eventName, Func<T1,T2> func)
    {
       
    }

    /// <summary>
    /// 注册事件，带返回值，2个参数
    /// </summary>
    /// <param name="eventName"></param> 事件名
    /// <param name="func"></param> 方法
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public static void Register<T1,T2,T3>(string eventName, Func<T1,T2,T3> func)
    {
       
    }
    
 


  
    /// <summary>
    /// 取消事件绑定
    /// </summary>
    /// <param name="eventName"></param>
    public static void UnRegister(string eventName)
    {
       
    }
    
 

    /// <summary>
    /// 取消所有事件绑定
    /// </summary>
    public static void ClearAll()
    {
        
    }

    /// <summary>
    /// 暂停所有事件调用
    /// </summary>
    public static void Pause()
    {
        
    }

    /// <summary>
    /// 事件名是否注册过
    /// </summary>
    /// <param name="eventName"></param>
    public static void IsRegisterName(string eventName)
    {
        
    }

    /// <summary>
    /// 方法是否注册过
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    public static void IsRegisterFunc<T>(T func)
    {
        
    }

    /// <summary>
    /// 调用事件
    /// </summary>
    /// <param name="eventName"></param>
    public static void Invoke(string eventName)
    {
        
    }
    
    /// <summary>
    /// 调用事件带返回值
    /// </summary>
    /// <param name="eventName"></param>
    public static T Invoke<T>(string eventName) where T : new()
    {
        return new T();
    }

    /// <summary>
    /// 调用事件带不等参数
    /// </summary>
    /// <param name="eventName"></param>
    public static void Invoke(string eventName,params object[] objs)
    {
        
    }
    
    /// <summary>
    /// 调用事件带不等参数有返回值
    /// </summary>
    /// <param name="eventName"></param>
    public static T Invoke<T>(string eventName,params object[] objs) where T : new()
    {
        return new T();
    }
    
    */

    #endregion



}

