namespace Risk
{
    class PlayerTurn
    {
        public static void GamePlay()
        {
            var board = GameBoard.GetBoard();

            board.CurrentPlayer.Armies = ArmyBuilder.ReinforcmentsCalculator();

            GamePlayMenus.PlayerTurnMenu();
        }
    }
}
