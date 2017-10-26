using System;
using System.Collections.Generic;

namespace Risk
{
    public class GameEngine
    {
        public static Player HighestRoll(List<Player> rollers)
        {
            var board = GameBoard.GetBoard();
            int highest = 0;
            int winnerCount = 0;
            Player winner = null;
            var success = false;
            var rnd = board.GetRandom();

            while (success == false)
            {
                foreach (var player in rollers)
                {
                    var roll = Dice.Roll(rnd);
                    if (roll > highest)
                    {
                        highest = roll;
                        winner = player;
                        winnerCount = 1;
                    }
                    else if (roll == highest)
                    {
                        winnerCount++;
                    }
                }

                if (winnerCount == 1)
                {
                    success = true;
                }
                else
                {
                    winnerCount = 0;
                    highest = 0;
                }
            }
            
            return winner;
        }

        public static int GetPlayerIndex(string name)
        {
            var board = GameBoard.GetBoard();
            var index = 0;

            foreach (var player in board.GetPlayerList())
            {
                if (player.Name == name)
                {
                    return index;
                }
                index++;
            }
            throw new Exception();
        }

        public static int GetPlayerColourIndex(string name)
        {
            var board = GameBoard.GetBoard();
            var index = 0;

            foreach (var player in board.GetPlayerList())
            {
                if (player.Name == name)
                {
                    index = player.Colour;
                }
            }
            return index;
        }

        public static string BufferBuilder(int length, int max)
        {
            var difference = max - length;
            var buffer = "";

            for (int count = 1; count <= difference; count++)
            {
                buffer += " ";
            }

            return buffer;
        }

        public static int UserInputTest(string prompt, string error, int lowest, int highest)
        {
            var input = 0;
            var count = 0;
            while (input < lowest || input > highest)
            {
                if (count != 0) { Console.WriteLine(error); }
                Console.Write(prompt);
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\tSelection must be a number!");
                }
                count = 1;
            }
            return input;
        }

        public static Queue<Player> CreateTurnQueue(Player starter)
        {
            var board = GameBoard.GetBoard();
            var queue = new Queue<Player>(board.GetPlayerList());
            var complete = false;

            while (complete == false)
            {
                if (queue.Peek().Name != starter.Name)
                {
                    var swap = queue.Dequeue();
                    queue.Enqueue(swap);
                }
                else
                {
                    complete = true;
                }
            }
            return queue;
        }

        public static void Timer(string message)
        {
            Console.Clear();
            Colour.SouthAmericaRed("\t\t**** Risk! ****\n");
            Console.WriteLine("\t====================================");
            for (int a = 3; a >= 0; a--)
            {
                Console.Write("\r\t{0}......{1}",message, a);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
