using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risk;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    [TestClass]
    public class GameBoardTests
    {
        [TestMethod]
        public void TestGameBoardConstructor()
        {
            Assert.IsNotNull(GameBoard.GetBoard());
        }

        [TestMethod]
        public void GetBoardMethodTest()
        {
            Assert.IsInstanceOf<GameBoard>(GameBoard.GetBoard());
        }

        [TestMethod]
        public void GetRandomMethodTest()
        {
            Assert.IsNotNull(GameBoard.GetBoard().GetRandom());
        }

        [TestMethod]
        public void GetEarthMethodTest()
        {
            Assert.IsNotNull(GameBoard.GetBoard().GetEarth());
        }

        [TestMethod]
        public void GetCardMethodTest()
        {
            Assert.IsNotNull(GameBoard.GetBoard().GetGameCard());
        }

        [TestMethod]
        public void SetPlayerListMethodTest()
        {
            GameBoard.GetBoard().SetPlayerList(MockBuilder.GetPlayerList());
            var rnd = GameBoard.GetBoard().GetRandom();
            var index = rnd.Next(0, 5);
            var list = GameBoard.GetBoard().GetPlayerList();
            var testList = MockBuilder.GetPlayerList();

            Assert.IsTrue(list[index].Name == testList[index].Name);
        }

        [TestMethod]
        public void GetPlayerListMethodTest()
        {
            Assert.IsNotNull(GameBoard.GetBoard().GetPlayerList());
        }

        [TestMethod]
        public void GetPlayerByIndexMethodTest()
        {
            GameBoard.GetBoard().SetPlayerList(MockBuilder.GetPlayerList());
            var rnd = GameBoard.GetBoard().GetRandom();
            var index = rnd.Next(0, 5);
            var testList = MockBuilder.GetPlayerList();

            Assert.IsTrue(GameBoard.GetBoard().GetPlayerByIndex(index).Name == testList[index].Name);
        }

        [TestMethod]
        public void SetPlayerTurnQueueMethodTest()
        {
            GameBoard.GetBoard().SetPlayerTurnQueue(MockBuilder.GetPlayerQueue());
            var rnd = GameBoard.GetBoard().GetRandom();
            var index = rnd.Next(0, 5);
            var queue = GameBoard.GetBoard().GetPlayerList();
            var testQueue = MockBuilder.GetPlayerList();

            Assert.IsTrue(queue[index].Name == testQueue[index].Name);
        }
    }
}
