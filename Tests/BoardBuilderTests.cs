﻿using System;
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
            var territories = BoardBuilder.LoadNewTerritories();

            Assert.AreEqual(42,territories.Territories.Count);
        }

        [TestMethod]
        public void TestLoadedTerritoriesAreUnique()
        {
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
            var cards = BoardBuilder.LoadCards(_random);

            Assert.AreEqual(44, cards.Count);
        }

        [TestMethod]
        public void TestUsedCardsQueueMaker()
        {
            var cardDeck = MockBuilder.GetDeckOfCards();
            var rnd = new Random();
            var cards = BoardBuilder.UsedCardsQueueMaker(cardDeck,rnd);

            Assert.Contains(cardDeck.Cards[1], cards);
        }
    }
}
