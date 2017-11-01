namespace Risk
{
    class DiceSingleBattle : BattleOutcome
    {
        public override void Fight(Attack attack)
        {
            if (attack.AttackDice2 == 0 && attack.AttackDice3 == 0)
            {
                Battle.BattleResolve(attack, "");
            }
            else if (Successor != null)
            {
                Successor.Fight(attack);
            }
        }
    }
}
