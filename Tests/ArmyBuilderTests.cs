using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risk;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    [TestClass]
    public class ArmyBuilderTests
    {
        [TestMethod]
        public void TerritoryCountIsCorrect()
        {
            var earth = MockBuilder.GetEarth();
            var player = new Player("TestName", 0, 1);

            var result = ArmyBuilder.ArmiesForTerritoriesOccupied(earth, player);

            Assert.IsTrue(result == 9);
        }

        [TestMethod]
        public void ContinentCountIsCorrect()
        {
            var earth = MockBuilder.GetEarth();
            var player = new Player("TestName", 0, 1);

            var result = ArmyBuilder.ArmiesForContinentsOccupied(earth, player);

            Assert.IsTrue(result == 17);
        }

        [TestMethod]
        public void PlayerWithoutCardsCantTrade()
        {
            var player = new Player("TestName", 0, 1);

            var result = ArmyBuilder.TradeCards(player);

            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void ContinentIsRuledByPlayer()
        {
            var list = new List<string> {"TestName", "TestName", "TestName", "TestName"};

            var result = ArmyBuilder.CheckContinentForRuler(list, "TestName");

            Assert.IsTrue(result);
        }
    }
}
