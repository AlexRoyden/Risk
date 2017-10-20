using System.Collections.Generic;

namespace Risk
{
    interface ITerritory
    {
        string Name { get; set; }
        string Continent { get; set; }
        string Occupant { get; set; }
        int Armies { get; set; }
        List<string> NeighboursNames { get; set; }
        int TerriroryNumber { get; set; }
    }
}
