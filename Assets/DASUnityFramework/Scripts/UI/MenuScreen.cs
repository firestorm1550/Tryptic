using System;
using UnityEngine;

namespace DASUnityFramework.Scripts.UI
{
    /// <summary>
    /// For usage documentation, see the MenuScreenManager.cs usage example
    /// </summary>
    [DisallowMultipleComponent]
    public class MenuScreen : MonoBehaviour
    {
	    public bool selfInitializeForTesting = false;
	    public RectTransform RectTransform => _rectTransform;
        public Vector3 StartAnchoredPosition { get; private set; }

        protected MenuScreenManager _manager;
        private RectTransform _rectTransform;

        private void Awake()
        {
	        if (selfInitializeForTesting)
	        {
		        Initialize(null);
	        }
        }

        public virtual void Initialize(MenuScreenManager menuScreenManager)
        {
            _manager = menuScreenManager;
            _rectTransform = transform as RectTransform;
            StartAnchoredPosition = _rectTransform.anchoredPosition;
        }

        public void SetMeActive()
        {
            _manager.SetScreen(this);
        }
    }
}
