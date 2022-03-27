using DASUnityFramework.Scripts.Utilities;
using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class VisualDebugExtensionMethods
    {
        public static void DrawPointAndRotationInEditorGizmos(this Vector3 point, Quaternion rotation, float lineLen = 1)
        {
            Debug.DrawRay(point, rotation * Vector3.up * lineLen, Color.green);
            Debug.DrawRay(point, rotation * Vector3.down * lineLen, Color.white);
            Debug.DrawRay(point, rotation * Vector3.right * lineLen, Color.red);
            Debug.DrawRay(point, rotation * Vector3.left * lineLen, Color.white);
            Debug.DrawRay(point, rotation * Vector3.forward * lineLen, Color.blue);
            Debug.DrawRay(point, rotation * Vector3.back * lineLen, Color.white);
        }
    }
}