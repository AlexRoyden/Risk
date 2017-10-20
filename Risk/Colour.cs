using System;

namespace Risk
{
    public class Colour
    {
        public static void PrintLand(string continent, string value )
        {
            switch (continent)
            {
                case "North America":
                    NorthAmericaYellow(value);
                    break;
                case "South America":
                    SouthAmericaRed(value);
                    break;
                case "Europe":
                    EuropeBlue(value);
                    break;
                case "Africa":
                    AfricaMagenta(value);
                    break;
                case "Asia":
                    AsiaGreen(value);
                    break;
                case "Austarlasia":
                    AustralasiaCyan(value);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        public static void PrintPlayer(int index, string value)
        {
            switch (index)
            {
                case 1:
                    NorthAmericaYellow(value);
                    break;
                case 2:
                    SouthAmericaRed(value);
                    break;
                case 3:
                    EuropeBlue(value);
                    break;
                case 4:
                    AfricaMagenta(value);
                    break;
                case 5:
                    AsiaGreen(value);
                    break;
                case 6:
                    AustralasiaCyan(value);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        public static void NorthAmericaYellow(string value)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(value);
            Console.ResetColor();
        }

        public static void SouthAmericaRed(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(value);
            Console.ResetColor();
        }

        public static void EuropeBlue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(value);
            Console.ResetColor();
        }

        public static void AfricaMagenta(string value)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(value);
            Console.ResetColor();
        }

        public static void AsiaGreen(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(value);
            Console.ResetColor();
        }

        public static void AustralasiaCyan(string value)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(value);
            Console.ResetColor();
        }
    }
}
