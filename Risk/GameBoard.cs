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
        private CardDeck _usedCards;
        private int _tradedCardSets;
        private List<Player> _players;
        private Queue<Player> _currentPlayer;

        private GameBoard()
        {
            _random = new Random();
            _earth =  BoardBuilder.LoadNewTerritories();
            _cards = BoardBuilder.LoadCards(_random);
            _usedCards = new CardDeck();
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

        public void SetEarth(Earth earth)
        {
            _earth = earth;
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

        public void SetGameCards(Queue<Card> cards)
        {
            _cards = cards;
        }

        public Queue<Card> GetQueueOfGameCards()
        {
            return _cards;
        }

        public Card GetGameCard()
        {
            if (_cards.Count < 1)
            {
                _cards = BoardBuilder.UsedCardsQueueMaker(_usedCards, _random);
            }
            return _cards.Dequeue();
        }

        public void AddToUsedCardPile(List<Card> cards)
        {
            var count = 0;
            foreach (var card in cards)
            {
                _usedCards.Cards.Add(card);
                count++;
            }
            _tradedCardSets = count / 3;
        }

        public void SetUsedCards(CardDeck cards)
        {
            _usedCards = cards;
        }

        public CardDeck GetUsedCards()
        {
            return _usedCards;
        }

        public int GetTradedCardSets()
        {
            return _tradedCardSets;
        }

        public void SetTradedCardSets(int count)
        {
            _tradedCardSets = count;
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

        public Queue<Player> GetCurrentPlayerQueue()
        {
            return _currentPlayer;
        }
    }
}
