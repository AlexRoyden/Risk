using System;
using System.IO;
using Newtonsoft.Json;

namespace Risk
{
    class SaveGameMetaData
    {
        private static SaveMetaMapper _meta;

        public static SaveMetaMapper Meta
        {
            get
            {
                if (_meta == null)
                {
                    LoadMetaData();
                }
                return _meta;
            }
            set { _meta = value; }
        }

        public static void LoadMetaData()
        {
            var path = @"..\..\SaveFiles\SaveMeta.json";

            using (var stream = new StreamReader(path))
            {
                var json = stream.ReadToEnd();
                Meta = JsonConvert.DeserializeObject<SaveMetaMapper>(json);
            }
        }

        public void SaveMeta()
        {
            var path = @"..\..\SaveFiles\SaveMeta.json";

            using (var stream = new StreamWriter(path))
            {
                var metaData = JsonConvert.SerializeObject(Meta);
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
                    Meta.Save1Count = count;
                    Meta.Save1Date = date;
                    break;
                case 2:
                    Meta.Save2Count = count;
                    Meta.Save2Date = date;
                    break;
                case 3:
                    Meta.Save3Count = count;
                    Meta.Save3Date = date;
                    break;
                case 4:
                    Meta.Save4Count = count;
                    Meta.Save4Date = date;
                    break;
                case 5:
                    Meta.Save5Count = count;
                    Meta.Save5Date = date;
                    break;
                case 6:
                    Meta.Save6Count = count;
                    Meta.Save6Date = date;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}
