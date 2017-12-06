using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
/// <summary>
/// 资源管理 maybe bundle -> persistentDataPath -> streamingAssetsPath
/// </summary>
public class ResMgr : Singleton<ResMgr> {

    public void Init()
    {
        _InitLocation();
    }

    /// <summary>
    /// 初始化路径定位
    /// </summary>
    private void _InitLocation()
    {
        // 1. find persistentDataPath

        // 2. find streamingAssetsPath
    }

    public GameObject Load(string path)
    {
#if UNITY_EDITOR
        Object obj = AssetDatabase.LoadAssetAtPath<Object>(path);
        if (obj != null)
        {
            return GameObject.Instantiate(obj) as GameObject;
        }
        return null;
#endif
    }

    public void Unload(string path)
    {

    }
    public void Unload(UnityEngine.Object obj)
    {
        
    }
}
