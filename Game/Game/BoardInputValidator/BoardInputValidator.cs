using System;
using System.Linq;
using Game.GameLogic;

namespace Game.BoardInputValidator
{
    internal static class BoardInputValidator
    {
        internal static string title = @"
   ____                           
  /___ \_   _  ___  ___ _ __  ___ 
 //  / / | | |/ _ \/ _ \ '_ \/ __|
/ \_/ /| |_| |  __/  __/ | | \__ \
\___,_\ \__,_|\___|\___|_| |_|___/
                                  ";
        internal static int[] GetPlayerInputCord(bool player,out bool endEarly,Board board)
        {
            int x = 0;
            int y = 0;
            endEarly = false;
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
                        Console.ForegroundColor = ConsoleColors.ConsoleColors.titleColor;
                        Console.WriteLine(title);
                        Console.ForegroundColor = ConsoleColors.ConsoleColors.fontColor;
                    }
                    else if(cmd.ToLower() == "help")
                    {
                        Console.WriteLine("\n[clear] to clear the console\n[end] to exit\n[show] to show the board\n[help] for command list\n");
                    }
                    else if(cmd.ToLower() == "show")
                    {
                        BoardOutput.BoardOutput.BoardToString(board);
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
        internal static int[] GetBoardSize()
        {
            int width = 0;
            int height = 0;
            while (true)
            {
                try
                {
                    System.Console.Write("Please enter board width: ");
                    width = int.Parse(Console.ReadLine());
                    if (width < 5) throw new ArgumentException("\nThe width must be positive number!\n");
                    System.Console.Write("Please enter board height: ");
                    height = int.Parse(Console.ReadLine());
                    if (height < 5) throw new ArgumentException("\nThe height must be positive number!\n");
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
    }
}