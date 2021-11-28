using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Core;
using static ToyRobot.Core.Enums;

namespace ToyRobot.Entities
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public bool IsValid
        {
            get
            {
                return (X <= TableConstants.TableSizeX - 1 && Y <= TableConstants.TableSizeY - 1);
            }
        }
       
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(CardinalDirectionEnum CardinalDirection)
        {
            switch (CardinalDirection)
            {
                case CardinalDirectionEnum.North:
                    MoveToNorth();
                    break;
                case CardinalDirectionEnum.East:
                    MoveToEast();
                    break;
                case CardinalDirectionEnum.South:
                    MoveToSouth();
                    break;
                case CardinalDirectionEnum.West:
                    MoveToWest();
                    break;
            }
        }

        private void MoveToNorth()
        {
            if (Y < TableConstants.TableSizeY - 1)
                Y++;
        }

        private void MoveToSouth()
        {
            if (Y > 0)
                Y--;
        }

        private void MoveToWest()
        {
            if (X > 0)
                X--;
        }

        private void MoveToEast()
        {
            if (X < TableConstants.TableSizeX - 1)
                X++;
        }

    }
}
