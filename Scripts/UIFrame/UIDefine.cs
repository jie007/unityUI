using System;
using System.Collections.Generic;

namespace UIFrame
{
    public class UIDefine
    {
        private Dictionary<UIType, UIConfig> _type2configDict = null;
        public Dictionary<UIType, UIConfig> type2configDict { get { return _type2configDict; } }
        public UIDefine()
        {
            _type2configDict = new Dictionary<UIType, UIConfig>();
            Init();
        }
        private void RegisterUI(UIType type, string prefabPath, string scriptName, UIPanleType panelType = UIPanleType.eFrame)
        {
            UIConfig config;
            if (!_type2configDict.TryGetValue(type, out config))
            {
                config = new UIConfig(prefabPath, scriptName);
                _type2configDict.Add(type, config);
            }
            else
            {
                // TODO 重复注册提示（log）
            }
        }
        private void Init()
        {
            RegisterUI(UIType.eLogin, "prefabPath", "LoginPanel", UIPanleType.eWindow);
        }
    }

}
