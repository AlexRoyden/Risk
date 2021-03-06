﻿using System.Collections.Generic;

namespace Risk
{
    class PlayerTurn
    {
        public void GamePlay()
        {
            var board = GameBoard.GetBoard();
            var playerList = board.GetPlayerList();

            while (playerList.Count > 1)
            {
                var player = board.CurrentPlayer;
                if (player.GameEntryPoint == 0)
                {
                    player.ConqueredDuringTurn = 0;
                }
                GameEngine.Timer(player.Name + " Your turn is about to begin ");

                if (player.GameEntryPoint != 2 && player.GameEntryPoint != 3)
                {
                    ReinforcementsPhase(board);
                }
                if (player.GameEntryPoint != 3)
                {
                    BattlePhase();
                }
                TroopMovementPhase();

                if (player.ConqueredDuringTurn > 0)
                {
                    GameEngine.Timer("You conquered a territory, receiving a Game Card.");
                    var card = board.GetGameCard();
                    if (player.Cards == null)
                    {
                        player.Cards = new List<Card> {card};
                    }
                    else
                    {
                        player.Cards.Add(card);
                    }
                }

                player.GameEntryPoint = 0;
                board.SetCurrentPlayer();
            }
        }

        private void ReinforcementsPhase(GameBoard board)
        {
            board.CurrentPlayer.Armies = ArmyBuilder.ReinforcmentsCalculator(board.GetEarth(), board.CurrentPlayer);
            TroopDeployer.DeployTroops(board.CurrentPlayer);
        }

        private void BattlePhase()
        {
            var player = GameBoard.GetBoard().CurrentPlayer;
            player.GameEntryPoint = 2;
            GameEngine.Timer("Battle phase about to begin");
            var battle = new Battle();
            battle.BattleMenu();
        }

        private void TroopMovementPhase()
        {
            var player = GameBoard.GetBoard().CurrentPlayer;
            player.GameEntryPoint = 3;
            GameEngine.Timer("Fortification phase about to begin");
            TeritoriesFortification.FortificationMenu();
        }
    }
}
