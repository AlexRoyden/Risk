using System;
using Risk.Menus;

namespace Risk
{
    class PlayerTurn
    {
        public static void GamePlay()
        {
            var board = GameBoard.GetBoard();

            Console.Clear();
            Colour.SouthAmericaRed("\t     **** Risk! ****\n");
            Console.WriteLine("\t==========================");
            GameEngine.Timer("Next players turn is about to begin");

            board.CurrentPlayer.Armies = ArmyBuilder.ReinforcmentsCalculator();
            TroopDeployer.DeployTroops(board.CurrentPlayer);

            Console.Clear();
            Colour.SouthAmericaRed("\t     **** Risk! ****\n");
            Console.WriteLine("\t==========================");
            GameEngine.Timer("Battle phase about to begin");
            BattleBuilder.BattleMenu();

            GamePlayMenus.PlayerTurnMenu();
        }
    }
}
