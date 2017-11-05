using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risk;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    [TestClass]
    public class BoardPopulatorTests
    {
        [TestMethod]
        public void TestCheckMapIsFull()
        {
            var board = GameBoard.GetBoard();
            foreach (var territory in board.GetEarth().Territories)
            {
                territory.Occupant = "TestName";
            }

            Assert.IsTrue(BoardPopulator.CheckMapIsFull(board));
        }

        [TestMethod]
        public void TestTerritoryIsFound()
        {
            var territory = BoardPopulator.FindTerritory(1);

            Assert.IsTrue(territory.Name == "Afghanistan");
        }
    }
}
