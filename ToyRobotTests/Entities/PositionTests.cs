using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Entities;
using static ToyRobot.Core.Enums;

namespace ToyRobotTests.Entities
{
    [TestClass]
    public class PositionTests
    {

        [TestMethod]
        public void BeingOnEastEdge_MoveEast_PositionDoesNotChange()
        {
            var originalPositionX = 5;
            var originalPositionY = 3;
            var position = new Position(originalPositionX, originalPositionY);
            position.Move(CardinalDirectionEnum.East);
            Assert.AreEqual(originalPositionX, position.X, $"Position X changed {position.X}. Object may fall to destruction.");
            Assert.AreEqual(originalPositionY, position.Y, $"Position Y changed.");
        }

        [TestMethod]
        public void NotBeingOnEastEdge_MoveEast_PositionXChanges()
        {
            var position = new Position(3, 2);
            position.Move(CardinalDirectionEnum.East);
            var expectedPosition = new Position(4, 2);
            Assert.AreEqual(expectedPosition.X, position.X, $"Failed to move in east direction.");
            Assert.AreEqual(expectedPosition.Y, position.Y, $"Position Y changed.");
        }

        [TestMethod]
        public void BeingOnWestEdge_MoveWest_PositionDoesNotChange()
        {
            var originalPositionX = 0;
            var originalPositionY = 3;
            var position = new Position(originalPositionX, originalPositionY);
            position.Move(CardinalDirectionEnum.West);
            Assert.AreEqual(originalPositionX, position.X, $"Position X changed {position.X}. Object may fall to destruction.");
            Assert.AreEqual(originalPositionY, position.Y, $"Position Y changed.");
        }

        [TestMethod]
        public void NotBeingOnWestEdge_MoveWest_PositionXChanges()
        {
            var position = new Position(3, 2);
            position.Move(CardinalDirectionEnum.West);
            var expectedPosition = new Position(2, 2);
            Assert.AreEqual(expectedPosition.X, position.X, $"Failed to move in east direction.");
            Assert.AreEqual(expectedPosition.Y, position.Y, $"Position Y changed.");
        }

        [TestMethod]
        public void BeingOnNorthEdge_MoveNorth_PositionDoesNotChange()
        {
            var originalPositionX = 3;
            var originalPositionY = 5;
            var position = new Position(originalPositionX, originalPositionY);
            position.Move(CardinalDirectionEnum.North);
            Assert.AreEqual(originalPositionX, position.X, $"Position Y changed {position.Y}. Object may fall to destruction.");
            Assert.AreEqual(originalPositionY, position.Y, $"Position X changed.");
        }

        [TestMethod]
        public void NotBeingOnNorthEdge_MoveNorth_PositionYChanges()
        {
            var position = new Position(2, 3);
            position.Move(CardinalDirectionEnum.North);
            var expectedPosition = new Position(2, 4);
            Assert.AreEqual(expectedPosition.X, position.X, $"Failed to move in north direction.");
            Assert.AreEqual(expectedPosition.Y, position.Y, $"Position Y changed.");
        }

        [TestMethod]
        public void BeingOnSouthEdge_MoveSouth_PositionDoesNotChange()
        {
            var originalPositionX = 3;
            var originalPositionY = 0;
            var position = new Position(originalPositionX, originalPositionY);
            position.Move(CardinalDirectionEnum.South);
            Assert.AreEqual(originalPositionX, position.X, $"Position Y changed {position.Y}. Object may fall to destruction.");
            Assert.AreEqual(originalPositionY, position.Y, $"Position X changed.");
        }

        [TestMethod]
        public void NotBeingOnSouthEdge_MoveSouth_PositionYChanges()
        {
            var position = new Position(2, 3);
            position.Move(CardinalDirectionEnum.South);
            var expectedPosition = new Position(2, 2);
            Assert.AreEqual(expectedPosition.X, position.X, $"Failed to move in north direction.");
            Assert.AreEqual(expectedPosition.Y, position.Y, $"Position Y changed.");
        }
    }
}
