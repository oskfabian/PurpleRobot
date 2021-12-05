using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Dtos;
using ToyRobot.Entities;
using static ToyRobot.Core.Enums;

namespace ToyRobot.Core
{ 
    [TestClass]
    public class TranslationHelperTests
    {
        [TestMethod]
        public void ConvertIntoPosition_NoCommas_Null()
        {
            var input = "ABC";
            var position = input.ConvertIntoPosition();
            Assert.IsNull(position);          
        }

        [TestMethod]
        public void ConvertIntoPosition_XIsInvalid_Null()
        {
            var input = "A,0";
            var position = input.ConvertIntoPosition();
            Assert.IsNull(position);
        }

        [TestMethod]
        public void ConvertIntoPosition_YIsInvalid_Null()
        {
            var input = "3,Z";
            var position = input.ConvertIntoPosition();
            Assert.IsNull(position);
        }

        [TestMethod]
        public void ConvertIntoPosition_YAndXAreInvalid_Null()
        {
            var input = "Yfdsf,Zfdsfdas";
            var position = input.ConvertIntoPosition();
            Assert.IsNull(position);
        }

        [TestMethod]
        public void ConvertIntoPosition_PositionOutsideOfTable_InvalidePosition()
        {
            var input = "3545758,278878";
            var position = input.ConvertIntoPosition();
            Assert.AreEqual(3545758, position.X);
            Assert.AreEqual(278878, position.Y);
            Assert.IsFalse(position.IsValid);
        }

        [TestMethod]
        public void ConvertIntoPosition_ValidPosition()
        {
            var input = "2,5";
            var position = input.ConvertIntoPosition();
            Assert.AreEqual(2, position.X);
            Assert.AreEqual(5, position.Y);
            Assert.IsTrue(position.IsValid);
        }

        [TestMethod]
        public void GetCommand_InvalidInput_CommandIgnored()
        {
            var input = "InvalidCommand!!!";
            var commandEnum = input.ConvertIntoCommand();
            Assert.AreEqual(CommandEnum.Unknow, commandEnum, "Failed to ignore invalid command");

            input = string.Empty;
            commandEnum = input.ConvertIntoCommand();
            Assert.AreEqual(CommandEnum.Unknow, commandEnum, "Failed to ignore invalid command");
        }

        [TestMethod]
        public void ConvertIntoCommand_Place()
        {          
            var input = "Place 2,3";
            var commandEnum = input.ConvertIntoCommand();
            Assert.AreEqual(CommandEnum.Place, commandEnum, "Failed to get Place command");
        }

        [TestMethod]
        public void ConvertIntoCommand_FirstPlace()
        {
            var input = "Place 2,3,North";
            var commandEnum = input.ConvertIntoCommand();
            Assert.AreEqual(CommandEnum.Place, commandEnum, "Failed to get Place command");
        }


        [TestMethod]
        public void ConvertIntoCommand_Move()
        {
            var input = "Move";
            var commandEnum = input.ConvertIntoCommand();           
            Assert.AreEqual(CommandEnum.Move, commandEnum, "Failed to get Move command");
        }

        [TestMethod]
        public void ConvertIntoCommand_Right()
        {
            var input = "Right";
            var commandEnum = input.ConvertIntoCommand();
            Assert.AreEqual(CommandEnum.Right, commandEnum, "Failed to get Right command");
        }

        [TestMethod]
        public void ConvertIntoCommand_Left()
        {
            var input = "left";
            var commandEnum = input.ConvertIntoCommand();
            Assert.AreEqual(CommandEnum.Left, commandEnum, "Failed to get Left command");
        }

        [TestMethod]
        public void ConvertIntoCommand_Report()
        {
            var input = "report";
            var commandEnum = input.ConvertIntoCommand();
            Assert.AreEqual(CommandEnum.Report, commandEnum, "Failed to get Report command");
        }

        [TestMethod]
        public void ConvertIntoPlaceDto_InvalidInput()
        {
            var input = "Invalid Input!!!";
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsFalse(placeDto.IsValid);
        }

        [TestMethod]
        public void ConvertIntoPlaceDto_ContainsNoCommas_InvalidInput()
        {
            var input = "Place 4 3 West";
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsFalse(placeDto.IsValid);
        }

        [TestMethod]
        public void ConvertIntoPlaceDto_ThreeCommas_InvalidInput()
        {
            var input = "Place ,34,33,West";
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsFalse(placeDto.IsValid);
        }

        [TestMethod]
        public void ConvertIntoPlaceDto_Empty_InvalidInput()
        {
            var input = string.Empty;
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsFalse(placeDto.IsValid);
        }

