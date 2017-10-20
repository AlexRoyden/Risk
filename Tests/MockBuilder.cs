using System.Collections.Generic;
using Risk;

namespace Tests
{
    class MockBuilder
    {
        public static List<Player> GetPlayerList()
        {
            var player1 = new Player("TestName1", 5, 1);
            var player2 = new Player("TestName2", 5, 2);
            var player3 = new Player("TestName3", 5, 3);
            var player4 = new Player("TestName4", 5, 4);
            var player5 = new Player("TestName5", 5, 5);
            var player6 = new Player("TestName6", 5, 6);
            var players = new List<Player>
            {
                player1,
                player2,
                player3,
                player4,
                player5,
                player6
            };

            return players;
        }

        public static CardDeck GetDeckOfCards()
        {
            var card1 = CreateCard("TestTerritory1", "TestArmy1");
            var card2 = CreateCard("TestTerritory2", "TestArmy2");
            var card3 = CreateCard("TestTerritory3", "TestArmy3");
            var card4 = CreateCard("TestTerritory4", "TestArmy4");
            var card5 = CreateCard("TestTerritory5", "TestArmy5");
            var card6 = CreateCard("TestTerritory6", "TestArmy6");
            var cards = new List<Card>
            {
                card1,
                card2,
                card3,
                card4,
                card5,
                card6
            };
            var deck = new CardDeck {Cards = cards};
            return deck;
        }

        public static Card CreateCard(string territory, string army)
        {
            var card = new Card();
            card.Territory = territory;
            card.Army = army;
            return card;
        }

        public static Queue<Player> GetPlayerQueue()
        {
            var list = GetPlayerList();
            return new Queue<Player>(list);
        }
    }
}
