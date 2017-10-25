using System;
using System.Collections.Generic;

namespace Risk
{
    class CardTradeingEngine
    {
        private static int _armies;
        private static PlayersCards _cards;

        public static int TradeMenu()
        {
            var player = GameBoard.GetBoard().CurrentPlayer;
            _cards = new PlayersCards(player.Cards);

            var doneTrading = false;
            while (doneTrading == false)
            {
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\t       Card trade menu");
                if (player.Cards.Count > 6) { Colour.SouthAmericaRed("\tYou must trade at least one set of cards!\n"); }

                Console.WriteLine("\tInfantry cards = " + _cards.Infantry.Count);
                Console.WriteLine("\tCavalry cards = " + _cards.Cavalry.Count);
                Console.WriteLine("\tArtillary cards = " + _cards.Infantry.Count);
                Console.WriteLine("\tWild cards = " + _cards.Wild.Count);

                Console.WriteLine("\n\t1. Play three of a kind");
                Console.WriteLine("\t2. Play one of each");
                Console.WriteLine("\t3. Play a wild card");
                Console.WriteLine("\t4. Commence deployment of reinforcements");
                Console.WriteLine("\t==========================");
                var option = GameEngine.UserInputTest("\t(1-4)>", "\tInvalid input, please try again!", 1, 4);

                switch (option)
                {
                    case 1:
                        PlayThreeOfAKind();
                        break;
                    case 2:
                        PlayOneOfEach();
                        break;
                    case 3:
                        PlayWildCard();
                        break;
                    case 4:
                        doneTrading = true;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
            return _armies;
        }

        private static void PlayWildCard()
        {
            var done = false;
            while (done == false)
            {
                var usedCards = new List<Card>();
                var player = GameBoard.GetBoard().CurrentPlayer;
                var infantry = _cards.Infantry.Count;
                var cavalry = _cards.Infantry.Count;
                var artillery = _cards.Infantry.Count;
                var wild = _cards.Infantry.Count;

                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\tTrade a wild card menu");
                if (player.Cards.Count > 6) { Colour.SouthAmericaRed("\tYou must trade at least one set of cards!\n"); }

                Console.WriteLine("\tInfantry cards = " + infantry);
                Console.WriteLine("\tCavalry cards = " + cavalry);
                Console.WriteLine("\tArtillary cards = " + artillery);
                Console.WriteLine("\tWild cards = " + wild);

                Console.WriteLine("\t1. Play a wild card with two infantry cards");
                Console.WriteLine("\t2. Play a wild card with two cavalry cards");
                Console.WriteLine("\t3. Play a wild card with two artillary cards");
                Console.WriteLine("\t4. return to previous menu");
                Console.WriteLine("\t==========================");
                var option = GameEngine.UserInputTest("\t(1-4)>", "\tInvalid input, please try again!", 1, 4);

                switch (option)
                {
                    case 1:
                        if (infantry >= 2)
                        {
                            usedCards.Add(_cards.Wild[0]);
                            _cards.Wild.RemoveAt(0);
                            for (var index = 0; index <= 1; index++)
                            {
                                usedCards.Add(_cards.Infantry[index]);
                                _cards.Infantry.RemoveAt(index);
                            }
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("Cards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You do not have enough of that type of card!");
                        }
                        break;
                    case 2:
                        if (cavalry >= 3)
                        {
                            usedCards.Add(_cards.Wild[0]);
                            _cards.Wild.RemoveAt(0);
                            for (var index = 0; index <= 1; index++)
                            {
                                usedCards.Add(_cards.Cavalry[index]);
                                _cards.Cavalry.RemoveAt(index);
                            }
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("Cards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You do not have enough of that type of card!");
                        }
                        break;
                    case 3:
                        if (artillery >= 3)
                        {
                            usedCards.Add(_cards.Wild[0]);
                            _cards.Wild.RemoveAt(0);
                            for (var index = 0; index <= 1; index++)
                            {
                                usedCards.Add(_cards.Artillary[index]);
                                _cards.Artillary.RemoveAt(index);
                            }
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("Cards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You do not have enough of that type of card!");
                        }
                        break;
                    case 4:
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }

        private static void PlayThreeOfAKind()
        {
            var done = false;
            while (done == false)
            {
                var usedCards = new List<Card>();
                var player = GameBoard.GetBoard().CurrentPlayer;
                var infantry = _cards.Infantry.Count;
                var cavalry = _cards.Infantry.Count;
                var artillery = _cards.Infantry.Count;
                var wild = _cards.Infantry.Count;

                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\tTrade three of a kind menu");
                if (player.Cards.Count > 6) { Colour.SouthAmericaRed("\tYou must trade at least one set of cards!\n"); }

                Console.WriteLine("\tInfantry cards = " + infantry);
                Console.WriteLine("\tCavalry cards = " + cavalry);
                Console.WriteLine("\tArtillary cards = " + artillery);
                Console.WriteLine("\tWild cards = " + wild);

                Console.WriteLine("\t1. Play three infantry cards");
                Console.WriteLine("\t2. Play three cavalry cards");
                Console.WriteLine("\t3. Play three artillary cards");
                Console.WriteLine("\t4. return to previous menu");
                Console.WriteLine("\t==========================");
                var option = GameEngine.UserInputTest("\t(1-4)>", "\tInvalid input, please try again!", 1, 4);

                switch (option)
                {
                    case 1:
                        if (infantry >= 3)
                        {
                            for (var index = 0; index <= 2; index++)
                            {
                                usedCards.Add(_cards.Infantry[index]);
                                _cards.Infantry.RemoveAt(index);
                            }
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("Cards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You do not have enough of that type of card!");
                        }
                        break;
                    case 2:
                        if (cavalry >= 3)
                        {
                            for (var index = 0; index <= 2; index++)
                            {
                                usedCards.Add(_cards.Cavalry[index]);
                                _cards.Cavalry.RemoveAt(index);
                            }
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("Cards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You do not have enough of that type of card!");
                        }
                        break;
                    case 3:
                        if (artillery >= 3)
                        {
                            for (var index = 0; index <= 2; index++)
                            {
                                usedCards.Add(_cards.Artillary[index]);
                                _cards.Artillary.RemoveAt(index);
                            }
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("Cards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You do not have enough of that type of card!");
                        }
                        break;
                    case 4:
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }

        private static void PlayOneOfEach()
        {
            var done = false;
            while (done == false)
            {
                var usedCards = new List<Card>();
                var player = GameBoard.GetBoard().CurrentPlayer;
                var infantry = _cards.Infantry.Count;
                var cavalry = _cards.Infantry.Count;
                var artillery = _cards.Infantry.Count;
                var wild = _cards.Infantry.Count;

                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\t  Trade one of each menu");
                if (player.Cards.Count > 6) { Colour.SouthAmericaRed("\tYou must trade at least one set of cards!\n"); }

                Console.WriteLine("\tInfantry cards = " + infantry);
                Console.WriteLine("\tCavalry cards = " + cavalry);
                Console.WriteLine("\tArtillary cards = " + artillery);
                Console.WriteLine("\tWild cards = " + wild);

                Console.WriteLine("\t1. Play one of each card");
                Console.WriteLine("\t2. return to previous menu");
                Console.WriteLine("\t==========================");
                var option = GameEngine.UserInputTest("\t(1-2)>", "\tInvalid input, please try again!", 1, 2);

                switch (option)
                {
                    case 1:
                        if (infantry >= 1 && cavalry >= 1 && artillery >= 1)
                        {
                            usedCards.Add(_cards.Infantry[0]);
                            _cards.Infantry.RemoveAt(0);
                            usedCards.Add(_cards.Cavalry[0]);
                            _cards.Cavalry.RemoveAt(0);
                            usedCards.Add(_cards.Artillary[0]);
                            _cards.Artillary.RemoveAt(0);

                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("Cards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You do not have enough of each card type!");
                        }
                        break;
                    case 2:
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }

        private static void TradedCardValue()
        {
            var sets = GameBoard.GetBoard().GetTradedCardSets();
            sets += 1;

            if (sets == 1)
            {
                _armies += 4;
            }
            if (sets == 2)
            {
                _armies += 6;
            }
            if (sets == 3)
            {
                _armies += 8;
            }
            if (sets == 4)
            {
                _armies += 10;
            }
            if (sets == 5)
            {
                _armies += 12;
            }
            if (sets == 6)
            {
                _armies += 15;
            }
            if (sets > 6)
            {
                var difference = sets - 6;
                _armies += 15 + difference * 5;
            }
        }
    }
}
