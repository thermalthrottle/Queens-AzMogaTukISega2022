using System;
using System.Text;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "Queens";
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            string row_line = new string('-', n * 4 + 1);
            for (int i = 0; i < m; i++)
            {
                Console.Write(row_line);
                Console.WriteLine();
                Console.Write("|");
                for (int j = 0; j < n; j++)
                {
                    Console.Write("   |");
                }
                Console.WriteLine();
            }
            Console.WriteLine(row_line);
        }
    }
}
