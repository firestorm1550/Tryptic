using System;
using UnityEngine;

namespace DASUnityFramework.Scripts.Utilities
{
    public static class LogicalUtilities
    {
        public static void ExecuteOnEachCombinationOfXYZPlusAndMinusOne(Action<Vector3Int> action)
        {
            action(new Vector3Int(1, 1, 1));
            action(new Vector3Int(-1, 1, 1));
            
            action(new Vector3Int(1, -1, 1));
            action(new Vector3Int(-1, -1, 1));
            
            
            action(new Vector3Int(1, 1, -1));
            action(new Vector3Int(-1, 1, -1));
            action(new Vector3Int(1, -1, -1));
            action(new Vector3Int(-1, -1, -1));
        }
    }
}