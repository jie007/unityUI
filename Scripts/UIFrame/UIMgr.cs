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
        ShowPanel(type, null, UIPanleType.eFrame);
    }

    public void ShowPanel(UIType type, object data = null)
    {
        ShowPanel(type, data, UIPanleType.eFrame);
    }

    public void ShowPanel(UIType type, UIPanleType panelType = UIPanleType.eFrame)
    {
        ShowPanel(type, null, panelType);
    }

    public void ShowPanel(UIType type, object data = null, UIPanleType panelType = UIPanleType.eFrame, params object[] objs)
    {
        UIPanel panel = null;
        if (panelType == UIPanleType.eFrame)
        {
            // 1、是否显示中
            if (_displayPanels.TryGetValue(type, out panel))
            {
                // 显示中
                return;
            }
            // 2、是否缓存
            if (!_allPanels.TryGetValue(type, out panel))
            {
                // 3、需要加载
                panel = LoadPanel(type, panelType);
            }
            if (panel != null) _displayPanels.Add(type, panel);
        }
        else if (panelType == UIPanleType.eWindow)
        {
            if (!_allPanels.TryGetValue(type, out panel))
            {
                panel = LoadPanel(type, panelType);
            }
            if (panel != null) _popStack.Push(panel);
        }

        if (panel != null)
        {
            panel.OnEnter(data, objs);
            panel.Display();
            //panel.RefreshView();
        }
    }

    public void DestroyPanel(UIType type)
    {
        UIPanel panel = null;
        // 1、是否显示中
        if (panel.PanelType == UIPanleType.eFrame)
        {
            if (_displayPanels.TryGetValue(type, out panel))
            {
                _displayPanels.Remove(type);
            }
        }
        else if (panel.PanelType == UIPanleType.eWindow)
        {
            if (_popStack.Count > 0) panel = _popStack.Pop();
        }
        if (panel != null) panel.OnDestroy();
    }

    public UIPanel LoadPanel(UIType type, UIPanleType panelType)
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
            prefab.SetActive(false);
            panel.Init(prefab, type, panelType);
            return panel;
        }
        // TODO log支持
        return null;
    }
}
