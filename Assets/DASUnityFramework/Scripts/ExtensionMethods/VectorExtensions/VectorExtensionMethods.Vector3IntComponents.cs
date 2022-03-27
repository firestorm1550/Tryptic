using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods.VectorExtensions
{
    public static partial class VectorExtensionMethods
    {
        public static Vector2 XX(this Vector3Int v)
        {
            return new Vector2(v.x,v.x);
        }
        public static Vector2 XY(this Vector3Int v)
        {
            return new Vector2(v.x,v.y);
        }
        public static Vector2 XZ(this Vector3Int v)
        {
            return new Vector2(v.x,v.z);
        }
        
        public static Vector2 YX(this Vector3Int v)
        {
            return new Vector2(v.y,v.x);
        }
        public static Vector2 YY(this Vector3Int v)
        {
            return new Vector2(v.y,v.y);
        }
        public static Vector2 YZ(this Vector3Int v)
        {
            return new Vector2(v.y,v.z);
        }
        
        public static Vector2 ZX(this Vector3Int v)
        {
            return new Vector2(v.z,v.x);
        }
        public static Vector2 ZY(this Vector3Int v)
        {
            return new Vector2(v.z,v.y);
        }
        public static Vector2 ZZ(this Vector3Int v)
        {
            return new Vector2(v.z,v.z);
        }
        
        
        //=============================================================================================================

        public static Vector3Int XXX(this Vector3Int v)
        {
            return new Vector3Int(v.x,v.x,v.x);
        }
        public static Vector3Int XXY(this Vector3Int v)
        {
            return new Vector3Int(v.x,v.x,v.y);
        }
        public static Vector3Int XXZ(this Vector3Int v)
        {
            return new Vector3Int(v.x,v.x,v.z);
        }
        
        public static Vector3Int XYX(this Vector3Int v)
        {
            return new Vector3Int(v.x,v.y,v.x);
        }
        public static Vector3Int XYY(this Vector3Int v)
        {
            return new Vector3Int(v.x,v.y,v.y);
        }
        public static Vector3Int XYZ(this Vector3Int v)
        {
            return new Vector3Int(v.x,v.y,v.z);
        }
        
        public static Vector3Int XZX(this Vector3Int v)
        {
            return new Vector3Int(v.x,v.z,v.x);
        }
        public static Vector3Int XZY(this Vector3Int v)
        {
            return new Vector3Int(v.x,v.z,v.y);
        }
        public static Vector3Int XZZ(this Vector3Int v)
        {
            return new Vector3Int(v.x,v.z,v.z);
        }
        
         //=============================================================================================================
        
         public static Vector3Int YXX(this Vector3Int v)
         {
             return new Vector3Int(v.y,v.x,v.x);
         }
         public static Vector3Int YXY(this Vector3Int v)
         {
             return new Vector3Int(v.y,v.x,v.y);
         }
         public static Vector3Int YXZ(this Vector3Int v)
         {
             return new Vector3Int(v.y,v.x,v.z);
         }
        
         public static Vector3Int YYX(this Vector3Int v)
         {
             return new Vector3Int(v.y,v.y,v.x);
         }
         public static Vector3Int YYY(this Vector3Int v)
         {
             return new Vector3Int(v.y,v.y,v.y);
         }
         public static Vector3Int YYZ(this Vector3Int v)
         {
             return new Vector3Int(v.y,v.y,v.z);
         }
        
         public static Vector3Int YZX(this Vector3Int v)
         {
             return new Vector3Int(v.y,v.z,v.x);
         }
         public static Vector3Int YZY(this Vector3Int v)
         {
             return new Vector3Int(v.y,v.z,v.y);
         }
         public static Vector3Int YZZ(this Vector3Int v)
         {
             return new Vector3Int(v.y,v.z,v.z);
         }
         
         
         //=============================================================================================================
        
         public static Vector3Int ZXX(this Vector3Int v)
         {
             return new Vector3Int(v.z,v.x,v.x);
         }
         public static Vector3Int ZXY(this Vector3Int v)
         {
             return new Vector3Int(v.z,v.x,v.y);
         }
         public static Vector3Int ZXZ(this Vector3Int v)
         {
             return new Vector3Int(v.z,v.x,v.z);
         }
        
         public static Vector3Int ZYX(this Vector3Int v)
         {
             return new Vector3Int(v.z,v.y,v.x);
         }
         public static Vector3Int ZYY(this Vector3Int v)
         {
             return new Vector3Int(v.z,v.y,v.y);
         }
         public static Vector3Int ZYZ(this Vector3Int v)
         {
             return new Vector3Int(v.z,v.y,v.z);
         }
        
         public static Vector3Int ZZX(this Vector3Int v)
         {
             return new Vector3Int(v.z,v.z,v.x);
         }
         public static Vector3Int ZZY(this Vector3Int v)
         {
             return new Vector3Int(v.z,v.z,v.y);
         }
         public static Vector3Int ZZZ(this Vector3Int v)
         {
             return new Vector3Int(v.z,v.z,v.z);
         }
    }
}