using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// 加载UI
/// </summary>
public class InitUI : BaseUI {

    public override UIType GetUIType()
    {
        return UIType.InitUI;
    }

    public override void OnAwake()
    {
        base.OnAwake();

        UIManager.SetUITrans(CacheRectTransform);
    }

    public override void OnStart()
    {
        base.OnStart();
        //开始加载数据与Game场景
        StartCoroutine(LoadData());
    }

    public override void SetUI(params object[] objs)
    {
        base.SetUI(objs);
    }

    public override void OnRelease()
    {
        base.OnRelease();

        Util.Log("InitUI OnRelease");
    }

    // --------------------------------------------------------------------------------------------------
	
	private IEnumerator LoadData ()
    {
        //加载数据
        //模拟加载 1f
        yield return new WaitForSeconds(1);

        //加载完成后 加载Game模块并清除Init模块
        GameController.Instance.LoadModule(ModuleType.GameModule);
        GameController.Instance.RemoveModule(ModuleType.InitModule);
    }
}
