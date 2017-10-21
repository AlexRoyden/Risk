using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Risk
{
    class GameSave
    {
        public static string SaveGame()
        {
            string message;
            var path = @"..\..\ConfigFiles\save1.json";
            var state = SaveBuilder.GetGameState();

            using (var stream = new StreamWriter(path))
            {
                try
                {
                    var json = JsonConvert.SerializeObject(state);
                    stream.Write(json);
                    message = "Save was successful";
                }
                catch(Exception e)
                {
                    message = "Error, save game failed : " + e;
                }
                
            }
            return message;
        }
    }
}
