using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TagType
{
    None = -1,
    DontDestroy,
}

/// <summary>
/// 给物体打上Tag脚本
/// </summary>
public class TagManager : ISingleton<TagManager>{

	public void AddTag (GameObject go, TagType type)
    {
        switch(type)
        {
            case TagType.DontDestroy:
                Tag_DontDestroy tag = go.GetComponent<Tag_DontDestroy>();
                if (null == tag)
                {
                    go.AddComponent<Tag_DontDestroy>();
                }
                break;

            default:
                break;
        }
    }
}
