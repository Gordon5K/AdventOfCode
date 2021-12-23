using System;

namespace AOC
{
    public static class Program
    {
        static void Main()
        {
            Console.Clear();
            var day = new _2021.Day23();
            Console.WriteLine(day.Task1());
            Console.WriteLine(day.Task2());
            Console.ReadKey();
        }
    }
}
