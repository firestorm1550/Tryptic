using System;
using UnityEngine;

namespace DASUnityFramework.Scripts.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class UIMonoBehaviour : MonoBehaviour
    {
        public RectTransform RectTransform
        {
            get
            {
                if (!_rectTransform)
                    _rectTransform = GetComponent<RectTransform>();
                return _rectTransform;
            }
        }

        private RectTransform _rectTransform;

        protected virtual void Awake()
        {
            if(_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();
        }
    }
}