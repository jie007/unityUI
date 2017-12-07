using System;
using System.Collections.Generic;
using UIFrame;
using UnityEngine;

public class UIMgr : Singleton<UIMgr>
{
    /// <summary>
    /// 显示列表
    /// </summary>
    private Dictionary<UIType, UIPanel> _displayPanels = null;

    /// <summary>
    /// 缓存
    /// </summary>
    private Dictionary<UIType, UIPanel> _allPanels = null;

    /// <summary>
    /// 栈式窗口
    /// </summary>
    private Stack<UIPanel> _popStack = null;

    /// <summary>
    /// 根节点
    /// </summary>
    private Transform _uiRoot = null;

    private UIDefine _define;

    public UIMgr()
    {
        Init();
    }

    private void Init()
    {
        _uiRoot = GameObject.Find("UIRoot").transform;
        _displayPanels = new Dictionary<UIType, UIPanel>();
        _popStack = new Stack<UIPanel>();
        _allPanels = new Dictionary<UIType, UIPanel>();
        _define = new UIDefine();
    }

    public void ShowPanel(UIType type)
    {
        UIPanel panel;
        // 1、是否显示中
        if (_displayPanels.TryGetValue(type, out panel))
        {
            // 显示中
            return;
        }
        // 2、是否缓存
        if (_allPanels.TryGetValue(type, out panel))
        {
            _displayPanels.Add(type, panel);
            panel.Display();
            return;
        }
        // 3、需要加载
        panel = LoadPanel(type);
        if (panel != null)
        {
            panel.Display();
            //panel.RefreshView();
        }
    }

    public UIPanel LoadPanel(UIType type)
    {
        UIConfig config;
        if (_define.type2configDict.TryGetValue(type, out config))
        {
            GameObject prefab = ResMgr.Instance.Load(config.prefabPath);
            UIPanel panel = System.Activator.CreateInstance(System.Type.GetType(config.scriptName)) as UIPanel;
            if (panel == null)
            {
                // TODO log支持
                return null;
            }
            panel.InitSkin(prefab);
            return panel;
        }
        // TODO log支持
        return null;
    }
}
