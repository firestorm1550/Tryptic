using System.Collections.Generic;
using System.Linq;
using DASUnityFramework.Scripts.ExtensionMethods.VectorExtensions;
using UnityEngine;

namespace Board
{
    public static class HexBoardUtils
    {
        public static float HexDistance(Vector3Int space1, Vector3Int space2)
        {
            return (space1 - space2).Abs().Sum();
        }

        public static List<Vector3Int> GetHexRing(int radius)
        {
            var hex = HexDirectionUtils.Left * radius;
            var spaces = new List<Vector3Int>();
            
            foreach (Vector3Int direction in HexDirectionUtils.Directions)
            {
                for (int i = 0; i < radius; i++)
                {
                    spaces.Add(hex);
                    hex += direction;
                }
            }
            
            if(radius == 0)
                spaces.Add(hex);
            
            return spaces;
        }
    }
}