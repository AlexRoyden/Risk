namespace Risk
{
    //Builder Abstract base class
    public abstract class Game
    {
        protected GameBoard GameBoard;

        public GameBoard GetGameBoard()
        {
            return GameBoard;
        }

        public abstract void CreateGame();
        public abstract void InitializeBoard();
        public abstract void AssignStartingPlayer();
    }
}
