using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 该标签会让物体在切场景时不会销毁
/// </summary>
public class Tag_DontDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SetDontDestroy();
    }

    private void SetDontDestroy()
    {
        DontDestroyOnLoad(gameObject);
    }
}
