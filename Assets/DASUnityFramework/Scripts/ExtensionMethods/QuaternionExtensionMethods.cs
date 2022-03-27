using System;
using UnityEngine;
using UnityEngine.Animations;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class QuaternionExtensionMethods
    {
        /// <summary>
        /// Determine if Quaternion value is normalized, within a range of
        /// tolerance.
        /// </summary>
        public static bool IsValid(this Quaternion q, float tolerance = .0001f)
        {
            return Math.Abs(1 - (q.w * q.w + q.x * q.x + q.y * q.y + q.z * q.z)) < tolerance;
        }

        public static Quaternion Reflect(this Quaternion q, Axis axis)
        {
            if((axis & Axis.X) != 0)
                q = new Quaternion(q.x, -q.y, -q.z, q.w);
            if((axis & Axis.Y) != 0)
                q = new Quaternion(-q.x, q.y, -q.z, q.w);
            if((axis & Axis.Z) != 0)
                q = new Quaternion(-q.x, -q.y, q.z, q.w);
            return q;
        }
    }
}