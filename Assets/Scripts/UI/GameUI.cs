using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameUIType
{
    None = -1,
    Fight,
    Team,
    Factory,
    Setting,
}

public class GameUI : BaseUI {

    private Transform fightP;
    private Transform teamP;
    private Transform factoryP;
    private Transform settingP;

    private GameUIType uiType = GameUIType.None;

    public override UIType GetUIType()
    {
        return UIType.GameUI;
    }

    public override void OnAwake()
    {
        base.OnAwake();

        fightP = CacheTransform.Find("Main_P/Fight_P");
        teamP = CacheTransform.Find("Main_P/Team_P");
        factoryP = CacheTransform.Find("Main_P/Factory_P");
        settingP = CacheTransform.Find("Main_P/Setting_P");

        UIManager.SetUITrans(CacheRectTransform);
    }

    public override void OnStart()
    {
        base.OnStart();
        //注册UI事件
        RegistUI();
        //默认初始化为战斗界面
        ShowUI(GameUIType.Fight);

    }

    public override void SetUI(params object[] objs)
    {
        base.SetUI(objs);
    }

    public override void OnRelease()
    {
        base.OnRelease();

        Util.Log("GameUI OnRelease");
    }

    /// <summary>
    /// 注册UI事件
    /// </summary>
    private void RegistUI()
    {
        //主按钮
        CacheTransform.Find("Func_P/Fight_B").GetComponent<Button>().onClick.AddListener(() => { OnClick_UIType(GameUIType.Fight); });
        CacheTransform.Find("Func_P/Team_B").GetComponent<Button>().onClick.AddListener(() => { OnClick_UIType(GameUIType.Team); });
        CacheTransform.Find("Func_P/Factory_B").GetComponent<Button>().onClick.AddListener(() => { OnClick_UIType(GameUIType.Factory); });
        CacheTransform.Find("Func_P/Setting_B").GetComponent<Button>().onClick.AddListener(() => { OnClick_UIType(GameUIType.Setting); });
    }

    /// <summary> 点击了按钮 切换UI类别 </summary> 
    private void OnClick_UIType (GameUIType gameUIType)
    {
        CloseUI(uiType);
        uiType = gameUIType;
        ShowUI(uiType);
    }

    /// <summary> 显示并刷新特定类别的UI </summary> 
    private void ShowUI(GameUIType gameUIType)
    {
        switch (gameUIType)
        {
            case GameUIType.Fight:
                fightP.gameObject.SetActive(true);
                //TODO
                break;
            case GameUIType.Team:
                teamP.gameObject.SetActive(true);
                //TODO
                break;
            case GameUIType.Factory:
                factoryP.gameObject.SetActive(true);
                //TODO
                break;
            case GameUIType.Setting:
                settingP.gameObject.SetActive(true);
                //TODO
                break;
            default:
                break;
        }
    }
    /// <summary> 关闭特定类别的UI </summary> 
    private void CloseUI(GameUIType gameUIType)
    {
        switch(gameUIType)
        {
            case GameUIType.Fight:
                fightP.gameObject.SetActive(false);
                break;
            case GameUIType.Team:
                teamP.gameObject.SetActive(false);
                break;
            case GameUIType.Factory:
                factoryP.gameObject.SetActive(false);
                break;
            case GameUIType.Setting:
                settingP.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
