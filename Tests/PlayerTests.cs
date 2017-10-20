using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risk;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            var player = new Player("TestName", 5, 1);

            Assert.IsTrue(player.Name == "TestName" && player.Armies == 5 && player.Colour == 1);
        }
    }
}
