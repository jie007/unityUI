using System;
using System.Collections.Generic;

public enum UIPanleType
{
    eFrame,     // 全屏界面
    eWindow     // 窗口界面
}
public struct UIConfig
{
    public string prefabPath;
    public string scriptName;

    public UIConfig(string prefabPath, string scriptName)
    {
        this.prefabPath = prefabPath;
        this.scriptName = scriptName;
    }
}