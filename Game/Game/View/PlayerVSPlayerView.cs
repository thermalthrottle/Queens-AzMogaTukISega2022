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
                int[] cord = GetPlayerInputCord(playerOneTurn);
                if (endEarly) {
                    PrintEndResult();
                    break;
                };
                int x = cord[0];
                int y = cord[1];
                try
                {
                    char player = playerOneTurn?'1':'2';
                    _playerBoard.Place(x, y, player);
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
            Console.ForegroundColor = boardColor;

            //column numbers
            string row_line = new string('-', n * 4 + 1);
            Console.Write("  ");
            for (int i = 0; i < n; i++)
            {
                Console.ForegroundColor = numberColor;
                if (i > 10)
                    Console.Write($" {i} ");
                else
                    Console.Write($"  {i} ");
                Console.ForegroundColor = boardColor;
            }
            Console.WriteLine();

            //draw rows
            for (int i = 0; i < m; i++)
            {
                Console.Write("  ");
                Console.Write(row_line);
                Console.WriteLine();
                Console.ForegroundColor = numberColor;
                Console.Write($"{i}");
                Console.ForegroundColor = boardColor;
                if (i < 10)
                    Console.Write(" |");
                else
                    Console.Write("|");
                for (int j = 0; j < n; j++)
                {
                    if(_playerBoard.GameBoard[j, i]=='\0')
                        Console.Write("   |");
                    else
                        Console.Write($" {_playerBoard.GameBoard[j, i]} |");
                }
                Console.WriteLine();
            }

            Console.Write("  ");
            Console.Write(row_line);
            Console.WriteLine();
            Console.ForegroundColor = fontColor;
        }
        public int[] GetPlayerInputCord(bool player)
        {
            int x = 0;
            int y = 0;
            while (true)
            {
                try
                {
                    int playerNumber = player == true ? 1 : 2;
                    Console.WriteLine("For command list [help]");
                    System.Console.Write($"Player {playerNumber}: Enter coordinates for your queen [x y]: ");
                    string cmd = Console.ReadLine();
                    if (cmd.ToLower() == "end")
                    {
                        endEarly = true;
                        break;
                    }
                    else if (cmd.ToLower() == "clear")
                    {
                        Console.Clear();
                        Console.ForegroundColor = titleColor;
                        Console.WriteLine(title);
                        Console.ForegroundColor = fontColor;
                    }
                    else if(cmd.ToLower() == "help")
                    {
                        Console.WriteLine("\n[clear] to clear the console\n[end] to exit\n[help] for command list\n");
                    }
                    else
                    {
                        string[] cordsStr = cmd.Split();
                        if (cordsStr.Length != 2) throw new ArgumentException("Invalid cordinates");
                        int[] cords = cordsStr.Select(int.Parse).ToArray();
                        x = cords[0];
                        y = cords[1];
                        break;
                    }
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("\nThe dimension must be positive number!\n");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\nThe number you entered is too big!\n");
                }
                catch (ArgumentNullException)
                {
                    System.Console.WriteLine("\nHow can you enter a null?\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine();
                    System.Console.WriteLine(ex.Message);
                    Console.WriteLine();
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
                    System.Console.Write("Please enter board width: ");
                    width = int.Parse(Console.ReadLine());
                    if (width < 5) throw new ArgumentException("\nThe entered width is too small!\n");
                    System.Console.Write("Please enter board height: ");
                    height = int.Parse(Console.ReadLine());
                    if (height < 5) throw new ArgumentException("\nThe entered height is too small!\n");
                    break;

                }
                catch (FormatException)
                {
                    System.Console.WriteLine("\nThe dimension must be positive number!\n");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\nThe number you entered is too big!\n");
                }
                catch (ArgumentNullException)
                {
                    System.Console.WriteLine("\nHow can you enter a null?\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine();
                    System.Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }

            }
            return new int[] { width, height };
        }
        public void PrintEndResult()
        {
            if (playerOneTurn)
            {
                string win = @"
  ____  _                          ___              __        _____ _   _ ____  
 |  _ \| | __ _ _   _  ___ _ __   / _ \ _ __   ___  \ \      / /_ _| \ | / ___| 
 | |_) | |/ _` | | | |/ _ \ '__| | | | | '_ \ / _ \  \ \ /\ / / | ||  \| \___ \ 
 |  __/| | (_| | |_| |  __/ |    | |_| | | | |  __/   \ V  V /  | || |\  |___) |
 |_|   |_|\__,_|\__, |\___|_|     \___/|_| |_|\___|    \_/\_/  |___|_| \_|____/ 
                |___/                                                           ";
                System.Console.WriteLine(win);
            }
            else
            {
                string win = @"
  ____  _                         _____                __        _____ _   _ ____  
 |  _ \| | __ _ _   _  ___ _ __  |_   _|_      _____   \ \      / /_ _| \ | / ___| 
 | |_) | |/ _` | | | |/ _ \ '__|   | | \ \ /\ / / _ \   \ \ /\ / / | ||  \| \___ \ 
 |  __/| | (_| | |_| |  __/ |      | |  \ V  V / (_) |   \ V  V /  | || |\  |___) |
 |_|   |_|\__,_|\__, |\___|_|      |_|   \_/\_/ \___/     \_/\_/  |___|_| \_|____/ 
                |___/                                                              ";
                System.Console.WriteLine(win);
            }
        }
    }
}
