using System;
using ToyRobot.Core;
using ToyRobot.Managers;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            IRobotManager manager = new RobotManager();
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                var output = manager.ExecuteInput(input);
                if (output.IsPrintable)
                    Console.WriteLine(output);
            }
        }
    }
}
