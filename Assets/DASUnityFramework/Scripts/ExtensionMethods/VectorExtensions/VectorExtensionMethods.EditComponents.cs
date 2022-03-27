using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods.VectorExtensions
{
    public static partial class VectorExtensionMethods
    {
        //=============== Float Modifiers ======================================
        
        /// <summary>
        /// Change x value of Vector3 to a specified float.
        /// </summary>
        public static Vector3 WithX(this Vector3 v, float x)
        {
            return new Vector3(x, v.y, v.z);
        }

        /// <summary>
        /// Change y value of Vector3 to a specified float.
        /// </summary>
        public static Vector3 WithY(this Vector3 v, float y)
        {
            return new Vector3(v.x, y, v.z);
        }

        /// <summary>
        /// Change z value of Vector3 to a specified float.
        /// </summary>
        public static Vector3 WithZ(this Vector3 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }
        
        //=============== Vector3 Modifiers ====================================
        
        /// <summary>
        /// Change x value of Vector3 to match that of a second Vector3.
        /// </summary>
        public static Vector3 WithX(this Vector3 v1, Vector3 v2)
        {
            return new Vector3(v2.x, v1.y, v1.z);
        }
        
        /// <summary>
        /// Change y value of Vector3 to match that of a second Vector3.
        /// </summary>
        public static Vector3 WithY(this Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x, v2.y, v1.z);
        }
        
        /// <summary>
        /// Change z value of Vector3 to match that of a second Vector3.
        /// </summary>
        public static Vector3 WithZ(this Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x, v1.y, v2.z);
        }
        
        /// <summary>
        /// Change x and y values of Vector3 to match those of a second Vector3.
        /// </summary>
        public static Vector3 WithXY(this Vector3 v1, Vector3 v2)
        {
            return new Vector3(v2.x, v2.y, v1.z);
        }
        
        /// <summary>
        /// Change x and z values of Vector3 to match those of a second Vector3.
        /// </summary>
        public static Vector3 WithXZ(this Vector3 v1, Vector3 v2)
        {
            return new Vector3(v2.x, v1.y, v2.z);
        }
        
        /// <summary>
        /// Change y and z values of Vector3 to match those of a second Vector3.
        /// </summary>
        public static Vector3 WithYZ(this Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x, v2.y, v2.z);
        }
        
    }
}
