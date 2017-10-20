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
            var number = Dice.Roll(rnd);

            Assert.IsTrue(number >= 1 && number <= 6);
        }

    }
}
