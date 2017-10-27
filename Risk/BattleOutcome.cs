namespace Risk
{
    abstract class BattleOutcome
    {
        protected BattleOutcome Successor;

        public void SetSuccessor(BattleOutcome successor)
        {
            Successor = successor;
        }

        public abstract void Fight(Attack attack);
    }
}
