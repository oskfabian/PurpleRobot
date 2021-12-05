using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Entities;
using static ToyRobot.Core.Enums;

namespace ToyRobotTests.Entities
{
    [TestClass]
    public class RobotTests
    {
        /// <summary>
        /// The first valid command to the robot is a PLACE command. 
        /// After that, any sequence of commands may be issued, in any order, including another PLACE command. 
        /// The library should discard all commands in the sequence until a valid PLACE command has been executed.
        /// </summary>
        [TestMethod]
        public void ExecuteCommand_RobotNotOnTheTable_CommandsIgnored()
        {
            var robot = new Robot();
            Assert.IsFalse(robot.IsOnTable, "Invalid Command was executed.");
           
            robot.Turn(SideEnum.Left);
            Assert.IsFalse(robot.IsOnTable, "Invalid TurnLeft Command was executed.");
           
            robot.Turn(SideEnum.Right);
            Assert.IsFalse(robot.IsOnTable, "Invalid TurnRight Command was executed.");

            robot.Move();
            Assert.IsFalse(robot.IsOnTable, "Invalid Move Command was executed.");

            var report = robot.Report();
            Assert.IsFalse(robot.IsOnTable, "Invalid Command was executed.");
            Assert.IsFalse(report.IsOnTable, "Invalid Command was executed.");
            Assert.IsNull(report.Orientation, "Invalid Report Command was executed.");
            Assert.IsNull(report.Position, "Invalid Report Command was executed.");

            robot.Place(new Position(5,5), null);
            Assert.IsFalse(robot.IsOnTable, "Invalid Place Command was executed.");

            robot.Place(new Position(5, 5), new Direction(CardinalDirectionEnum.East));
            Assert.IsTrue(robot.IsOnTable, "Valid Place Command was not executed.");
        }

        [TestMethod]
        public void PlaceRobot_OutsideOfTable_CommandIsIgnored()
        {
            var robot = new Robot(new Position(0, 0), new Direction(CardinalDirectionEnum.West));

            robot.Place(new Position(20, 3), null);
            Assert.AreEqual(0, robot.Position.X, "Failed to ignore command");
            Assert.AreEqual(0, robot.Position.Y, "Failed to ignore command");

            robot.Place(new Position(20, 3), null);
            Assert.AreEqual(0, robot.Position.X, "Failed to ignore command");
            Assert.AreEqual(0, robot.Position.Y, "Failed to ignore command");

            robot.Place(new Position(20, 20), null);
            Assert.AreEqual(0, robot.Position.X, "Failed to ignore command");
            Assert.AreEqual(0, robot.Position.Y, "Failed to ignore command");
        }

        [TestMethod]
        public void PlaceRobot_InsideOfTable_CommandIsExecuted()
        {
            var robot = new Robot(new Position(0, 0), new Direction(CardinalDirectionEnum.West));
            robot.Place(new Position(5, 5), null);

            Assert.AreEqual(5, robot.Position.X, "Failed to ignore command");
            Assert.AreEqual(5, robot.Position.Y, "Failed to ignore command");
        } 
    }
}
