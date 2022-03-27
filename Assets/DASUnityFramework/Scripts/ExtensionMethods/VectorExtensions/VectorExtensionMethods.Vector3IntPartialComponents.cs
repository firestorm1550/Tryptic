using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods.VectorExtensions
{
    public static partial class VectorExtensionMethods
    {
        public static Vector3Int XOO(this Vector3Int v)
        {
            return new Vector3Int(v.x, 0, 0);
        }

        public static Vector3Int OYO(this Vector3Int v)
        {
            return new Vector3Int(0, v.y, 0);
        }

        public static Vector3Int OOZ(this Vector3Int v)
        {
            return new Vector3Int(0, 0, v.z);
        }

        //=============================================================================================================
        public static Vector3Int XYO(this Vector3Int v)
        {
            return new Vector3Int(v.x, v.y, 0);
        }

        public static Vector3Int OYZ(this Vector3Int v)
        {
            return new Vector3Int(0, v.y, v.z);
        }

        public static Vector3Int XOZ(this Vector3Int v)
        {
            return new Vector3Int(v.x, 0, v.z);
        }
    }
}