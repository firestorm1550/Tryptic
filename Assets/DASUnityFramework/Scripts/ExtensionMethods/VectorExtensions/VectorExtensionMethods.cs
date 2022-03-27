using System;
using System.Collections.Generic;
using DASUnityFramework.Scripts.UnityWiki;
using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods.VectorExtensions
{
    public static partial class VectorExtensionMethods 
    {
        //=============== Vector3 Extensions ==========================================
        
        /// <summary>
        /// Converts each component of a Vector3 to its absolute value.
        /// </summary>
        public static Vector3 Abs(this Vector3 v)
        {
            return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
        }

        
        /// <summary>
        /// Converts each component of a Vector3Int to its absolute value.
        /// </summary>
        public static Vector3Int Abs(this Vector3Int v)
        {
            return new Vector3Int(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
        }

        
        
        /// <summary>
        /// Rounds each component of a Vector3 to a given number of decimal places
        /// </summary>
        public static Vector3 Round(this Vector3 v, int decimals)
        {
            return new Vector3((float) Math.Round(v.x, decimals), (float) Math.Round(v.y, decimals), (float) Math.Round(v.z, decimals));
        }

        /// <summary>
        /// Rounds each component of a Vector3 to the closest integer and returns the values in a Vector3Int 
        /// </summary>
        public static Vector3Int RoundToInt(this Vector3 v)
        {
            return new Vector3Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z));
        }
        
        public static bool RoughlyEquals(this Vector3 v, Vector3 other, float tolerance = Single.Epsilon)
        {
            return v.x.RoughlyEquals(other.x, tolerance) && 
                   v.y.RoughlyEquals(other.y, tolerance) &&
                   v.z.RoughlyEquals(other.z, tolerance);
        }
        
        /// <summary>
        /// Sums components of a Vector3.
        /// </summary>
        public static float Sum(this Vector3 v)
        {
            return v.x + v.y + v.z;
        }
        
        /// <summary>
        /// Creates new vector from the average of each component from a list
        /// of Vector3s. 
        /// </summary>
        public static Vector3 Average(this List<Vector3> vector3s)
        {
            Vector3 sum = Vector3.zero;

            foreach (Vector3 vector3 in vector3s)
            {
                sum += vector3;
            }

            int numVectors = vector3s.Count;

            sum = new Vector3(sum.x / numVectors, sum.y / numVectors, sum.z / numVectors);

            return sum;
        }

        /// <summary>
        /// Finds greatest component value in a Vector3. Functionally
        /// equivalent to Max.
        /// </summary>
        public static float GreatestDimension(this Vector3 vector)
        {
            if (vector.x > vector.y && vector.x > vector.z)
                return vector.x;
            //At this point we know x is not the greatest, so it must be y or z
            return vector.y > vector.z ? vector.y : vector.z;
        }

        /// <summary>
        /// Swaps a Vector3's x and z components.
        /// </summary>
        public static Vector3 SwapXandZ(this Vector3 v3)
        {
            return new Vector3(v3.z, v3.y, v3.x);
        }

        /// <summary>
        /// Converts a Vector3 to a Vector3Int. Functionally equivalent to
        /// Vector3Int.FloorToInt.
        /// </summary>
        public static Vector3Int ToVector3Int(this Vector3 v)
        {
            return new Vector3Int((int)v.x,(int)v.y,(int)v.z);
        }
        
        /// <summary>
        /// Finds greatest component value in a Vector3.
        /// </summary>
        public static float Max(this Vector3 v)
        {
            return Mathf.Max(v.x, v.y, v.z);
        }

        
        /// <summary>
        /// Finds the max between v1 and v2 in each component
        /// </summary>
        public static Vector3 Max(this Vector3 v1, Vector3 v2)
        {
            return new Vector3(Mathf.Max(v1.x, v2.x), Mathf.Max(v1.y, v2.y), Mathf.Max(v1.z, v2.z));
        }
        
        /// <summary>
        /// Finds the min between v1 and v2 in each component
        /// </summary>
        public static Vector3Int Min(this Vector3Int v1, Vector3Int v2)
        {
            return new Vector3Int(Mathf.Min(v1.x, v2.x), Mathf.Min(v1.y, v2.y), Mathf.Min(v1.z, v2.z));
        }
        
        /// <summary>
        /// Finds the max between v1 and v2 in each component
        /// </summary>
        public static Vector3Int Max(this Vector3Int v1, Vector3Int v2)
        {
            return new Vector3Int(Mathf.Max(v1.x, v2.x), Mathf.Max(v1.y, v2.y), Mathf.Max(v1.z, v2.z));
        }
        
                
        /// <summary>
        /// Sums components of a Vector3Int.
        /// </summary>
        public static int Sum(this Vector3Int v)
        {
            return v.x + v.y + v.z;
        }

        
        /// <summary>
        /// Finds lowest component value in a Vector3.
        /// </summary>
        public static float Min(this Vector3 v)
        {
            return Mathf.Min(v.x, v.y, v.z);
        }

        /// <summary>
        /// Finds component with the greatest absolute value.
        /// </summary>
        /// <returns>Signed value that's furthest from zero.</returns>
        public static float MaxAbsValue(this Vector3 v)
        {
            float max = v.Max();
            float min = v.Min();

            return Mathf.Abs(max) > Mathf.Abs(min) ? max : min;
        }

        public static Vector3 Sign(this Vector3 v)
        {
            return new Vector3(Mathf.Sign(v.x), Mathf.Sign(v.y), Mathf.Sign(v.z));
        }
        
        public static Vector3 RemoveInfinities(this Vector3 v, float valueToUseInstead)
        {
            if (float.IsInfinity(v.x))
                v.x = valueToUseInstead;
            if (float.IsInfinity(v.y))
                v.y = valueToUseInstead;
            if (float.IsInfinity(v.z))
                v.z = valueToUseInstead;

            return v;
        }
        
        /// <summary>
        /// Determines if all components are approximately equal.
        /// </summary>
        public static bool IsUniform(this Vector3 v)
        {
            return Math.Abs(v.x - v.y) < .01f && Math.Abs(v.y - v.z) < .01f;
        }

        /// <summary>
        /// Create a vector where each component has the absolute value of v's largest component
        /// </summary>
        public static Vector3 MakeUniformToMax(this Vector3 v)
        {
            float maxAbs = v.MaxAbsValue();
            
            v.x = maxAbs;
            v.y = maxAbs;
            v.z = maxAbs;

            return v;
        }

        /// <summary>
        /// Returns the greatest non-zero value. Returns 0 if all values equal 0
        /// </summary>
        public static float MaxIgnoreZeroes(this Vector3 v)
        {
            float max = 0;
            if (max == 0 || v.x > max && v.x != 0)
                max = v.x;
            if (max == 0 || v.y > max && v.y != 0)
                max = v.y;
            if (max == 0 || v.z > max && v.z != 0)
                max = v.z;

            return max;
        }
        
        
        /// <summary>
        /// Returns the least non-zero value. Returns 0 if all values equal 0
        /// </summary>
        public static float MinIgnoreZeroes(this Vector3 v)
        {
            float min = 0;
            if (min == 0 || v.x < min && v.x != 0)
                min = v.x;
            if (min == 0 || v.y < min && v.y != 0)
                min = v.y;
            if (min == 0 || v.z < min && v.z != 0)
                min = v.z;

            return min;
        }
        
        /// <summary>
        /// Clamps each component of vector v between the corresponding components of min and max.
        /// </summary>
        public static Vector3 Clamp(this Vector3 v, Vector3 min, Vector3 max)
        {
            float x = Mathf.Clamp(v.x, min.x, max.x);
            float y = Mathf.Clamp(v.y, min.y, max.y);
            float z = Mathf.Clamp(v.z, min.z, max.z);
            
            return new Vector3(x, y, z);
        }
        
        /// <summary>
        /// returns a vector where any non-zero component is set to 1 and zero remains 0
        /// </summary>
        public static Vector3 Digitize(this Vector3 v)
        {
            if (v.x != 0)
                v.x = 1;
            if (v.y != 0)
                v.y = 1;
            if (v.z != 0)
                v.z = 1;

            return v;
        }

        /// <summary>
        /// Returns the point on a line nearest to the given point
        /// </summary>
        public static Vector3 NearestPointOnLine(this Vector3 point, Vector3 aPointOnTheLine, Vector3 lineDirection)
        {
            return Math3d.ProjectPointOnLine(aPointOnTheLine, lineDirection, point);
        }

        public static Vector3 NearestPointOnPlane(this Vector3 worldPoint, Vector3 aPointOnThePlane, Vector3 planeNormal)
        {
            Vector3 planePointToWorldPoint = aPointOnThePlane - worldPoint;
            Vector3 worldPointToPlane = Vector3.Dot(planePointToWorldPoint, planeNormal) * planeNormal;
            return worldPoint + worldPointToPlane;
        }
        
        //=============== Vector2 Extensions ==========================================
        
        /// <summary>
        /// Finds greatest components value in a Vector2.
        /// </summary>
        public static float Max(this Vector2 v)
        {
            return Mathf.Max(v.x, v.y);
        }
        
        /// <summary>
        /// Finds smallest components value in a Vector2.
        /// </summary>
        public static float Min(this Vector2 v)
        {
            return Mathf.Min(v.x, v.y);
        }

        public static Vector3 ScreenPointToPointOnLine(this Vector3 screenPoint, Camera camera, Vector3 lineStart, Vector3 lineDirection)
        {
            Ray cameraRay = camera.ScreenPointToRay(screenPoint);
            Math3d.ClosestPointsOnTwoLines(out _, out Vector3 pointOnLine,
                cameraRay.origin, cameraRay.direction, lineStart, lineDirection);

            return pointOnLine;
        }
        
        //=============== Vector4 Extensions ==========================================
        
        /// <summary>
        /// Finds greatest components value in a Vector4.
        /// </summary>
        public static float Max(this Vector4 v)
        {
            return Mathf.Max(v.w, v.x, v.y, v.z);
        }

        /// <summary>
        /// returns this Vector4 multiplied by some value such that its new
        /// greatest element is 1. *sort of* like normalization
        /// </summary>
        public static Vector4 Maximized(this Vector4 v)
        {
            float maxValue = Max(v);
            return v / maxValue;
        }

    }
}
