using System;
using System.IO;
using Newtonsoft.Json;

namespace Risk
{
    class GameSaver
    {
        public static void SaveGame(string path, int slot)
        {
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
    }
}
