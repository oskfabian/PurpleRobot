using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Dtos;
using static ToyRobot.Core.Enums;

namespace ToyRobot.Entities
{
    public class Robot
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }

        public bool IsOnTable
        {
            get
            {
                return (Position != null && Position.IsValid);
            }
        }

        /// <summary>
        /// Instantiates a robot that is not on a table.
        /// </summary>
        public Robot()
        {}

        /// <summary>
        /// Instantiates a robot that is on a table only if position and direction are valid.
        /// </summary>
        public Robot(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }

        /// <summary>
        /// Updates a robot position.
        /// </summary>
        public void Place(Position location, Direction direction)
        {
            if (!IsOnTable && direction == null)
            {
                return;
            }
            ChangeLocation(location);
            if (direction != null)
                Direction = direction;
        }   

        public void Turn(SideEnum side)
        {
            if (IsOnTable)
                Direction.Turn(side);
        }

        public void Move()
        {
            if (IsOnTable)
                Position.Move(Direction.CardinalDirection);
        }

        public ReportDto Report()
        {
            var report = new ReportDto()
            {
              IsOnTable = this.IsOnTable,
              Orientation = this.Direction?.CardinalDirection,
              Position = this.IsOnTable ? 
                         new PositionDto() {X = this.Position.X, Y = this.Position.Y } :
                         null
            };

            return report;
        }

        private void ChangeLocation(Position location)
        {
            if (location.IsValid)
                Position = location;            
        }
    }
}
