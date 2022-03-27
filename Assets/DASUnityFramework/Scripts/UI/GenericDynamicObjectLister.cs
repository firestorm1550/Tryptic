using System.Collections.Generic;
using DASUnityFramework.Scripts.ExtensionMethods;
using UnityEngine;

namespace DASUnityFramework.Scripts.UI
{
    public abstract class GenericDynamicObjectLister <TData, TDisplayObject> : MonoBehaviour where TDisplayObject : MonoBehaviour
    {
        public Transform contentParent;
        public TDisplayObject listObjPrefab;

        public virtual void FillList(IEnumerable<TData> data)
        {
            foreach (TData datum in data)
            {
                TDisplayObject displayObject = Instantiate(listObjPrefab, contentParent);
                InitializeDisplayObject(displayObject, datum);
            }
        }

        protected virtual void ClearDisplayedList()
        {
            contentParent.DestroyAllChildren();
        }

        protected abstract void InitializeDisplayObject(TDisplayObject displayObject, TData withData);
    }
}
