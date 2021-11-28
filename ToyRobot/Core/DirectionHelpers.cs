using System;
using System.Collections.Generic;
using System.Text;
using static ToyRobot.Core.Enums;

namespace ToyRobot.Core
{
    public static class DirectionHelpers
    {
        public static IList<CardinalDirectionEnum> CardinalDirectionsInOrder => new List<CardinalDirectionEnum>()
            {
                CardinalDirectionEnum.North,
                CardinalDirectionEnum.East,
                CardinalDirectionEnum.South,
                CardinalDirectionEnum.West
            };
    }
}
