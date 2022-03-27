using System;
using UnityEngine;

namespace DASUnityFramework.Scripts
{
    public enum InterpolationType
    {
        Linear,Quadratic,Cubic,Quartic,
        Sqrt,CubeRoot,FourthRoot,
        EaseOutBack, EaseInOutSine
    }
    public static class Interpolation
    {
        /// <summary>
        /// Calculate interpolated result between two floats without clamping.
        /// </summary>
        public static float InterpolateUnclamped(float start, float end, float portion,
            InterpolationType type = InterpolationType.Linear)
        {
            float delta = (end - start);
        
            switch (type)
            {
                case InterpolationType.Linear:
                    return start + delta * portion;
                case InterpolationType.Quadratic:
                    return start + delta * portion * portion;
                case InterpolationType.Cubic:
                    return start + delta * portion * portion * portion;
                case InterpolationType.Quartic:
                    return start + delta * portion * portion * portion * portion;

                case InterpolationType.Sqrt:
                    return start + delta * Mathf.Sqrt(portion);
                case InterpolationType.CubeRoot:
                    return start + delta * Mathf.Pow(portion, 1 / 3f);
                case InterpolationType.FourthRoot:
                    return start + delta * Mathf.Pow(portion, 1 / 4f);
                
                case InterpolationType.EaseOutBack:
                    return start + delta * EaseOutBack(portion);
                case InterpolationType.EaseInOutSine:
                    return start + delta * EaseInOutSine(portion);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        
        /// <summary>
        /// Calculate interpolated result between two floats.
        /// </summary>
        public static float Interpolate(float start, float end, float portion, InterpolationType type = InterpolationType.Linear)
        {
            portion = Mathf.Clamp01(portion);
            return InterpolateUnclamped(start, end, portion, type);
        }
        
        /// <summary>
        /// Calculate interpolated result between two Vector3s.
        /// </summary>
        public static Vector3 Interpolate(Vector3 startPoint, Vector3 endPoint, float portion, InterpolationType type = InterpolationType.Linear)
        {
            return new Vector3(
                Interpolate(startPoint.x, endPoint.x, portion, type),
                Interpolate(startPoint.y, endPoint.y, portion, type),
                Interpolate(startPoint.z, endPoint.z, portion, type));
        }

        /// <summary>
        /// Calculate interpolated result between two Quaternions.
        /// </summary>
        public static Quaternion Interpolate(Quaternion start, Quaternion end, float portion, InterpolationType type = InterpolationType.Linear)
        {
            return new Quaternion(
                Interpolate(start.x, end.x, portion, type),
                Interpolate(start.y, end.y, portion, type),
                Interpolate(start.z, end.z, portion, type),
                Interpolate(start.w, end.w, portion, type));
        }
        
        /// <summary>
        /// Calculate interpolated result between two Colors.
        /// </summary>
        public static Color Interpolate(Color start, Color end, float portion, InterpolationType type = InterpolationType.Linear)
        {
            return new Color(
                Interpolate(start.r, end.r, portion, type),
                Interpolate(start.g, end.g, portion, type),
                Interpolate(start.b, end.b, portion, type),
                Interpolate(start.a, end.a, portion, type));
        }
        
        private static float EaseOutBack(float t)
        {
            float c1 = 1.70158f;
            float c3 = c1 + 1;

            return 1 + c3 * Mathf.Pow(t - 1, 3) + c1 * Mathf.Pow(t - 1, 2);
        }

        private static float EaseInOutSine(float x)
        {
            return -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
        }
    }
}