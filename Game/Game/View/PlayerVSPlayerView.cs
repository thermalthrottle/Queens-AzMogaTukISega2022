using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.GameLogic;

namespace Game.View
{
    internal class PlayerVSPlayerView
    {
        private readonly Board _playerBoard;
        private bool playerOneTurn = true;
        private bool endEarly = false;
        private ConsoleColor numberColor = ConsoleColor.Cyan;
        private ConsoleColor boardColor = ConsoleColor.Blue;
        private ConsoleColor fontColor = ConsoleColor.Cyan;
        public static ConsoleColor titleColor = ConsoleColor.DarkCyan;
        public static string title = @"
   ____                           
  /___ \_   _  ___  ___ _ __  ___ 
 //  / / | | |/ _ \/ _ \ '_ \/ __|
/ \_/ /| |_| |  __/  __/ | | \__ \
\___,_\ \__,_|\___|\___|_| |_|___/
                                  ";

        public PlayerVSPlayerView()
        {
            System.Console.WriteLine("Welcome in Player vs Player mode!\n");
            int[] dimensions = BoardInputValidator.GetBoardSize();
            int width = dimensions[0];
            int height = dimensions[1];
            _playerBoard = new Board(width, height);
            BoardCycle();
        }
        public void BoardCycle()
        {
            while (true)
            {
                System.Console.WriteLine("");
                BoardOutput.BoardToString(_playerBoard);
                int[] cord = BoardInputValidator.GetPlayerInputCord(playerOneTurn,out endEarly,_playerBoard);
                if (endEarly) {
                    break;
                };
                int x = cord[0];
                int y = cord[1];
                try
                {
                    char player = playerOneTurn?'1':'2';
                    _playerBoard.Place(x, y, player);
                    if (_playerBoard.CheckIFGameFinished())
                    {
                         BoardOutput.PrintEndResult(playerOneTurn,_playerBoard);
                        break;
                    }
                    playerOneTurn = !playerOneTurn;
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