        [TestMethod]
        public void ConvertIntoPlaceDto_OnlyPosition_Position()
        {
            var input = "Place 33,44";
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.AreEqual(33, placeDto.Position.X);
            Assert.AreEqual(44, placeDto.Position.Y);
            Assert.IsNull(placeDto.Direction);
            Assert.IsTrue(placeDto.IsValid);
        }

        public void ConvertIntoPlaceDto_NorthValidInput_PlaceDto()
        {
            var input = "Place 333,444,North";
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsTrue(placeDto.IsValid);
            Assert.AreEqual(333, placeDto.Position.X);
            Assert.AreEqual(444, placeDto.Position.Y);
            Assert.AreEqual(CardinalDirectionEnum.North, placeDto.Direction.CardinalDirection);
        }

        public void ConvertIntoPlaceDto_SouthValidInput_PlaceDto()
        {
            var input = "Place 3,4,South";
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsTrue(placeDto.IsValid);
            Assert.AreEqual(3, placeDto.Position.X);
            Assert.AreEqual(4, placeDto.Position.Y);
            Assert.AreEqual(CardinalDirectionEnum.South, placeDto.Direction.CardinalDirection);
        }

        public void ConvertIntoPlaceDto_EastValidInput_PlaceDto()
        {
            var input = "Place 3,4,EAST";
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsTrue(placeDto.IsValid);
            Assert.AreEqual(3, placeDto.Position.X);
            Assert.AreEqual(4, placeDto.Position.Y);
            Assert.AreEqual(CardinalDirectionEnum.East, placeDto.Direction.CardinalDirection);
        }

        [TestMethod]
        public void ConvertIntoPlaceDto_WestValidInput_PlaceDto()
        { 
            var input = "Place 3,4,west"; 
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsTrue(placeDto.IsValid);
            Assert.AreEqual(3, placeDto.Position.X);
            Assert.AreEqual(4, placeDto.Position.Y);
            Assert.AreEqual(CardinalDirectionEnum.West, placeDto.Direction.CardinalDirection);
        }


        [TestMethod]
        public void ConvertIntoPlaceDto_PositionAndNoDirection()
        {
            var input = "Place 2,3";
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsTrue(placeDto.IsValid);
            Assert.AreEqual(2, placeDto.Position.X);
            Assert.AreEqual(3, placeDto.Position.Y);
            Assert.IsTrue(placeDto.IsValid);
            Assert.IsNull(placeDto.Direction);
        }

        [TestMethod]
        public void ConvertIntoPlaceDto_PositionAndDirection()
        {
            var input = "Place 2,3,North";
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsTrue(placeDto.IsValid);
            Assert.AreEqual(2, placeDto.Position.X);
            Assert.AreEqual(3, placeDto.Position.Y);
            Assert.AreEqual(CardinalDirectionEnum.North, placeDto.Direction.CardinalDirection);
            Assert.IsTrue(placeDto.IsValid);
        }

        [TestMethod]
        public void ConvertIntoPlaceDto_InvalidPosition()
        {
            var input = "Place 2,";
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsNull(placeDto.Direction);
            Assert.IsNull(placeDto.Position);
            Assert.IsFalse(placeDto.IsValid);

            input = "Place 2,X";
            placeDto = input.ConvertIntoPlaceDto();
            Assert.IsNull(placeDto.Direction);
            Assert.IsNull(placeDto.Position);
            Assert.IsFalse(placeDto.IsValid);
        }

        [TestMethod]
        public void ConvertIntoPlaceDto_InvalidDirection()
        {
            var input = "Place 2,4,Invalid!!!";
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsNull(placeDto.Direction);
            Assert.IsFalse(placeDto.IsValid);
        }

        [TestMethod]
        public void ConvertIntoPlaceDto_CoordinateHasManyDigitsAndDirection()
        {
            var input = "Place 778892,786554,North";
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsTrue(placeDto.IsValid);
            Assert.AreEqual(778892, placeDto.Position.X);
            Assert.AreEqual(786554, placeDto.Position.Y);
            Assert.AreEqual(CardinalDirectionEnum.North, placeDto.Direction.CardinalDirection);
        }

        [TestMethod]
        public void ConvertIntoPlaceDto_CoordinateHasManyDigitsAndNoDirection()
        {
            var input = "Place 778892,786554";
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsTrue(placeDto.IsValid);
            Assert.AreEqual(778892, placeDto.Position.X);
            Assert.AreEqual(786554, placeDto.Position.Y);
            Assert.IsNull(placeDto.Direction?.CardinalDirection);
        }

        [TestMethod]
        public void ConvertIntoPlaceDto_CoordinateHasManyDigitsAndCommaAtTheEnd()
        {
            var input = "Place 778892,786554,";
            var placeDto = input.ConvertIntoPlaceDto();
            Assert.IsFalse(placeDto.IsValid);
        }
    }
}
