using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : ISingleton<ResourceManager> {

    public static string LoadJsonData (string name)
    {
        //加载Resource目录下
        string path = string.Format("Data/" + name);
        TextAsset ta = Resources.Load<TextAsset>(path);
        return ta.text;

        //加载AB
        //TODO
    }

    private static Sprite LoadUISprite(string name)
    {
        //加载Resource目录下
        string path = string.Format("UI/" + name);
        Sprite ta = Resources.Load<Sprite>(path);
        return ta;

        //加载AB
        //TODO
    }

    public static Sprite LoadRoleHeadSprite(string headId)
    {
        return LoadUISprite("Role/" + headId);
    }
}
