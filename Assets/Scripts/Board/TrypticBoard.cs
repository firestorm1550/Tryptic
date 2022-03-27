using System.Collections.Generic;
using UnityEngine;

namespace Board
{
    public class TrypticBoard
    {
        public Dictionary<Vector3Int, TrypticBoardSpace> Spaces = new();
        public TrypticBoard()
        {
            List<Vector3Int> hexCoordinates = new List<Vector3Int>();
            
            for (int i = 0; i < 5; i++)
            {
                hexCoordinates.AddRange(HexBoardUtils.GetHexRing(i));
            }
            
            foreach (Vector3Int hexCoordinate in hexCoordinates)
            {
                Spaces.Add(hexCoordinate, new TrypticBoardSpace(this, hexCoordinate));
            }
            
        }
    }
}