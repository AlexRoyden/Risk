using System;
using System.Runtime.InteropServices;

namespace Risk
{
    class PlayerTurn
    {
        public static void GamePlay()
        {
            var board = GameBoard.GetBoard();
            var playerList = board.GetPlayerList();

            while (playerList.Count > 1)
            {
                var player = board.CurrentPlayer;

                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================\n");
                GameEngine.Timer(player.Name + " Your turn is about to begin ");

                if (player.Phase != 2 && player.Phase != 3)
                {
                    ReinforcementsPhase(board);
                }
                if (player.Phase != 3)
                {
                    BattlePhase();
                }
                TroopMovementPhase();

                if (player.ConqueredDuringTurn > 0)
                {
                    Console.Clear();
                    Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                    Console.WriteLine("\t==========================");
                    GameEngine.Timer("You receive a game card for conquerering a territory this turn.");
                    player.Cards.Add(board.GetGameCard());
                }

                player.ConqueredDuringTurn = 0;
                player.Phase = 0;
                board.SetCurrentPlayer();
            }
        }

        private static void ReinforcementsPhase(GameBoard board)
        {
            board.CurrentPlayer.Armies = ArmyBuilder.ReinforcmentsCalculator();
            TroopDeployer.DeployTroops(board.CurrentPlayer);
        }

        private static void BattlePhase()
        {
            var player = GameBoard.GetBoard().CurrentPlayer;
            player.Phase = 2;
            Console.Clear();
            Colour.SouthAmericaRed("\t     **** Risk! ****\n");
            Console.WriteLine("\t==========================");
            GameEngine.Timer("Battle phase about to begin");
            BattleBuilder.BattleMenu();
        }

        private static void TroopMovementPhase()
        {
            var player = GameBoard.GetBoard().CurrentPlayer;
            player.Phase = 3;
            Console.Clear();
            Colour.SouthAmericaRed("\t     **** Risk! ****\n");
            Console.WriteLine("\t==================================");
            GameEngine.Timer("Fortification phase about to begin");
        }
    }
}
