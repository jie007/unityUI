using System;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrame
{
    public class UIPanel : UIItem
    {
        public UIPanel() { }
        public UIPanel(GameObject go):base(go) { }

        public virtual void OnEnter()
        {
            InitView();
        }

        public virtual void InitView(){ }
        public virtual void Display()
        {
            _gameObject.SetActive(true);
        }
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
