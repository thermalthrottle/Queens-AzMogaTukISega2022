using Game.View;
using System;
using System.Text;

namespace Game
{
    internal class Program
    {
        public static ConsoleColor fontColor = ConsoleColor.Cyan;
        public static ConsoleColor titleColor = ConsoleColor.DarkCyan;
        public static string title = @"
   ____                           
  /___ \_   _  ___  ___ _ __  ___ 
 //  / / | | |/ _ \/ _ \ '_ \/ __|
/ \_/ /| |_| |  __/  __/ | | \__ \
\___,_\ \__,_|\___|\___|_| |_|___/
                                  ";

        static void Main(string[] args)
        {
            //console setup
            Console.OutputEncoding = Encoding.Unicode;
            Console.ForegroundColor = fontColor;
            Console.Title = "Queens";
            while(true){
                 Console.Clear();
            //title ascii
            Console.ForegroundColor = titleColor;
            Console.WriteLine(title);
            Console.ForegroundColor = fontColor;

            //main menu
            Console.WriteLine(@"1: Start");
            Console.WriteLine(@"2: Exit");
            Console.WriteLine();
            Console.Write("Select: ");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 2)
                Environment.Exit(0);

            //start
            ConsoleClear();
            new PlayerVSPlayerView();
            }
           
        }

        static void ConsoleClear()
        {
            Console.Clear();
            Console.ForegroundColor = titleColor;
            Console.WriteLine(title);
            Console.ForegroundColor = fontColor;
        }
    }
}