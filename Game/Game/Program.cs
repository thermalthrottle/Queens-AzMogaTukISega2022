using System;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Didaka log");
            Console.WriteLine("3rayski was here");
            Console.Title = "Queens";
            string title = @"
              @
            /' \. .:
   _______  )) ( _:::.__.'_
   `:::::: ~ / ,\     .::'
    :::::'   \`  \  .'::'
    :::'    ('.\  `-.. :.
 __::'_______`-.\    ))::._
  .'``:::::::::  `-'~'
         `:::'
           '";

            Console.WriteLine(title);
            Console.Read();
        }
    }
}
