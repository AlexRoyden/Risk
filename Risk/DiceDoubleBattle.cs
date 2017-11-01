﻿namespace Risk
{
    class DiceDoubleBattle : BattleOutcome
    {
        public override void Fight(Attack attack)
        {
            if (attack.AttackDice3 == 0)
            {
                bool twoDefendDie = attack.DefendDice2 != 0;
                Battle.BattleResolve(attack, "(First round)");
                if (attack.DefendingTerritory.Armies > 0 && twoDefendDie)
                {
                    Battle.BattleResolve(attack, "(Second round)");
                }
            }
            else if (Successor != null)
            {
                Successor.Fight(attack);
            }
        }
    }
}
