using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk
{
    class Risk
    {
        public void Construct(Game game)
        {
            game.CreateGame();
            game.InitializeBoard();
            game.AssignStartingPlayer();
        }
    }
}
