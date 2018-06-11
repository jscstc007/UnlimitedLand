using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 继承该脚本以形成单例类
/// </summary>
public class ISingleton<T> where T : new() {

    private static T instance;
    public static T Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new T();
            }
            return instance;
        }
    }
}
