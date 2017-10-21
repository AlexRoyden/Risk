using System.IO;
using Newtonsoft.Json;
using Risk.Mappers;

namespace Risk
{
    class GameLoader
    {
        public static void LoadGame(string path, int slot)
        {
            GameStateMapper game;

            using (var stream = new StreamReader(path))
            {
                var json = stream.ReadToEnd();
                game = JsonConvert.DeserializeObject<GameStateMapper>(json);
            }

            BoardBuilder(game);
        }

        public static void BoardBuilder(GameStateMapper mapper)
        {
            var board = GameBoard.GetBoard();
            board.SetEarth(mapper.Earth);
            board.SetGameCards(mapper.Cards);
            board.SetUsedCards(mapper.UsedCards);
            board.SetTradedCardSets(mapper.TradedCardSets);
            board.SetPlayerList(mapper.Players);
            board.SetPlayerTurnQueue(mapper.CurrentPlayer);

            Risk.BoardBuilder.LoadTerritoryNeighbours();
            MenuBuilder.PlayerTurnMenu();
        }
    }
}
