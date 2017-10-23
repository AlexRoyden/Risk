using System;
using System.Collections.Generic;

namespace Risk
{
    class CardTradeingEngine
    {
        private static int _armies;

        public static int TradeMenu(int cardCount)
        {
            var doneTrading = false;
            while (doneTrading == false)
            {
                var player = GameBoard.GetBoard().CurrentPlayer;
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\t       Card trade menu");
                if (cardCount > 6) { Colour.SouthAmericaRed("\tYou must trade at least one set of cards!\n"); }

                Console.WriteLine("\tInfantry cards = " + player.Infantry.Count);
                Console.WriteLine("\tCavalry cards = " + player.Cavalry.Count);
                Console.WriteLine("\tArtillary cards = " + player.Infantry.Count);
                Console.WriteLine("\tWild cards = " + player.Wild.Count);

                Console.WriteLine("\n\t1. Play three of a kind");
                Console.WriteLine("\t2. Play one of each");
                Console.WriteLine("\t3. Play a wild card");
                Console.WriteLine("\t4. Commence deployment of reinforcements");
                Console.WriteLine("\t==========================");
                var option = GameEngine.UserInputTest("\t(1-4)>", "\tInvalid input, please try again!", 1, 4);

                switch (option)
                {
                    case 1:
                        PlayThreeOfAKind(cardCount);
                        break;
                    case 2:
                        PlayOneOfEach(cardCount);
                        break;
                    case 3:
                        PlayWildCard(cardCount);
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

        private static void PlayWildCard(int cardCount)
        {
            var done = false;
            while (done == false)
            {
                var usedCards = new List<Card>();
                var player = GameBoard.GetBoard().CurrentPlayer;
                var infantry = player.Infantry.Count;
                var cavalry = player.Infantry.Count;
                var artillery = player.Infantry.Count;
                var wild = player.Infantry.Count;

                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\tTrade a wild card menu");
                if (cardCount > 6) { Colour.SouthAmericaRed("\tYou must trade at least one set of cards!\n"); }

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
                            usedCards.Add(player.Wild[0]);
                            player.Wild.RemoveAt(0);
                            for (var index = 0; index <= 1; index++)
                            {
                                usedCards.Add(player.Infantry[index]);
                                player.Infantry.RemoveAt(index);
                            }
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            var armies = TradedCardValue();
                            Console.WriteLine("You receive {0} armies", armies);
                            Console.WriteLine("Press any key to continue....");
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
                            usedCards.Add(player.Wild[0]);
                            player.Wild.RemoveAt(0);
                            for (var index = 0; index <= 1; index++)
                            {
                                usedCards.Add(player.Cavalry[index]);
                                player.Cavalry.RemoveAt(index);
                            }
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            var armies = TradedCardValue();
                            Console.WriteLine("You receive {0} armies", armies);
                            Console.WriteLine("Press any key to continue....");
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
                            usedCards.Add(player.Wild[0]);
                            player.Wild.RemoveAt(0);
                            for (var index = 0; index <= 1; index++)
                            {
                                usedCards.Add(player.Artillary[index]);
                                player.Artillary.RemoveAt(index);
                            }
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            var armies = TradedCardValue();
                            Console.WriteLine("You receive {0} armies", armies);
                            Console.WriteLine("Press any key to continue....");
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

        private static void PlayThreeOfAKind(int cardCount)
        {
            var done = false;
            while (done == false)
            {
                var usedCards = new List<Card>();
                var player = GameBoard.GetBoard().CurrentPlayer;
                var infantry = player.Infantry.Count;
                var cavalry = player.Infantry.Count;
                var artillery = player.Infantry.Count;
                var wild = player.Infantry.Count;

                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\tTrade three of a kind menu");
                if (cardCount > 6) { Colour.SouthAmericaRed("\tYou must trade at least one set of cards!\n"); }

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
                                usedCards.Add(player.Infantry[index]);
                                player.Infantry.RemoveAt(index);
                            }
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            var armies = TradedCardValue();
                            Console.WriteLine("You receive {0} armies", armies);
                            Console.WriteLine("Press any key to continue....");
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
                                usedCards.Add(player.Cavalry[index]);
                                player.Cavalry.RemoveAt(index);
                            }
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            var armies = TradedCardValue();
                            Console.WriteLine("You receive {0} armies", armies);
                            Console.WriteLine("Press any key to continue....");
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
                                usedCards.Add(player.Artillary[index]);
                                player.Artillary.RemoveAt(index);
                            }
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            var armies = TradedCardValue();
                            Console.WriteLine("You receive {0} armies", armies);
                            Console.WriteLine("Press any key to continue....");
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

        private static void PlayOneOfEach(int count)
        {
            var done = false;
            while (done == false)
            {
                var usedCards = new List<Card>();
                var player = GameBoard.GetBoard().CurrentPlayer;
                var infantry = player.Infantry.Count;
                var cavalry = player.Infantry.Count;
                var artillery = player.Infantry.Count;
                var wild = player.Infantry.Count;

                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\t  Trade one of each menu");
                if (count > 6) { Colour.SouthAmericaRed("\tYou must trade at least one set of cards!\n"); }

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
                            usedCards.Add(player.Infantry[0]);
                            player.Infantry.RemoveAt(0);
                            usedCards.Add(player.Cavalry[0]);
                            player.Cavalry.RemoveAt(0);
                            usedCards.Add(player.Artillary[0]);
                            player.Artillary.RemoveAt(0);

                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            var armies = TradedCardValue();
                            Console.WriteLine("You receive {0} armies", armies);
                            Console.WriteLine("Press any key to continue....");
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

        private static int TradedCardValue()
        {
            var sets = GameBoard.GetBoard().GetTradedCardSets();

            if (sets == 1)
            {
                _armies += 4;
                return 4;
            }
            if (sets == 2)
            {
                _armies += 6;
                return 6;
            }
            if (sets == 3)
            {
                _armies += 8;
                return 8;
            }
            if (sets == 4)
            {
                _armies += 10;
                return 10;
            }
            if (sets == 5)
            {
                _armies += 12;
                return 12;
            }
            if (sets == 6)
            {
                _armies += 15;
                return 15;
            }
            if (sets > 6)
            {
                var difference = sets - 6;
                var count = 15 + (difference * 5);
                _armies += count;
                return count;
            }

            return 0;
        }
    }
}
