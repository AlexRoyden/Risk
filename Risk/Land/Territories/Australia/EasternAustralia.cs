using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk.Land.Territories.Australia
{
    class EasternAustralia : ITerritory
    {
        public enum Neighbours { NewGuinea = 1, WesternAustralia };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}
