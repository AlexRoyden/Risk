using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk.Land.Territories.Europe
{
    class Iceland : ITerritory
    {
        public enum Neighbours { Scandanavia = 1, GreatBritain, Greenland };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}
