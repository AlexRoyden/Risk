using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risk;
using Assert = NUnit.Framework.Assert;


namespace Tests
{
    [TestClass]
    public class BoardBuilderTests
    {
        private readonly Random _random = new Random();

        [TestMethod]
        public void TestAllTerritoriesLoad()
        {
            //var path = GameEngine.PathBuilder();
            var territories = BoardBuilder.LoadNewTerritories();

            Assert.AreEqual(42,territories.Territories.Count);
        }

        [TestMethod]
        public void TestLoadedTerritoriesAreUnique()
        {
            //var path = GameEngine.PathBuilder();
            var earth = BoardBuilder.LoadNewTerritories();
            var rnd1 = _random.Next(0, 41);
            var rnd2 = _random.Next(0, 41);
            while(rnd1 == rnd2) { rnd2 = _random.Next(0, 41); }
            var territory1 = earth.Territories[rnd1];
            var territory2 = earth.Territories[rnd2];

            Assert.AreNotSame(territory1, territory2);
        }

        [TestMethod]
        public void TestAllCardsLoad()
        {
            // path = GameEngine.PathBuilder();
            var cards = BoardBuilder.LoadCards(_random);

            Assert.AreEqual(44, cards.Count);
        }
    }
}
