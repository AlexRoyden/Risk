using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risk;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    [TestClass]
    public class BattleBuilderTests
    {
        [TestMethod]
        public void CheckDieOptionAttackerTrue()
        {
            var territory = new Territory
            {
                Armies = 4,
            };

            var result = BattleBuilder.CheckDieOption(3, "attacker", territory);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckDieOptionAttackerFalse()
        {
            var territory = new Territory
            {
                Armies = 3
            };

            var result = BattleBuilder.CheckDieOption(3, "attacker", territory);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckDieOptionDefenderFirstConditionTrue()
        {
            var territory = new Territory
            {
                Armies = 2
            };

            var result = BattleBuilder.CheckDieOption(2, "defender", territory);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckDieOptionDefenderSecondConditionTrue()
        {
            var territory = new Territory
            {
                Armies = 1
            };

            var result = BattleBuilder.CheckDieOption(1, "defender", territory);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckDieOptionDefenderFalse()
        {
            var territory = new Territory
            {
                Armies = 1
            };

            var result = BattleBuilder.CheckDieOption(2, "defender", territory);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckBattleRollOptions()
        {
            var attack = new Attack();
            attack.AttackDiceCount = 3;
            attack.DefendDiceCount = 1;

            BattleBuilder.BattleRollOptions(attack);

            Assert.IsTrue(attack.AttackDice1 != 0 && attack.AttackDice2 != 0 && attack.AttackDice3 != 0
                && attack.DefendDice1 != 0);
        }
    }
}
