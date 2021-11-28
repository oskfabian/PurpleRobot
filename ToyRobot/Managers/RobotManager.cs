using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Core;
using ToyRobot.Dtos;
using ToyRobot.Entities;
using static ToyRobot.Core.Enums;

namespace ToyRobot.Managers
{
    public interface IRobotManager
    {
       string ExecuteInput(string input);
    }
    public class RobotManager : IRobotManager
    {
        Robot Robot = new Robot();

        public RobotManager()
        {
            Robot = new Robot();
        }

        string IRobotManager.ExecuteInput(string input)
        {
            var commandEnum = input.ConvertIntoCommand();
            string output = string.Empty;

            switch (commandEnum)
            {
                case CommandEnum.Unknow:
                    return string.Empty;
                case CommandEnum.Place:
                    var placeDto = input.ConvertIntoPlaceDto();
                    if (placeDto.IsValid)
                        Robot.Place(placeDto.Position, placeDto.Direction);
                    break;
                case CommandEnum.Left:
                    Robot.TurnLeft();
                    break;
                case CommandEnum.Right:
                    Robot.TurnRight();
                    break;
                case CommandEnum.Move:
                    Robot.Move();
                    break;
                case CommandEnum.Report:
                    var reportDto = Robot.Report();
                    output = reportDto.Output;
                    break;
            }
            return output;
        }
    }
}
