using System.IO;
using Newtonsoft.Json;
using Risk.Mappers;
using Risk.Menus;

namespace Risk
{
    sealed class LoadedGame : Game
    {
        private GameStateMapper _mapper;

        public override void CreateGame()
        {
            var slot = GamePlayMenus.SaveGameMenu("load");
            if(slot == 7) { GameCreationMenus.StartMenu();}
            var path = PathFinder(slot);
            LoadGame(path);
            InitializeBoard();
            var play = new PlayerTurn();
            play.GamePlay();
        }

        public override void InitializeBoard()
        {
            var board = GameBoard.GetBoard();
            board.SetEarth(_mapper.Earth);
            board.SetGameCards(_mapper.Cards);
            board.SetUsedCards(_mapper.UsedCards);
            board.SetTradedCardSets(_mapper.TradedCardSets);
            board.SetPlayerList(_mapper.Players);
            board.SetPlayerTurnQueue(_mapper.PlayerTurnQueue);
            AssignStartingPlayer();
            BoardBuilder.LoadTerritoryNeighbours();
        }

        public override void AssignStartingPlayer()
        {
            GameBoard.GetBoard().CurrentPlayer = _mapper.CurrentPlayer;
        }

        private string PathFinder(int slot)
        {
            switch (slot)
            {
                case 1:
                    return @"..\..\SaveFiles\save1.json";
                case 2:
                    return @"..\..\SaveFiles\save2.json";
                case 3:
                    return @"..\..\SaveFiles\save3.json";
                case 4:
                    return @"..\..\SaveFiles\save4.json";
                case 5:
                    return @"..\..\SaveFiles\save5.json";
                case 6:
                    return @"..\..\SaveFiles\save6.json";
                default:
                    return "Error";
            }
        }

        public void LoadGame(string path)
        {
            using (var stream = new StreamReader(path))
            {
                _mapper = new GameStateMapper();
                var json = stream.ReadToEnd();
                _mapper = JsonConvert.DeserializeObject<GameStateMapper>(json);
            }
        }
    }
}
