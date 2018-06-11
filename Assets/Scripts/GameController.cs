using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModuleType
{
    InitModule = 0,
    GameModule = 1,
}

public class GameController : MonoBehaviour {

    #region 单例
    private static GameController instance;
    public static GameController Instance
    {
        get
        {
            if (null == instance)
            {
                instance = GameObject.Find("/GameManager").GetComponent<GameController>();
            }
            return instance;
        }
    }
    #endregion

    // Use this for initialization
    void Start () {
        //添加不销毁tag
        TagManager.Instance.AddTag(gameObject, TagType.DontDestroy);
        //加载Init模块 Init完成后加载Game模块
        LoadModule(ModuleType.InitModule);
    }

    /// <summary>
    /// 首次进入游戏时 启动Init模块
    /// </summary>
    public void LoadModule(ModuleType moduleType)
    {
        switch(moduleType)
        {
            case ModuleType.InitModule:
                BaseUIManager.Instance.OpenUI(UIType.InitUI, null, null);
                break;
            case ModuleType.GameModule:
                BaseUIManager.Instance.OpenUI(UIType.GameUI, null, null);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 移除Init模块
    /// </summary>
    public void RemoveModule (ModuleType moduleType)
    {
        switch (moduleType)
        {
            case ModuleType.InitModule:
                BaseUIManager.Instance.CloseUI(UIType.InitUI);
                break;
            case ModuleType.GameModule:
                BaseUIManager.Instance.CloseUI(UIType.GameUI);
                break;
            default:
                break;
        }
        
    }
}
