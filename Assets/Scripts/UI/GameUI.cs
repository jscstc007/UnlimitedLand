using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : BaseUI {

    public override UIType GetUIType()
    {
        return UIType.GameUI;
    }

    public override void OnAwake()
    {
        base.OnAwake();
        
        UIManager.SetUITrans(CacheRectTransform);
    }

    public override void OnStart()
    {
        base.OnStart();
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

    // --------------------------------------------------------------------------------------------------
}
