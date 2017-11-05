using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risk;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    [TestClass]
    public class DiceTests
    {
        [TestMethod]
        public void TestRollIsInRange()
        {
            var rnd = new Random();
            var die = new Dice(rnd);
            var number = die.Roll(rnd);

            Assert.IsTrue(number >= 1 && number <= 6);
        }

    }
}
