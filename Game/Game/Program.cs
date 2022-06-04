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

            //board args
            Console.Write("Please enter board width: ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Please enter board height: ");
            m = int.Parse(Console.ReadLine());

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
            Console.WriteLine();

            //place queen
            Console.Write("x = ");
            int px = int.Parse(Console.ReadLine());
            Console.Write("y = ");
            int py = int.Parse(Console.ReadLine());

            Place(px, py);
        }

        public static void Place(int x, int y)
        {
            Console.Clear();
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