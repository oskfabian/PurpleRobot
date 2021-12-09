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
                var outputDto = manager.ExecuteInput(input);
                if (outputDto.IsPrintable)
                    Console.WriteLine(outputDto.Output);
            }
        }
    }
}
