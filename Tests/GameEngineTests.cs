using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Risk;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    [TestClass]
    public class GameEngineTests
    {
        //[TestMethod]
        //public void TestPathBuilderReturnsPath()
        //{
        //    var pathString = @"C:\Users\aroyd\Documents\Study\Year 3 Semester 1\Software dev\Assignment2\Risk\Tests\ConfigFiles";
        //    var path = GameEngine.PathBuilder();

        //    Assert.IsTrue(pathString == path);
        //}

        [TestMethod]
        public void TestHighestRollreturnsAWinner()
        {
            var players = MockBuilder.GetPlayerList();
            var winner = GameEngine.HighestRoll(players);

            Assert.IsTrue(winner == players[0] || winner == players[1] || winner == players[2] 
                || winner == players[3] || winner == players[4] || winner == players[5]);
        }

        [TestMethod]
        public void TestGetPlayerIndexMethodReturnsIndex()
        {
            var players = MockBuilder.GetPlayerList();
            var board = GameBoard.GetBoard();
            board.SetPlayerList(players);

            Assert.IsTrue(GameEngine.GetPlayerIndex("TestName3") == 2);
        }

        [TestMethod]
        public void TestGetPlayerColourIndexMethodReturnsInt()
        {
            var players = MockBuilder.GetPlayerList();
            players[2].Colour = 2;
            var board = GameBoard.GetBoard();
            board.SetPlayerList(players);

            Assert.IsTrue(GameEngine.GetPlayerColourIndex("TestName3") == 2);
        }

        [TestMethod]
        public void TestBufferBuilderBufferLength()
        {
            var testBuffer = "     ";
            var buffer = GameEngine.BufferBuilder(5, 10);

            Assert.IsTrue(buffer == testBuffer);
        }

        [TestMethod]
        public void TestCreateTurnQueueIsCorrectOrder()
        {
            var players = MockBuilder.GetPlayerList();
            GameBoard.GetBoard().SetPlayerList(players);
            var rnd = GameBoard.GetBoard().GetRandom();
            var player = GameBoard.GetBoard().GetPlayerByIndex(rnd.Next(0, 5));

            var queue = GameEngine.CreateTurnQueue(player);

            Assert.IsTrue(queue.Dequeue().Name == player.Name);
        }
    }
}
