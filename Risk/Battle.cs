using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk
{
    class Battle
    {
        public static void BeginBattle(Attack attack)
        {
            BattleOutcome singleDie = new DiceSingleBattle();
            BattleOutcome doubleDie = new DiceDoubleBattle();
            BattleOutcome trippleDie = new DiceTrippleBattle();

            singleDie.SetSuccessor(doubleDie);
            doubleDie.SetSuccessor(trippleDie);

            GameEngine.Timer("Rolling dice");

            singleDie.Fight(attack);
        }

        public static void BattleResolve(Attack attack, string round)
        {
            int attacker = attack.AttackDice1;
            int attackDice = 1;
            int defender = attack.DefendDice1;
            int defendDice = 1;

            if (attack.AttackDice2 > attacker)
            {
                attacker = attack.AttackDice2;
                attackDice = 2;
            }
            else if (attack.AttackDice3 > attacker)
            {
                attacker = attack.AttackDice3;
                attackDice = 3;
            }

            if (attack.DefendDice2 > defender)
            {
                defender = attack.DefendDice2;
                defendDice = 2;
            }

            if (attacker > defender)
            {
                attack.DefendingTerritory.Armies -= 1;
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\t       Battle outcome");
                Console.WriteLine("\t       {0}\n", round);
                Colour.PrintPlayer(attack.Attacker.Colour, "\t" + attack.Attacker.Name + "'s");
                Console.Write(", Highest attacking roll was {0}.\n\t", attacker);
                Colour.PrintPlayer(attack.Defender.Colour, attack.Defender.Name + "'s");
                Console.Write(", Highest defending roll was {0}.\n", defender);
                Colour.PrintPlayer(attack.Defender.Colour, "\n\t" + attack.Defender.Name);
                Console.WriteLine(", was defeated and has lost 1 army.");
                Console.WriteLine("\tPress any key to continue....");
                Console.ReadKey();
            }
            else
            {
                attack.AttackingTerritory.Armies -= 1;
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\t       Battle outcome");
                Console.WriteLine("\t       {0}\n", round);
                Colour.PrintPlayer(attack.Attacker.Colour, "\t" + attack.Attacker.Name + "'s");
                Console.Write(", Highest attacking roll was {0}.\n\t", attacker);
                Colour.PrintPlayer(attack.Defender.Colour, attack.Defender.Name + "'s");
                Console.Write(", Highest defending roll was {0}.\n", defender);
                Colour.PrintPlayer(attack.Attacker.Colour, "\n\t" + attack.Attacker.Name);
                Console.WriteLine(", was defeated and has lost 1 army.");
                Console.WriteLine("\tPress any key to continue....");
                Console.ReadKey();
            }

            if (attackDice == 1)
            {
                attack.AttackDice1 = 0;
            }
            else if (attackDice == 2)
            {
                attack.AttackDice2 = 0;
            }
            else if (attackDice == 3)
            {
                attack.AttackDice3 = 0;
            }

            if (defendDice == 1)
            {
                attack.DefendDice1 = 0;
            }
            else if (defendDice == 2)
            {
                attack.DefendDice2 = 0;
            }
        }
    }
}
