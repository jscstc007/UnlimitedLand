using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI主控制器 挂载在UI上
/// </summary>
public class UIManager : MonoBehaviour {

    private static Transform UIroot;
    public static Transform UIRoot
    {
        get
        {
            if (null == UIroot)
            {
                UIroot = GameObject.Find("/UIManager").transform;
            }
            return UIroot;
        }
    }

	// Use this for initialization
	void Awake () {
        //添加不销毁tag
        TagManager.Instance.AddTag(gameObject, TagType.DontDestroy);
	}

    /// <summary>
    /// 设置一个UI的位置信息
    /// </summary>
    /// <param name="ui"></param>
    public static void SetUITrans (RectTransform ui)
    {
        ui.SetParent(UIRoot);

        ui.anchoredPosition = Vector3.zero;
        ui.sizeDelta = Vector3.zero;
        ui.localScale = Vector3.one;
    }
	
	//TODO
}
