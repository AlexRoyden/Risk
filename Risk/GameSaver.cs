using System;
using System.IO;
using Newtonsoft.Json;

namespace Risk
{
    class GameSaver
    {
        public static void SaveGame(int slot)
        {
            var path = PathFinder(slot);
            string message;
            var state = StateBuilder.GetGameState();
            var meta = new SaveGameMetaData();

            using (var stream = new StreamWriter(path))
            {
                try
                {
                    var json = JsonConvert.SerializeObject(state);
                    stream.Write(json);
                    message = "Save was successful";
                    meta.UpdateMeta(slot);
                    meta.SaveMeta();
                    BoardBuilder.LoadTerritoryNeighbours();
                }
                catch(Exception e)
                {
                    message = "Error, save game failed : " + e;
                    BoardBuilder.LoadTerritoryNeighbours();
                }
            }
            GameEngine.Timer("Saving game");
            Console.WriteLine("\r\t" + message + "\n\tPress any key to continue");
            Console.ReadKey();
        }

        private static string PathFinder(int slot)
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
    }
}
