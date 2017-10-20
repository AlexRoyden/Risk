using System;
using System.Collections.Generic;

namespace Risk
{
    public class GameBoard
    {
        private static GameBoard _board;
        private readonly Random _random;
        private Earth _earth;
        private Queue<Card> _cards;
        public CardDeck UsedCards;
        private int _tradedCardSets;
        private List<Player> _players;
        private Queue<Player> _currentPlayer;

        private GameBoard()
        {
            _random = new Random();
            //var path = GameEngine.PathBuilder();
            _earth =  BoardBuilder.LoadNewTerritories();
            _cards = BoardBuilder.LoadCards(_random);
            UsedCards = new CardDeck();
            _tradedCardSets = 0;
            _players = new List<Player>();
            _currentPlayer = new Queue<Player>();
        }

        public static GameBoard GetBoard()
        {
            if (_board == null)
            {
                _board = new GameBoard();
            }
            return _board;
        }

        public Random GetRandom()
        {
            return _random;
        }

        public Earth GetEarth()
        {
            return _earth;
        }

        public void SetEarth(string gameType)
        {
            //var path = GameEngine.PathBuilder();
            _earth = BoardBuilder.LoadNewTerritories();
        }

        public Territory GetTerritoryByName(string name)
        {
            foreach (var territory in _earth.Territories)
            {
                if (territory.Name == name)
                {
                    return territory;
                }
            }
            return null;
        }

        public void SetGameCards()
        {
            //var path = GameEngine.PathBuilder();
            _cards = BoardBuilder.LoadCards(_random);
        }

        public Card GetGameCard()
        {
            if (_cards.Count < 1)
            {
                _cards = BoardBuilder.UsedCardsQueueMaker(UsedCards, _random);
            }
            return _cards.Dequeue();
        }

        public void AddToUsedCardPile(List<Card> cards)
        {
            foreach (var card in cards)
            {
                UsedCards.Cards.Add(card);
                _tradedCardSets += 1;
            }
        }

        public void SetPlayerList(List<Player> list)
        {
            _players = list;
        }

        public List<Player> GetPlayerList()
        {
            return _players;
        }

        public Player GetPlayerByIndex(int index)
        {
            return _players[index];
        }

        public Player GetPlayerByName(string name)
        {
            foreach (var player in _players)
            {
                if (player.Name == name)
                {
                    return player;
                }
            }
            return null;
        }

        public void SetPlayerTurnQueue(Queue<Player> queue)
        {
            _currentPlayer = queue;
        }

        public Player GetCurrentPlayer()
        {
            var currentPlayer = _currentPlayer.Dequeue();
            var player = new Player(null, 0, 1);
            var match = false;

            while (match == false)
            {
                foreach (var person in _players)
                {
                    if (person.Name == currentPlayer.Name)
                    {
                        _currentPlayer.Enqueue(currentPlayer);
                        player = person;
                        match = true;
                    }
                }
            }
            return player;
        }
    }
}
