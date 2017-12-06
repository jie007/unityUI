﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrame
{
    public class UIItem
    {
        protected GameObject _gameObject;
        public GameObject gameObject
        {
            set { _gameObject = value; }
            get { return _gameObject; }
        }

        protected Transform _transform;
        public Transform transform
        {
            set { _transform = value; }
            get { return _transform; }
        }

        protected string _path;

        /// <summary>
        /// 子项
        /// </summary>
        protected List<UIItem> _items;

        public UIItem(GameObject go)
        {
            _gameObject = go;
            _transform = go.transform;
        }

        public virtual void OnDestroy()
        {
            _gameObject = null;
            _transform = null;

            if (_items != null)
            {
                foreach (UIItem item in _items)
                {
                    item.OnDestroy();
                }
                _items.Clear();
                _items = null;
            }
        }
    }
}
