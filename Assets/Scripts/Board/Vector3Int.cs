using System.Collections.Generic;
using UnityEngine;

namespace Board
{
    public static class HexDirectionUtils
    {
        public static readonly Vector3Int UpRight  = new Vector3Int(1, 0, -1);
        public static readonly Vector3Int DownLeft = new Vector3Int(-1, 0, 1);
        public static readonly Vector3Int UpLeft = new Vector3Int(0, 1, -1);
        public static readonly Vector3Int DownRight = new Vector3Int(0, -1, 1);
        public static readonly Vector3Int Right = new Vector3Int(1, 0, -1);
        public static readonly Vector3Int Left = new Vector3Int(-1, 0, 1);

        public static readonly List<Vector3Int> Directions = new List<Vector3Int>
        {
            UpRight, DownLeft, UpLeft, DownRight, Right, Left
        };
    }
}