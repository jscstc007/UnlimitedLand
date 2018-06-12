using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {

    private Image roleMask;
    private Image roleHP;
    private Image enemyMask;
    private Image enemyHP;

    private int RoleSpeed = 250;
    private int RoleHP = 2000;
    private int RoleMaxHP = 2000;
    private int RoleAtk = 50;

    private int EnemySpeed = 20;
    private int EnemyHP = 1500;
    private int EnemyMaxHP = 1500;
    private int EnemyAtk = 10;

    private bool IsStart;

    private void Awake()
    {
        roleMask = GameObject.Find("Canvas/Role/Mask_I").GetComponent<Image>();
        roleHP = GameObject.Find("Canvas/Role/HP_I").GetComponent<Image>();
        enemyMask = GameObject.Find("Canvas/Enemy/Mask_I").GetComponent<Image>();
        enemyHP = GameObject.Find("Canvas/Enemy/HP_I").GetComponent<Image>();
    }
    // Use this for initialization
    void Start () {
        roleMask.fillAmount = 0;
        enemyMask.fillAmount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (IsStart)
        {
            //按照速度更新RoleImageFillAmount 达到满值后触发一次攻击并重置
            roleMask.fillAmount += RoleSpeed * 0.0001f;
            enemyMask.fillAmount += EnemySpeed * 0.0001f;
            
            if (roleMask.fillAmount >= 0.99f)
            {
                roleMask.fillAmount = 0;

                Util.Log("玩家攻击1次!");
                RoleAttack();
            }
            if (enemyMask.fillAmount >= 0.99f)
            {
                enemyMask.fillAmount = 0;

                Util.Log("敌人攻击1次!");
                EnemyAttack();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Q ))
        {
            StarFight();
        }
        if (Input.GetKeyDown(KeyCode.W ))
        {
            StopFight();
        }
    }

    private void RoleAttack ()
    {
        EnemyHP = Mathf.Max(0, EnemyHP - RoleAtk);

        if(EnemyHP == 0)
        {
            //Enemy Die
            StopFight();

            Util.Log("敌人已死亡");
        }
        //UI
        enemyHP.fillAmount = (float)EnemyHP / (float)EnemyMaxHP;
    }
    private void EnemyAttack()
    {
        RoleHP = Mathf.Max(0, RoleHP - EnemyAtk);

        if (RoleHP == 0)
        {
            //Role Die
            StopFight();

            Util.Log("角色已死亡");
        }
        //UI
        roleHP.fillAmount = (float)RoleHP / (float)RoleMaxHP;
    }

    private void StarFight()
    {
        IsStart = true;
    }

    private void StopFight()
    {
        IsStart = false;

        roleMask.fillAmount = 0;
        enemyMask.fillAmount = 0;
    }
}
