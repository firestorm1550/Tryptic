using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class RectTransformExtensions
    {
        /// <summary>
        /// Create RectTransform using screen space based on a given
        /// RectTransform.
        /// </summary>
        public static Rect ScreenSpaceRect(this RectTransform transform)
        {
            Vector2 size = Vector2.Scale(transform.rect.size, transform.lossyScale);
            Rect rect = new Rect(transform.position.x, Screen.height - transform.position.y, size.x, size.y);
            rect.x -= (transform.pivot.x * size.x);
            rect.y -= ((1.0f - transform.pivot.y) * size.y);
            return rect;
        }
    }
}