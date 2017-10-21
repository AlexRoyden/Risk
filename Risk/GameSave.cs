using System;
using System.IO;
using Newtonsoft.Json;

namespace Risk
{
    class GameSave
    {
        public static void SaveMenu()
        {
            Console.Clear();
            var meta = SaveGameMetaData.LoadMetaData();
            Colour.SouthAmericaRed("\t     **** Risk! ****\n");
            Console.WriteLine("\t===========================================");
            Console.WriteLine("\t       Save Menu");
            Console.WriteLine("\t1. Slot 1 - " + meta.Save1Count + " Players...." + meta.Save1Date);
            Console.WriteLine("\t2. Slot 2 - " + meta.Save2Count + " Players...." + meta.Save2Date);
            Console.WriteLine("\t3. Slot 3 - " + meta.Save3Count + " Players...." + meta.Save3Date);
            Console.WriteLine("\t4. Slot 4 - " + meta.Save4Count + " Players...." + meta.Save4Date);
            Console.WriteLine("\t5. Slot 5 - " + meta.Save5Count + " Players...." + meta.Save5Date);
            Console.WriteLine("\t6. Slot 6 - " + meta.Save6Count + " Players...." + meta.Save6Date);
            Console.WriteLine("\t7. Return to previous Menu");
            Console.WriteLine("\t==========================");
            var option = GameEngine.UserInputTest("\t(1-7)>", "\tInvalid input, please try again!", 1, 7);

            switch (option)
            {
                case 1:
                    var path1 = @"..\..\SaveFiles\save1.json";
                    SaveGame(path1, 1);
                    break;
                case 2:
                    var path2 = @"..\..\SaveFiles\save2.json";
                    SaveGame(path2, 2);
                    break;
                case 3:
                    var path3 = @"..\..\SaveFiles\save3.json";
                    SaveGame(path3, 3);
                    break;
                case 4:
                    var path4 = @"..\..\SaveFiles\save4.json";
                    SaveGame(path4, 4);
                    break;
                case 5:
                    var path5 = @"..\..\SaveFiles\save5.json";
                    SaveGame(path5, 5);
                    break;
                case 6:
                    var path6 = @"..\..\SaveFiles\save6.json";
                    SaveGame(path6, 6);
                    break;
                case 7:
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

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
