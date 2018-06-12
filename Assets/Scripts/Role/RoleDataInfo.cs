using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public enum ProfessionType
{
    Beginner = 101,

    TreasureHunter = 201,

    Saber = 301,

    Archer = 401,

    Caster = 501,
}

/// <summary>
/// 人物基础数据
/// </summary>
public struct BaseRoleData
{
    public int RoleID;
    public string RoleName;
    public ProfessionType Profession;
    public int Level;
    public int HP;
    public string Head;
    public string Info;

    public int MaxHP
    {
        get
        {
            return MaxHPBase + Level * MaxHPAdd;
        }
    }
    public int MaxHPBase;
    public int MaxHPAdd;
    public int Str
    {
        get
        {
            return StrBase + Level * StrAdd;
        }
    }
    public int StrBase;
    public int StrAdd;
    public int Agi
    {
        get
        {
            return AgiBase + Level * AgiAdd;
        }
    }
    public int AgiBase;
    public int AgiAdd;
    public int Intelligence
    {
        get
        {
            return IntBase + Level * IntAdd;
        }
    }

    public int IntBase;
    public int IntAdd;
    public int Speed
    {
        get
        {
            return SpeedBase + Level * SpeedAdd;
        }
    }
    public int SpeedBase;
    public int SpeedAdd;

    public BaseRoleData(int roleID, string roleName, ProfessionType profession, int level, int hP, string head, string info, int maxHPBase, int maxHPAdd, int strBase, int strAdd, int agiBase, int agiAdd, int intBase, int intAdd, int speedBase, int speedAdd)
    {
        RoleID = roleID;
        RoleName = roleName;
        Profession = profession;
        Level = level;
        HP = hP;
        Head = head;
        Info = info;
        MaxHPBase = maxHPBase;
        MaxHPAdd = maxHPAdd;
        StrBase = strBase;
        StrAdd = strAdd;
        AgiBase = agiBase;
        AgiAdd = agiAdd;
        IntBase = intBase;
        IntAdd = intAdd;
        SpeedBase = speedBase;
        SpeedAdd = speedAdd;
    }

    /// <summary>
    /// 默认血量为最大血量
    /// </summary>
    public BaseRoleData(int roleID, string roleName, ProfessionType profession, int level, string head, string info, int maxHPBase, int maxHPAdd, int strBase, int strAdd, int agiBase, int agiAdd, int intBase, int intAdd, int speedBase, int speedAdd)
    {
        RoleID = roleID;
        RoleName = roleName;
        Profession = profession;
        Level = level;
        HP = maxHPBase + level * maxHPBase;//默认为最大血量
        Head = head;
        Info = info;
        MaxHPBase = maxHPBase;
        MaxHPAdd = maxHPAdd;
        StrBase = strBase;
        StrAdd = strAdd;
        AgiBase = agiBase;
        AgiAdd = agiAdd;
        IntBase = intBase;
        IntAdd = intAdd;
        SpeedBase = speedBase;
        SpeedAdd = speedAdd;
    }
}

public class RoleDataInfo : ISingleton<RoleDataInfo>
{

    public static JsonData originRoleJsonData;
    public static JsonData OriginRoleJsonData
    {
        get
        {
            if (null == originRoleJsonData)
            {
                originRoleJsonData = JsonMapper.ToObject(ResourceManager.LoadJsonData("OriginRoleData"));
            }
            return originRoleJsonData;
        }
    }

    /// <summary>
    /// 主角ID
    /// </summary>
    public const int MainRoleId = 10101;

    /// <summary>
    /// 获取当前进度所拥有的全部角色ID
    /// </summary>
	public int[] RoleMembers
    {
        get
        {
            //TODO 目前仅考虑主角
            return new int[] { MainRoleId };
        }
    }

    private Dictionary<int, BaseRoleData> RoleMemberDataMap = new Dictionary<int, BaseRoleData>();

    /// <summary>
    /// 获取一名角色的属性信息
    /// </summary>
    public BaseRoleData GetRoleData(int roleId)
    {
        //不存在时默认添加一个角色
        if (!RoleMemberDataMap.ContainsKey(roleId))
        {
            BaseRoleData data = InitRoleData(roleId);
            RoleMemberDataMap.Add(roleId, data);
        }
        return RoleMemberDataMap[roleId];
    }

    /// <summary>
    /// 通过RoleID初始化一个角色的BaseRoleData信息(hp默认为最大值)
    /// </summary>
    public BaseRoleData InitRoleData(int roleId)
    {
        string key = roleId.ToString();
        //获取角色的Level
        int roleLevel = PlayerprefsManager.LoadRoleLevel(roleId);
        //获取该角色的基础数据与成长系数
        string roleName = (string)OriginRoleJsonData[key]["name"];
        ProfessionType profession = (ProfessionType)((int)OriginRoleJsonData[key]["profession"]);
        string head = (string)OriginRoleJsonData[key]["head"];
        string info = (string)OriginRoleJsonData[key]["info"];
        int str = (int)OriginRoleJsonData[key]["str"];
        int strAdd = (int)OriginRoleJsonData[key]["strAdd"];
        int agi = (int)OriginRoleJsonData[key]["agi"];
        int agiAdd = (int)OriginRoleJsonData[key]["agiAdd"];
        int Int = (int)OriginRoleJsonData[key]["int"];
        int IntAdd = (int)OriginRoleJsonData[key]["intAdd"];
        int speed = (int)OriginRoleJsonData[key]["speed"];
        int speedAdd = (int)OriginRoleJsonData[key]["speedAdd"];
        int maxHP = (int)OriginRoleJsonData[key]["maxHP"];
        int maxHPAdd = (int)OriginRoleJsonData[key]["maxHPAdd"];

        //初始化属性 默认满血量
        BaseRoleData roleData = new BaseRoleData(roleId, roleName, profession, roleLevel, head, info, maxHP, maxHPAdd, str, strAdd, agi, agiAdd, Int, IntAdd, speed, speedAdd);

        return roleData;
    }

    /// <summary>
    /// 获得一个职业的名称
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string GetProfessionName(ProfessionType type)
    {
        string value = string.Empty;
        switch (type)
        {
            case ProfessionType.Beginner:
                value = "初心者";
                break;
            case ProfessionType.TreasureHunter:
                value = "初心者";
                break;
            case ProfessionType.Saber:
                value = "剑士";
                break;
            case ProfessionType.Archer:
                value = "弓兵";
                break;
            case ProfessionType.Caster:
                value = "法师";
                break;
            default:
                break;
        }
        return value;
    }
}
