using System;
using DASUnityFramework.Scripts.ExtensionMethods.VectorExtensions;
using UnityEngine;
using UnityEngine.UI;

namespace DASUnityFramework.Scripts.UI
{
    
    /// <summary>
    /// Sets objects in children to rotate from zero to 360 based on child index.
    /// Note that this is somewhat inefficient since updates every frame. This won't scale well with many children.
    /// </summary>
    [ExecuteAlways]
    public class InefficientRotationLayout : MonoBehaviour
    {
        private void Update()
        {
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform child = transform.GetChild(i);
                float zRotation = 360 * (float)i / childCount;
                child.localEulerAngles = child.localEulerAngles.WithZ(zRotation);
            }
        }
    }
}