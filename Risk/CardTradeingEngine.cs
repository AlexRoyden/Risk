using System;
using System.Collections.Generic;
using Risk.Menus;

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
                Console.Write("\tCurrently ");
                Colour.PrintPlayer(player.Colour, player.Name + "'s");
                Console.Write(" turn.\n");
                if (player.Cards.Count > 6) { Colour.SouthAmericaRed("\tYou must trade at least one set of cards!\n"); }

                int infantryCount, cavalryCount, artillaryCount, wildCount;
                if (_cards.Infantry == null)
                {
                    infantryCount = 0;
                }
                else
                {
                    infantryCount = _cards.Infantry.Count;
                }

                if (_cards.Cavalry == null)
                {
                    cavalryCount = 0;
                }
                else
                {
                    cavalryCount = _cards.Cavalry.Count;
                }

                if (_cards.Artillary == null)
                {
                    artillaryCount = 0;
                }
                else
                {
                    artillaryCount = _cards.Artillary.Count;
                }

                if (_cards.Wild == null)
                {
                    wildCount = 0;
                }
                else
                {
                    wildCount = _cards.Wild.Count;
                }

                Console.WriteLine("\tInfantry cards = " + infantryCount);
                Console.WriteLine("\tCavalry cards = " + cavalryCount);
                Console.WriteLine("\tArtillary cards = " + artillaryCount);
                Console.WriteLine("\tWild cards = " + wildCount);

                Console.WriteLine("\n\t1. Play three of a kind");
                Console.WriteLine("\t2. Play one of each");
                Console.WriteLine("\t3. Play a wild card");
                Console.WriteLine("\t4. Game Menu");
                Console.WriteLine("\t5. Commence deployment of reinforcements");
                Console.WriteLine("\t==========================");
                var option = GameEngine.UserInputTest("\t(1-5)>", "\tInvalid input, please try again!", 1, 5);

                switch (option)
                {
                    case 1:
                        PlayThreeOfAKind(infantryCount, cavalryCount, artillaryCount, wildCount);
                        break;
                    case 2:
                        PlayOneOfEach(infantryCount, cavalryCount, artillaryCount, wildCount);
                        break;
                    case 3:
                        PlayWildCard(infantryCount, cavalryCount, artillaryCount, wildCount);
                        break;
                    case 4:
                        GamePlayMenus.PlayerTurnMenu();
                        break;
                    case 5:
                        doneTrading = true;
                        break;
                    default:
                        Console.WriteLine("\tError");
                        break;
                }
            }
            return _armies;
        }

        private static void PlayThreeOfAKind(int infantry, int cavalry, int artillery, int wild)
        {
            var done = false;
            while (done == false)
            {
                var usedCards = new List<Card>();
                var player = GameBoard.GetBoard().CurrentPlayer;

                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\tTrade three of a kind menu");
                Console.Write("\tCurrently ");
                Colour.PrintPlayer(player.Colour, player.Name + "'s");
                Console.Write(" turn.\n");
                if (player.Cards.Count > 6) { Colour.SouthAmericaRed("\tYou must trade at least one set of cards!\n"); }

                Console.WriteLine("\tInfantry cards = " + infantry);
                Console.WriteLine("\tCavalry cards = " + cavalry);
                Console.WriteLine("\tArtillary cards = " + artillery);
                Console.WriteLine("\tWild cards = " + wild);

                Console.WriteLine("\n\t1. Play three infantry cards");
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
                                usedCards.Add(_cards.Infantry[0]);
                                _cards.Infantry.RemoveAt(0);
                            }
                            infantry -= 3;
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("\tCards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\tYou do not have enough of that type of card!");
                            Console.WriteLine("\tPress any key to continue....");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        if (cavalry >= 3)
                        {
                            for (var index = 0; index <= 2; index++)
                            {
                                usedCards.Add(_cards.Cavalry[0]);
                                _cards.Cavalry.RemoveAt(0);
                            }
                            cavalry -= 3;
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("\tCards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\tYou do not have enough of that type of card!");
                            Console.WriteLine("\tPress any key to continue....");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        if (artillery >= 3)
                        {
                            for (var index = 0; index <= 2; index++)
                            {
                                usedCards.Add(_cards.Artillary[0]);
                                _cards.Artillary.RemoveAt(0);
                            }
                            artillery -= 3;
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("\tCards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\tYou do not have enough of that type of card!");
                            Console.WriteLine("\tPress any key to continue....");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        done = true;
                        break;
                    default:
                        Console.WriteLine("\tError");
                        break;
                }
            }
        }

        private static void PlayOneOfEach(int infantry, int cavalry, int artillery, int wild)
        {
            var done = false;
            while (done == false)
            {
                var usedCards = new List<Card>();
                var player = GameBoard.GetBoard().CurrentPlayer;

                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\t  Trade one of each menu");
                Console.Write("\tCurrently ");
                Colour.PrintPlayer(player.Colour, player.Name + "'s");
                Console.Write(" turn.\n");
                if (player.Cards.Count > 6) { Colour.SouthAmericaRed("\tYou must trade at least one set of cards!\n"); }

                Console.WriteLine("\tInfantry cards = " + infantry);
                Console.WriteLine("\tCavalry cards = " + cavalry);
                Console.WriteLine("\tArtillary cards = " + artillery);
                Console.WriteLine("\tWild cards = " + wild);

                Console.WriteLine("\n\t1. Play one of each card");
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
                            artillery -= 1;
                            cavalry -= 1;
                            artillery -= 1;
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("\tCards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\tYou do not have enough of that type of card!");
                            Console.WriteLine("\tPress any key to continue....");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        done = true;
                        break;
                    default:
                        Console.WriteLine("\tError");
                        break;
                }
            }
        }

        private static void PlayWildCard(int infantry, int cavalry, int artillery, int wild)
        {
            var done = false;
            while (done == false)
            {
                var usedCards = new List<Card>();
                var player = GameBoard.GetBoard().CurrentPlayer;

                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\tTrade a wild card menu");
                Console.Write("\tCurrently ");
                Colour.PrintPlayer(player.Colour, player.Name + "'s");
                Console.Write(" turn.\n");
                if (player.Cards.Count > 6) { Colour.SouthAmericaRed("\tYou must trade at least one set of cards!\n"); }

                Console.WriteLine("\tInfantry cards = " + infantry);
                Console.WriteLine("\tCavalry cards = " + cavalry);
                Console.WriteLine("\tArtillary cards = " + artillery);
                Console.WriteLine("\tWild cards = " + wild);

                Console.WriteLine("\n\t1. Play a wild card with two infantry cards");
                Console.WriteLine("\t2. Play a wild card with two cavalry cards");
                Console.WriteLine("\t3. Play a wild card with two artillery cards");
                Console.WriteLine("\t4. Play a wild card with an infantry and cavalry card");
                Console.WriteLine("\t5. Play a wild card with an infantry and artillary card");
                Console.WriteLine("\t6. Play a wild card with a cavalry and artillery card");
                Console.WriteLine("\t7. return to previous menu");
                Console.WriteLine("\t==========================");
                var option = GameEngine.UserInputTest("\t(1-7)>", "\tInvalid input, please try again!", 1, 7);

                switch (option)
                {
                    case 1:
                        if (infantry >= 2)
                        {
                            usedCards.Add(_cards.Wild[0]);
                            _cards.Wild.RemoveAt(0);
                            for (var index = 0; index <= 1; index++)
                            {
                                usedCards.Add(_cards.Infantry[0]);
                                _cards.Infantry.RemoveAt(0);
                            }
                            wild -= 1;
                            infantry -= 2;
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("\tCards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\tYou do not have enough of that type of card!");
                            Console.WriteLine("\tPress any key to continue....");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        if (cavalry >= 3)
                        {
                            usedCards.Add(_cards.Wild[0]);
                            _cards.Wild.RemoveAt(0);
                            for (var index = 0; index <= 1; index++)
                            {
                                usedCards.Add(_cards.Cavalry[0]);
                                _cards.Cavalry.RemoveAt(0);
                            }
                            wild -= 1;
                            cavalry -= 2;
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("\tCards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\tYou do not have enough of that type of card!");
                            Console.WriteLine("\tPress any key to continue....");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        if (artillery >= 3)
                        {
                            usedCards.Add(_cards.Wild[0]);
                            _cards.Wild.RemoveAt(0);
                            for (var index = 0; index <= 1; index++)
                            {
                                usedCards.Add(_cards.Artillary[0]);
                                _cards.Artillary.RemoveAt(0);
                            }
                            wild -= 1;
                            artillery -= 2;
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("\tCards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\tYou do not have enough of that type of card!");
                            Console.WriteLine("\tPress any key to continue....");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        if (infantry >= 1 && cavalry >= 1)
                        {
                            usedCards.Add(_cards.Wild[0]);
                            _cards.Wild.RemoveAt(0);
                            usedCards.Add(_cards.Infantry[0]);
                            _cards.Infantry.RemoveAt(0);
                            usedCards.Add(_cards.Cavalry[0]);
                            _cards.Cavalry.RemoveAt(0);

                            wild -= 1;
                            infantry -= 1;
                            cavalry -= 1;
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("\tCards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\tYou do not have enough of those types of card!");
                            Console.WriteLine("\tPress any key to continue....");
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        if (infantry >= 1 && artillery >= 1)
                        {
                            usedCards.Add(_cards.Wild[0]);
                            _cards.Wild.RemoveAt(0);
                            usedCards.Add(_cards.Infantry[0]);
                            _cards.Infantry.RemoveAt(0);
                            usedCards.Add(_cards.Artillary[0]);
                            _cards.Artillary.RemoveAt(0);

                            wild -= 1;
                            infantry -= 1;
                            artillery -= 1;
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("\tCards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\tYou do not have enough of those types of card!");
                            Console.WriteLine("\tPress any key to continue....");
                            Console.ReadKey();
                        }
                        break;
                    case 6:
                        if (cavalry >= 1 && artillery >= 1)
                        {
                            usedCards.Add(_cards.Wild[0]);
                            _cards.Wild.RemoveAt(0);
                            usedCards.Add(_cards.Cavalry[0]);
                            _cards.Cavalry.RemoveAt(0);
                            usedCards.Add(_cards.Artillary[0]);
                            _cards.Artillary.RemoveAt(0);

                            wild -= 1;
                            cavalry -= 1;
                            artillery -= 1;
                            GameBoard.GetBoard().AddToUsedCardPile(usedCards);
                            TradedCardValue();
                            Console.WriteLine("\tCards traded, Press any key to continue....");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\tYou do not have enough of those types of card!");
                            Console.WriteLine("\tPress any key to continue....");
                            Console.ReadKey();
                        }
                        break;
                    case 7:
                        done = true;
                        break;
                    default:
                        Console.WriteLine("\tError");
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
