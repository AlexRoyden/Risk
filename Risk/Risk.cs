namespace Risk
{
    class Risk
    {
        public void Construct(Game game)
        {
            game.CreateGame();
            game.InitializeBoard();
            game.AssignStartingPlayer();
        }
    }
}
