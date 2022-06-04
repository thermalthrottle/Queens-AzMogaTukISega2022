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
        public PlayerVSPlayerView()
        {
            System.Console.WriteLine("Welcome in Player vs Player mode!");
            int[] dimensions = GetBoardSize();
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
                BoardToString();
                int[] cord = GetPlayerInputCord();
                if(endEarly)break;
                int x = cord[0];
                int y = cord[1];
                try
                {

                    _playerBoard.Place(x, y);
                    //     if(_playerBoard.IsEnd)
                    //    {
                    //        PrintEndResult();
                    //        break;
                    //    }
                    playerOneTurn = !playerOneTurn;
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

            }
        }
        public string BoardToString()
        {
            return _playerBoard.GameBoard.ToString();
        }
        public int[] GetPlayerInputCord()
        {
            int x = 0;
            int y = 0;
            while (true)
            {
                try
                {
                    System.Console.WriteLine("If you want to continue please enter cordinates of your next queen in the format \"<x> <y>\"");
                    System.Console.WriteLine("or if you want to end the current current game early please enter \"end\"");
                    string cmd = Console.ReadLine();
                    if(cmd=="end")
                    {
                        endEarly=true;
                        break;
                    }

                    string[] cordsStr = cmd.Split();
                    if(cordsStr.Length!=2)throw new ArgumentException("Please the cordinates in the format \"<x> <y>\" to continue or \"end\" to end the current game early!");
                    int[] cords = cordsStr.Select(int.Parse).ToArray();
                    break;

                }
                catch (FormatException) 
                {
                    Console.WriteLine("The diminsion must be positive number!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number you entered is too big!");
                }
                catch (ArgumentNullException)
                {
                    System.Console.WriteLine("How you enter a null?");
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

            }
            return new int[] { x, y };
        }
        public int[] GetBoardSize()
        {
            int width = 0;
            int height = 0;
            while (true)
            {
                try
                {
                    System.Console.WriteLine("Please enter board width: ");
                    width = int.Parse(Console.ReadLine());
                    if (width < 5) throw new ArgumentException("The entered width is too small!");
                    System.Console.WriteLine("Please enter board height: ");
                    height = int.Parse(Console.ReadLine());
                    if (height < 5) throw new ArgumentException("The entered height is too small!");
                    break;

                }
                catch (FormatException)
                {
                    System.Console.WriteLine("The diminsion must be positive number!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number you entered is too big!");
                }
                catch (ArgumentNullException)
                {
                    System.Console.WriteLine("How you enter a null?");
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

            }
            return new int[] { width, height };
        }
        public void PrintEndResult()
        {
            if (playerOneTurn)
            {
                System.Console.WriteLine("Player one the winner");
            }
            else
            {
                System.Console.WriteLine("Player two the winner");
            }
        }
    }
}
