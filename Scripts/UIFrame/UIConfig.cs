using System;
using System.Collections.Generic;

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