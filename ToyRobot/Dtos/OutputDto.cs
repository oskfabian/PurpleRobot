using System;
using System.Collections.Generic;
using System.Text;
using static ToyRobot.Core.Enums;

namespace ToyRobot.Dtos
{
    public class ReportDto
    {
        public string Output
        {
            get
            {
                if (IsOnTable)
                    return $"{Position.X},{Position.Y},{Orientation.ToString()}";

                return string.Empty;
            }
        }
        public CardinalDirectionEnum? Orientation { get; set; }
        public PositionDto Position { get; set; }
        public bool IsOnTable { get; set; }
    }
}
