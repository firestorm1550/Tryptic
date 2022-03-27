using Board;
using DASUnityFramework.Scripts.ExtensionMethods;
using NUnit.Framework;
using UnityEngine;

namespace Editor.Test
{
    public static class BoardTests
    {
        [Test]
        [TestCase(0), TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5)]
        public static void RingTest(int i)
        {
            var hexRing = HexBoardUtils.GetHexRing(2);
            Assert.AreEqual(hexRing.Count, 12);
            
            for(int q = -2; q <= 2; q++)
            for(int r = -2; r <= 2; r++)
            for (int s = -2; s <= 2; s++)
            {
                int absSum = q.Abs() + r.Abs() + s.Abs();
                int sum = q + r + s;
                if (absSum == 4 && sum == 0)
                    Assert.Contains(new Vector3Int(q, r, s), hexRing);
            }
        }

        [Test]
        public static void CreateBoardTest()
        {
            TrypticBoard board = new TrypticBoard();
            Assert.AreEqual(61, board.Spaces.Count);
        }
    }
}