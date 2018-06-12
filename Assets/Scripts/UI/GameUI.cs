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

        areaSelectP = fightP.Find("AreaSelect_P");
        fightSceneP = fightP.Find("Fight_P");

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

                InitMemberUI();
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

    #region 战斗模块

    private Transform areaSelectP;
    private Transform fightSceneP;

    /// <summary>
    /// 显示区域选择场景
    /// </summary>
    private void ShowAreaSelectP ()
    {
        areaSelectP.gameObject.SetActive(true);
        fightSceneP.gameObject.SetActive(false);
    }
    /// <summary>
    /// 显示战斗场景
    /// </summary>
    private void ShowFightSceneP ()
    {
        areaSelectP.gameObject.SetActive(false);
        fightSceneP.gameObject.SetActive(true);
    }

    #endregion

    #region 队伍模块
    
    /// <summary>
    /// 初始化队伍UI
    /// </summary>
    public void InitMemberUI ()
    {
        //更新所选角色列表信息(目前仅考虑主角)
        Image headI = teamP.Find("Member_P/Item/Head_I").GetComponent<Image>();
        Text nameT = teamP.Find("Member_P/Item/Name_T").GetComponent<Text>();
        Text levelT = teamP.Find("Member_P/Item/Level_T").GetComponent<Text>();
        Text professionT = teamP.Find("Member_P/Item/Profession_T").GetComponent<Text>();
        Text hpT = teamP.Find("Member_P/Item/HP_T").GetComponent<Text>();
        Text strT = teamP.Find("Member_P/Item/Str_T").GetComponent<Text>();
        Text agiT = teamP.Find("Member_P/Item/Agi_T").GetComponent<Text>();
        Text intT = teamP.Find("Member_P/Item/Int_T").GetComponent<Text>();
        Text speedT = teamP.Find("Member_P/Item/Speed_T").GetComponent<Text>();
        Text infoT = teamP.Find("Member_P/Item/Info_T").GetComponent<Text>();

        BaseRoleData data = RoleDataInfo.Instance.GetRoleData(RoleDataInfo.MainRoleId);

        headI.sprite = ResourceManager.LoadRoleHeadSprite(data.Head);
        nameT.text = data.RoleName;
        levelT.text = string.Format("Lv{0}", data.Level);
        professionT.text = RoleDataInfo.GetProfessionName(data.Profession);
        hpT.text = string.Format("生命:{0}",data.MaxHP);
        strT.text = string.Format("力量:{0}", data.Str);
        agiT.text = string.Format("敏捷:{0}", data.Agi);
        intT.text = string.Format("智力:{0}", data.Intelligence);
        speedT.text = string.Format("速度:{0}", data.Speed);
        infoT.text = data.Info;
    }

    #endregion

    #region 工坊模块
    //TODO
    #endregion

    #region 设置模块
    //TODO
    #endregion
}
