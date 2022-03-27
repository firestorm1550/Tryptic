using Board;
using NUnit.Framework;
using UnityEngine;

namespace Editor.Test
{
    public static class BoardTests
    {
        [Test]
        public static void Ring0Test()
        {
            var zeroRadius = HexBoardUtils.GetHexRing(0);
            Assert.IsTrue(zeroRadius.Count == 1 && zeroRadius[0] == Vector3Int.zero);
        }
        
        [Test]
        public static void Ring1Test()
        {
            var zeroRadius = HexBoardUtils.GetHexRing(1);
            Assert.AreEqual(zeroRadius.Count, 6);
        }
        
        
        [Test]
        public static void Ring2Test()
        {
            var zeroRadius = HexBoardUtils.GetHexRing(2);
            Assert.AreEqual(zeroRadius.Count, 12);
        }

        [Test]
        public static void CreateBoardTest()
        {
            TrypticBoard board = new TrypticBoard();
            Assert.AreEqual(board.);
        }
    }
}