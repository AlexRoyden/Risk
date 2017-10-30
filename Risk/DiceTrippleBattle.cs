using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk
{
    class DiceTrippleBattle : BattleOutcome
    {
        public override void Fight(Attack attack)
        {
            if (attack.AttackDice1 != 0 && attack.AttackDice2 != 0 && attack.AttackDice3 != 0)
            {
                Battle.BattleResolve(attack, "(First round)");
                if (attack.DefendingTerritory.Armies != 0)
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
