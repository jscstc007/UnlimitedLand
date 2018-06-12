using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FPSType
{
    FPS_1 = 1,
    FPS_30 = 30,
    FPS_60 = 60,
}

public class SettingManager : ISingleton<SettingManager> {

    /// <summary>
    /// 设置帧率
    /// </summary>
	public static void SetFPS (FPSType type)
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = (int)type;
    }

    /// <summary>
    /// 设置不息屏
    /// </summary>
    public static void SetNeverSleep()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
