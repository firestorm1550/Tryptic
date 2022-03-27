using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods.VectorExtensions
{
    public static partial class VectorExtensionMethods
    {
        //========== Vector 2 =========================================================================================
        public static Vector2 Multiply(this Vector2 v, float x, float y)
        {
            return new Vector2(v.x * x, v.y * y);
        }

        public static Vector2 Multiply(this Vector2 v, Vector2 v2)
        {
            return new Vector2(v.x * v2.x, v.y * v2.y);
        }
        
        //========== Vector 3 =========================================================================================
        
        /// <summary>
        /// Multiplies Vector3 and Vector3Int component-wise. Functionally
        /// equivalent to Vector3.Scale.
        /// </summary>
        public static Vector3 Multiply(this Vector3 v1, Vector3Int v2)
        {
            Vector3 retval = new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return retval;
        }
        
        /// <summary>
        /// Multiplies two Vector3s component-wise. Functionally equivalent to
        /// Vector3.Scale.
        /// </summary>
        public static Vector3 Multiply(this Vector3 v1, Vector3 v2)
        {
            Vector3 retval = new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return retval;
        }
        
        /// <summary>
        /// Multiplies Vector3 by three floats component-wise.
        /// </summary>
        public static Vector3 Multiply(this Vector3 v1, float x, float y, float z)
        {
            Vector3 retval = new Vector3(v1.x * x, v1.y * y, v1.z * z);
            return retval;
        }

        /// <summary>
        /// Divides Vector3 by three floats component-wise.
        /// </summary>
        public static Vector3 Divide(this Vector3 v1, Vector3 v2)
        {
            Vector3 retval = new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
            return retval;
        }
        
        //========== Vector 3 Int =====================================================================================
        
        /// <summary>
        /// Multiplies Vector3Int and Vector3 component-wise. Functionally
        /// equivalent to Vector3.Scale.
        /// </summary>
        public static Vector3 Multiply(this Vector3Int v1, Vector3 v2)
        {
            Vector3 retval = new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return retval;
        }
        
        /// <summary>
        /// Multiplies two Vector3Ints component-wise. Functionally equivalent to
        /// Vector3Int.Scale.
        /// </summary>
        public static Vector3Int Multiply(this Vector3Int v1, Vector3Int v2)
        {
            Vector3Int retval = new Vector3Int(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return retval;
        }
        
        /// <summary>
        /// Divides two Vector3Ints component-wise and floors each value.
        /// </summary>
        public static Vector3Int DivideAndFloor(this Vector3Int v1, Vector3Int v2)
        {
            Vector3Int retval = new Vector3Int(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
            return retval;
        }
        
        /// <summary>
        /// Divides two Vector3Ints component-wise and ceils each value.
        /// </summary>
        public static Vector3Int DivideAndCeil(this Vector3Int v1, Vector3Int v2)
        {
            Vector3Int retval = new Vector3Int(
                Mathf.CeilToInt((float) v1.x / v2.x),
                Mathf.CeilToInt((float) v1.y / v2.y), 
                Mathf.CeilToInt((float) v1.z / v2.z));
            
            return retval;
        }
        
        /// <summary>
        /// Divides two Vector3Ints component-wise and rounds each value.
        /// </summary>
        public static Vector3Int DivideAndRound(this Vector3Int v1, Vector3Int v2)
        {
            Vector3Int retval = new Vector3Int(
                Mathf.RoundToInt((float) v1.x / v2.x),
                Mathf.RoundToInt((float) v1.y / v2.y), 
                Mathf.RoundToInt((float) v1.z / v2.z));
            
            return retval;
        }
    }
}