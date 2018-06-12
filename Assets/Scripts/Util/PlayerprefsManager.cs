using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerprefsManager : ISingleton<PlayerprefsManager> {

    #region Base

    private static int LoadData(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    private static float LoadData(string key, float defaultValue = 0)
    {
        return PlayerPrefs.GetFloat(key, defaultValue);
    }

    private static string LoadData (string key,string defaultValue = "")
    {
        return PlayerPrefs.GetString(key, defaultValue);
    }

    private static void SaveData(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    private static void SaveData(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    private static void SaveData(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    #endregion

    public static int LoadRoleLevel (int roleId)
    {
        return LoadData(roleId + "_Level", 1);
    }

    public static void SaveRoleLevel (int roleId,int level)
    {
        SaveData(roleId + "_Level", level);
    }
}
