using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyRobot.Core;
using static ToyRobot.Core.Enums;

namespace ToyRobot.Entities
{
    public class Direction
    {
        public CardinalDirectionEnum CardinalDirection { get; private set; }

        public Direction(CardinalDirectionEnum cardinalDirection)
        {
            CardinalDirection = cardinalDirection;
        }

        public void TurnLeft()
        {
            var currentDirectionIndex = DirectionHelpers.CardinalDirectionsInOrder.ToList().FindIndex(cd => cd == CardinalDirection);
            if (currentDirectionIndex <= 0)
                CardinalDirection = DirectionHelpers.CardinalDirectionsInOrder.ToList().Last();
            else
                CardinalDirection = DirectionHelpers.CardinalDirectionsInOrder.ToList()[currentDirectionIndex - 1];
        }

        public void TurnRight()
        {
            var currentDirectionIndex = DirectionHelpers.CardinalDirectionsInOrder.ToList().FindIndex(cd => cd == CardinalDirection);
            if (currentDirectionIndex >= DirectionHelpers.CardinalDirectionsInOrder.ToList().Count - 1)
                CardinalDirection = DirectionHelpers.CardinalDirectionsInOrder.ToList().First();
            else
                CardinalDirection = DirectionHelpers.CardinalDirectionsInOrder.ToList()[currentDirectionIndex + 1];
        }
    }
}
