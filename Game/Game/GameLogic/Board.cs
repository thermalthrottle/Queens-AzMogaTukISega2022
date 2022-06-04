using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameLogic
{
    internal class Board
    {
        private char[,] board;

        public char[,] GameBoard { get => board; }

        public Board(int width, int height)
        {
            board = new char[width, height];
        }

        public void Place(int x, int y)
        {

        }

        private bool ValidateIfOccupied()
        {
            return false;
        }

        private bool CheckIFGameFinished()
        {
            return false;
        }
    }
}
