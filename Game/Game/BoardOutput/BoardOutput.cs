using System;
using Game.ConsoleColors;
using Game.GameLogic;

namespace Game.BoardOutput
{
    internal static class BoardOutput
    {
        internal static void BoardToString(Board board)
        {
            
            int n = board.GameBoard.GetLength(0);
            int m = board.GameBoard.GetLength(1);
            Console.ForegroundColor = ConsoleColors.ConsoleColors.boardColor;

            //column numbers
            Console.WriteLine();
            string row_line = new string('-', n * 4 + 1);
            Console.Write("  ");
            for (int i = 0; i < n; i++)
            {
                Console.ForegroundColor = ConsoleColors.ConsoleColors.numberColor;
                if (i > 10)
                    Console.Write($" {i} ");
                else
                    Console.Write($"  {i} ");
                Console.ForegroundColor = ConsoleColors.ConsoleColors.boardColor;
            }
            Console.WriteLine();

            //draw rows
            for (int i = 0; i < m; i++)
            {
                Console.Write("  ");
                Console.Write(row_line);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColors.ConsoleColors.numberColor;
                Console.Write($"{i}");
                Console.ForegroundColor = ConsoleColors.ConsoleColors.boardColor;
                if (i < 10)
                    Console.Write(" |");
                else
                    Console.Write("|");
                for (int j = 0; j < n; j++)
                {
                    if(board.GameBoard[j, i]=='\0')
                        Console.Write("   |");
                    else
                        Console.Write($" {board.GameBoard[j, i]} |");
                }
                Console.WriteLine();
            }

            Console.Write("  ");
            Console.Write(row_line);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColors.ConsoleColors.fontColor;
        }
         internal static void PrintEndResult(bool playerOneTurn,Board board)
        {
            BoardToString(board);
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
            System.Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}