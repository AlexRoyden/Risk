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
        public Player CurrentPlayer;
        private Queue<Player> _playerTurnQueue;

        private GameBoard()
        {
            _random = new Random();
            _earth =  BoardBuilder.LoadNewTerritories();
            _cards = BoardBuilder.LoadCards(_random);
            _usedCards = new CardDeck();
            _tradedCardSets = 0;
            _players = new List<Player>();
            CurrentPlayer = new Player();
            _playerTurnQueue = new Queue<Player>();
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
            foreach (var card in cards)
            {
                _usedCards.Cards.Add(card);
            }
            _tradedCardSets += 1;
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
            _playerTurnQueue = queue;
        }

        public void SetCurrentPlayer()
        {
            if (CurrentPlayer.Name == null)
            {
                CurrentPlayer = _playerTurnQueue.Dequeue();
            }
            else
            {
                var oldPlayer = new Player
                {
                    Name = CurrentPlayer.Name,
                    Armies = CurrentPlayer.Armies,
                    Colour = CurrentPlayer.Colour
                };
                _playerTurnQueue.Enqueue(oldPlayer);

                CurrentPlayer = _playerTurnQueue.Dequeue();
            }
            
            //var match = false;

            //while (match == false)
            //{
            //    foreach (var person in _players)
            //    {
            //        if (person.Name == newPlayer.Name)
            //        {
            //            CurrentPlayer.Name = newPlayer.Name;
            //            CurrentPlayer.Armies = newPlayer.Armies;
            //            CurrentPlayer.Colour = newPlayer.Colour;
            //            _playerTurnQueue.Enqueue(newPlayer);

            //            match = true;
            //        }
            //    }
            //}
        }

        public Queue<Player> GetCurrentPlayerQueue()
        {
            return _playerTurnQueue;
        }
    }
}
