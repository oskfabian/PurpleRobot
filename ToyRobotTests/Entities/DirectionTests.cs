using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Entities;
using static ToyRobot.Core.Enums;

namespace ToyRobotTests.Entities
{
    [TestClass]
    public class DirectionTests
    {
        [TestMethod]
        public void CurrentlyWest_TurnRight_North()
        {
            var direction = new Direction(CardinalDirectionEnum.West);
            direction.Turn(SideEnum.Right);
            var expectedResult = CardinalDirectionEnum.North;
            Assert.AreEqual(expectedResult, direction.CardinalDirection, "Failed to turn right");
        }

        [TestMethod]
        public void CurrentlyWest_TurnLeft_South()
        {
            var direction = new Direction(CardinalDirectionEnum.West);
            direction.Turn(SideEnum.Left);
            var expectedResult = CardinalDirectionEnum.South;
            Assert.AreEqual(expectedResult, direction.CardinalDirection, "Failed to turn left");
        }

        [TestMethod]
        public void CurrentlyNorth_TurnRight_East()
        {
            var direction = new Direction(CardinalDirectionEnum.North);
            direction.Turn(SideEnum.Right);
            var expectedResult = CardinalDirectionEnum.East;
            Assert.AreEqual(expectedResult, direction.CardinalDirection, "Failed to turn right");
        }

        [TestMethod]
        public void CurrentlyNorth_TurnLeft_West()
        {
            var direction = new Direction(CardinalDirectionEnum.North);
            direction.Turn(SideEnum.Left);
            var expectedResult = CardinalDirectionEnum.West;
            Assert.AreEqual(expectedResult, direction.CardinalDirection, "Failed to turn left");
        }
    }
}
