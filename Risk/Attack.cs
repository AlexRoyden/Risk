namespace Risk
{
    class Attack
    {
        public int AttackDiceCount { get; set; }
        public int DefendDiceCount { get; set; }
        public int AttackDice1 { get; set; }
        public int AttackDice2 { get; set; }
        public int AttackDice3 { get; set; }
        public int DefendDice1 { get; set; }
        public int DefendDice2 { get; set; }

        public Player Attacker { get; set; }
        public Player Defender { get; set; }

        public Territory AttackingTerritory { get; set; }
        public Territory DefendingTerritory { get; set; }

        public Attack(Player attacker, Player defender, Territory attack, Territory defend)
        {
            Attacker = attacker;
            Defender = defender;
            AttackingTerritory = attack;
            DefendingTerritory = defend;
        }
    }
}
