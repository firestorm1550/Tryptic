using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods.VectorExtensions
{
    public static partial class VectorExtensionMethods
    {
        /// <summary>
        /// Rotates a point about another point (pivot) by rotation. Works similarly to Transform.RotateAround.
        /// </summary>
        /// <param name="point">The point being rotated</param>
        /// <param name="pivot">The point we're rotating around</param>
        /// <param name="rotation">The rotation to apply</param>
        /// <returns></returns>
        public static Vector3 RotateAround(this Vector3 point, Vector3 pivot, Quaternion rotation)
        {
            return rotation * (point - pivot) + pivot;
        }
        
    }
}