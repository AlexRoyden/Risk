using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Risk
{
    class SaveGameMetaData
    {
        private static SaveMetaMapper _meta;

        public static SaveMetaMapper LoadMetaData()
        {
            var path = @"..\..\SaveFiles\SaveMeta.json";
            SaveMetaMapper metaMapper;

            using (var stream = new StreamReader(path))
            {
                var json = stream.ReadToEnd();
                metaMapper = JsonConvert.DeserializeObject<SaveMetaMapper>(json);
            }
            return metaMapper;
        }

        public void SaveMeta()
        {
            var path = @"..\..\SaveFiles\SaveMeta.json";

            using (var stream = new StreamWriter(path))
            {
                var metaData = JsonConvert.SerializeObject(_meta);
                stream.Write(metaData);
            }
        }

        public void UpdateMeta(int slot)
        {
            var dt = DateTime.Now;
            var date = $"{dt:g}";
            var count = GameBoard.GetBoard().GetPlayerList().Count;
            switch (slot)
            {
                case 1:
                    _meta.Save1Count = count;
                    _meta.Save1Date = date;
                    break;
                case 2:
                    _meta.Save2Count = count;
                    _meta.Save2Date = date;
                    break;
                case 3:
                    _meta.Save3Count = count;
                    _meta.Save3Date = date;
                    break;
                case 4:
                    _meta.Save4Count = count;
                    _meta.Save4Date = date;
                    break;
                case 5:
                    _meta.Save5Count = count;
                    _meta.Save5Date = date;
                    break;
                case 6:
                    _meta.Save6Count = count;
                    _meta.Save6Date = date;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}
