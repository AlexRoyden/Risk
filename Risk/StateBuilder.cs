using Risk.Mappers;

namespace Risk
{
    class StateBuilder
    {
        public static GameStateMapper GetGameState()
        {
            var board = GameBoard.GetBoard();

            var state = new GameStateMapper
            {
                Earth = board.GetEarth(),
                Cards = board.GetQueueOfGameCards(),
                UsedCards = board.GetUsedCards(),
                TradedCardSets = board.GetTradedCardSets(),
                Players = board.GetPlayerList(),
                CurrentPlayer = board.CurrentPlayer,
                PlayerTurnQueue = board.GetCurrentPlayerQueue()
            };

            foreach (var territory in state.Earth.Territories)
            {
                territory.Neighbours = null;
            }
            return state;
        }
    }
}
