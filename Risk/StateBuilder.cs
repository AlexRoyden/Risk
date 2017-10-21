using System.Collections.Generic;

namespace Risk
{
    class StateBuilder
    {
        public static GameState GetGameState()
        {
            var board = GameBoard.GetBoard();

            var state = new GameState
            {
                Earth = board.GetEarth(),
                Cards = board.GetQueueOfGameCards(),
                UsedCards = board.GetUsedCards(),
                TradedCardSets = board.GetTradedCardSets(),
                Players = board.GetPlayerList(),
                CurrentPlayer = board.GetCurrentPlayerQueue()
            };

            foreach (var territory in state.Earth.Territories)
            {
                territory.Neighbours = null;
            }
            return state;
        }
    }
}
