using System;

namespace RobotChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table = new();
            // Infinite loop. Does not end until user closes the console window. 
            while (true)
            {
                string command = Console.ReadLine();
                Parser.RunStringCommand(table, command);
            }
        }
    }
}
