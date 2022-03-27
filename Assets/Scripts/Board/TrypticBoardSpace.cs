using UnityEngine;

namespace Board
{
    public class TrypticBoardSpace
    {
        public Vector3Int Coordinates;
        public TrypticBoard Board;

        public TrypticBoardSpace(TrypticBoard board, Vector3Int coordinates)
        {
            Board = board;
            Coordinates = coordinates;
        }
    }
}