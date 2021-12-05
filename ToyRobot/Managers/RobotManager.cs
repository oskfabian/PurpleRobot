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
        OutputDto ExecuteInput(string input);
    }
    public class RobotManager : IRobotManager
    {
        Robot Robot = new Robot();

        public RobotManager()
        {
            Robot = new Robot();
        }

        OutputDto IRobotManager.ExecuteInput(string input)
        {
            var commandEnum = input.ConvertIntoCommand();
            var outputDto = new OutputDto();

            switch (commandEnum)
            {
                case CommandEnum.Unknow:
                    return outputDto;
                case CommandEnum.Place:
                    var placeDto = input.ConvertIntoPlaceDto();
                    if (placeDto.IsValid)
                        Robot.Place(placeDto.Position, placeDto.Direction);
                    break;
                case CommandEnum.Left:
                    Robot.Turn(SideEnum.Left);
                    break;
                case CommandEnum.Right:
                    Robot.Turn(SideEnum.Right);
                    break;
                case CommandEnum.Move:
                    Robot.Move();
                    break;
                case CommandEnum.Report:
                    var reportDto = Robot.Report();
                    outputDto.Output = reportDto.Output;
                    break;
            }
            return outputDto;
        }
    }
}
