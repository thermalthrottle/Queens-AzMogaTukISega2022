using Game.View;
using System;
using System.Text;

namespace Game
{
    internal class Program
    {
        public static int n;
        public static int m;

        static void Main(string[] args)
        {
            //console setup
            Console.OutputEncoding = Encoding.Unicode;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "Queens";

            //title ascii
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string title = @"
   ____                           
  /___ \_   _  ___  ___ _ __  ___ 
 //  / / | | |/ _ \/ _ \ '_ \/ __|
/ \_/ /| |_| |  __/  __/ | | \__ \
\___,_\ \__,_|\___|\___|_| |_|___/
                                  ";
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.Black;

            //player one ascii
            string win = @"
  ____  _                          ___              __        _____ _   _ ____  
 |  _ \| | __ _ _   _  ___ _ __   / _ \ _ __   ___  \ \      / /_ _| \ | / ___| 
 | |_) | |/ _` | | | |/ _ \ '__| | | | | '_ \ / _ \  \ \ /\ / / | ||  \| \___ \ 
 |  __/| | (_| | |_| |  __/ |    | |_| | | | |  __/   \ V  V /  | || |\  |___) |
 |_|   |_|\__,_|\__, |\___|_|     \___/|_| |_|\___|    \_/\_/  |___|_| \_|____/ 
                |___/                                                           ";
            //player two ascii
            string win1 = @"
  ____  _                         _____                __        _____ _   _ ____  
 |  _ \| | __ _ _   _  ___ _ __  |_   _|_      _____   \ \      / /_ _| \ | / ___| 
 | |_) | |/ _` | | | |/ _ \ '__|   | | \ \ /\ / / _ \   \ \ /\ / / | ||  \| \___ \ 
 |  __/| | (_| | |_| |  __/ |      | |  \ V  V / (_) |   \ V  V /  | || |\  |___) |
 |_|   |_|\__,_|\__, |\___|_|      |_|   \_/\_/ \___/     \_/\_/  |___|_| \_|____/ 
                |___/                                                              ";
            Console.WriteLine(win);
            Console.WriteLine(win1);

            new PlayerVSPlayerView();

            //board args
            /*Console.Write("Please enter board width: ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Please enter board height: ");
            m = int.Parse(Console.ReadLine());*/

            //column numbers
            /*string row_line = new string('-', n * 4 + 1);
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
                if(i < 10)
                    Console.Write(" |");
                else
                    Console.Write("|");
                for (int j = 0; j < n; j++)
                {
                    Console.Write("   |");
                }
                Console.WriteLine();
            }

            Console.Write("  ");
            Console.Write(row_line);
            Console.WriteLine();*/

            //place queen
            /*Console.Write("x = ");
            int px = int.Parse(Console.ReadLine());
            Console.Write("y = ");
            int py = int.Parse(Console.ReadLine());

            Place(px, py);*/
        }

        public static void Place(int x, int y)
        {
            Console.Clear();

            //title
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string title = @"
   ____                           
  /___ \_   _  ___  ___ _ __  ___ 
 //  / / | | |/ _ \/ _ \ '_ \/ __|
/ \_/ /| |_| |  __/  __/ | | \__ \
\___,_\ \__,_|\___|\___|_| |_|___/
                                  ";
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.Black;

            string row_line = new string('-', n * 4 + 1);

            //column numbers
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
                    if (i == y - 1 && j == x - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" 1 ");
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write("|");
                    }
                    else
                        Console.Write("   |");
                }
                Console.WriteLine();
            }

            Console.Write("  ");
            Console.Write(row_line);
        }
    }
}