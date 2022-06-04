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
                if (endEarly) {
                    PrintEndResult();
                    break;
                };
                int x = cord[0];
                int y = cord[1];
                try
                {
                    char player = playerOneTurn?'1':'2';
                    _playerBoard.Place(x, y,player);
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
        public void BoardToString()
        {
            int n = _playerBoard.GameBoard.GetLength(0);
            int m = _playerBoard.GameBoard.GetLength(1);

            //column numbers
            string row_line = new string('-', n * 4 + 1);
            Console.Write("  ");
            for (int i = 0; i < n; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                if (i > 10)
                    Console.Write($" {i} ");
                else
                    Console.Write($"  {i} ");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine();

            //draw rows
            for (int i = 0; i < m; i++)
            {
                Console.Write("  ");
                Console.Write(row_line);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"{i}");
                Console.ForegroundColor = ConsoleColor.Black;
                if (i < 10)
                    Console.Write(" |");
                else
                    Console.Write("|");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(" * |");
                }
                Console.WriteLine();
            }

            Console.Write("  ");
            Console.Write(row_line);
            Console.WriteLine();
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
                    Console.WriteLine("or enter \"clear\" to clear the console");
                    string cmd = Console.ReadLine();
                    if (cmd == "end")
                    {
                        endEarly = true;
                        break;
                    }
                    else if (cmd == "clear")
                    {
                        Console.Clear();
                    }
                    else
                    {
                        string[] cordsStr = cmd.Split();
                        if (cordsStr.Length != 2) throw new ArgumentException("Please enter the cordinates in the format \"<x> <y>\" to continue or \"end\" to end the current game early!");
                        int[] cords = cordsStr.Select(int.Parse).ToArray();
                        break;

                    }
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("The dimension must be positive number!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number you entered is too big!");
                }
                catch (ArgumentNullException)
                {
                    System.Console.WriteLine("How can you enter a null?");
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
                    System.Console.WriteLine("The dimension must be positive number!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number you entered is too big!");
                }
                catch (ArgumentNullException)
                {
                    System.Console.WriteLine("How can you enter a null?");
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
                System.Console.WriteLine("Player One WINS!");
            }
            else
            {
                System.Console.WriteLine("Player Two WINS!");
            }
        }
    }

}
