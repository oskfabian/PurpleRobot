using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Entities;
using static ToyRobot.Core.Enums;

namespace ToyRobot.Dtos
{
    public class PlaceDto
    {
        public bool IsValid { get; set; }
        public Position Position { get; set; }
        public Direction Direction { get; set; }
    }
}
