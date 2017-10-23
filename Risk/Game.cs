using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk
{
    //Builder Abstract base class
    public abstract class Game
    {
        protected GameBoard GameBoard;

        public GameBoard GetGameBoard()
        {
            return GameBoard;
        }

        public abstract void CreateGame();
        public abstract void InitializeBoard();
        public abstract void AssignStartingPlayer();
    }
}
