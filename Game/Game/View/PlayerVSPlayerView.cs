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
        public PlayerVSPlayerView()
        {
            System.Console.WriteLine("Welcome in Player vs Player mode!");
            int[] dimensions = GetBoardSize();
            int width = dimensions[0];
            int height = dimensions[1];
            _playerBoard = new Board(width,height);       
            BoardCycle();
        }
        public void BoardCycle(){
            while (true)
            {
                int[] cord = GetPlayerInputCord();
                int x = cord[0];
                int y = cord[1];
                try
                {
                    _playerBoard.Place(x,y);
                   // if(_playerBoard.IsEnd)
                   {
                       PrintEndResult();
                       break;
                   }

                }
                catch (System.Exception ex)
                {
                     System.Console.WriteLine("Cannot place queen there!");
                }
                
            }
        }
        public string BoardToString(){
            return _playerBoard.GameBoard.ToString();
        }
        public int[] GetPlayerInputCord()
        {

            //validate
            return new int[]{0,0};
        } 
        public int[] GetBoardSize()
        {
            //validate
            System.Console.WriteLine("Enter board size: ");
            return new int[]{5,5};
        }
        public void PrintEndResult()
        {
            if(playerOneTurn){
                System.Console.WriteLine("Player one the winner");
            }
            else
            {
                System.Console.WriteLine("Player two the winner");
            }
        }
    }
}
