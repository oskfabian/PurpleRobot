using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Core;
using ToyRobot.Dtos;
using ToyRobot.Entities;
using static ToyRobot.Core.Enums;

namespace ToyRobot.Managers
{
    [TestClass]
    public class RobotManagerTests
    {
        [TestMethod]
        public void ExecuteSequence1()
        {
            IRobotManager manager = new RobotManager();
           
            var input = "PLACE 0,0";
            manager.ExecuteInput(input);

            input = "PLACE 0,0,North";
            manager.ExecuteInput(input);

            input = "Invalid!!!";
            manager.ExecuteInput(input);

            input = "MOVE";
            manager.ExecuteInput(input);

            input = "REPORT";
            var output = manager.ExecuteInput(input);

            Assert.AreEqual("0,1,North", output);
        }


        [TestMethod]
        public void ExecuteSequence2()
        {
            IRobotManager manager = new RobotManager();

            var input = "PLACE 1,2,EAST";
            manager.ExecuteInput(input);

            input = "MOVE";
            manager.ExecuteInput(input);

            input = "LEFT";
            manager.ExecuteInput(input);

            input = "MOVE";
            manager.ExecuteInput(input);

            input = "PLACE 3,1";
            manager.ExecuteInput(input);

            input = "Move";
            manager.ExecuteInput(input);

            input = "Right";
            manager.ExecuteInput(input);

            input = "Right";
            manager.ExecuteInput(input);

            input = "Right";
            manager.ExecuteInput(input);

            input = "Right";
            manager.ExecuteInput(input);

            input = "Right";
            manager.ExecuteInput(input);

            input = "Right";
            manager.ExecuteInput(input);

            input = "MOVE";
            manager.ExecuteInput(input);

            input = "MOVE";
            manager.ExecuteInput(input);

            input = "MOVE";
            manager.ExecuteInput(input);

            input = "Right";
            manager.ExecuteInput(input);

            input = "MOVE";
            manager.ExecuteInput(input);

            input = "MOVE";
            manager.ExecuteInput(input);

            input = "MOVE";
            manager.ExecuteInput(input);

            input = "MOVE";
            manager.ExecuteInput(input);

            input = "MOVE";
            manager.ExecuteInput(input);

            input = "Report";
            var output = manager.ExecuteInput(input);

            Assert.AreEqual("0,0,West", output);
        }
    }
}
