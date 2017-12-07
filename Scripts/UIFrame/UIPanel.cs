using System;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrame
{
    public class UIPanel : UIItem
    {
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

        public virtual void InitView(){ }
        public virtual void Hide()
        {
            _gameObject.SetActive(false);
        }
        public virtual void RefreshView(object data, params object[] args){}

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
