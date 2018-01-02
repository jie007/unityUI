using System;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrame
{
    public class UIPanel : UIItem , IView
    {
        protected Proxy m_Proxy;
        protected UIType type;
        public UIType Type { get; }
        protected UIPanleType panelType = UIPanleType.eFrame;
        public UIPanleType PanelType { get; }
        protected object data;
        protected object[] dataArray;
        public UIPanel() { }
        public UIPanel(GameObject go):base(go) { }

        public virtual void OnEnter(object data = null, params object[] objs)
        {
            this.data = data;
            dataArray = objs;
            InitView();
        }
        public void Init(GameObject go, UIType type, UIPanleType panelType)
        {
            base.InitSkin(go);
            this.type = type;
            this.panelType = panelType;
        }
        public virtual void InitView(){ }
        public virtual void Hide()
        {
            _gameObject.SetActive(false);
        }
        public virtual void RefreshView(object data, params object[] args){}
        public virtual void Destroy(UIType type)
        {
            if (m_Proxy != null)
                m_Proxy.OnPanelDestroy(this);
            UIMgr.Instance.DestroyPanel(type);
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        public List<string> InterestNotifications()
        {
            return null;
        }

        public void OnHandlerNotification(INotification notification)
        {
            throw new NotImplementedException();
        }
    }
}
