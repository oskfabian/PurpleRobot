using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyRobot.Dtos;
using ToyRobot.Entities;
using static ToyRobot.Core.Enums;

namespace ToyRobot.Core
{
    /// <summary>
    /// A helper class that converts a string into robot language.
    /// </summary>
    public static class TranslationHelpers
    {
        /// <summary>
        /// Convert a string into a Command a robot can execute.
        /// </summary>
        public static CommandEnum ConvertIntoCommand(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return CommandEnum.Unknow;
            if (input.ToLower().StartsWith($"{CommandEnum.Place.ToString().ToLower()} "))
                return CommandEnum.Place;
            else if (input.Equals(CommandEnum.Move.ToString().ToLower(), StringComparison.OrdinalIgnoreCase))
                return CommandEnum.Move;
            else if (input.Equals(CommandEnum.Right.ToString().ToLower(), StringComparison.OrdinalIgnoreCase))
                return CommandEnum.Right;
            else if (input.Equals(CommandEnum.Left.ToString().ToLower(), StringComparison.OrdinalIgnoreCase))
                return CommandEnum.Left;
            else if (input.Equals(CommandEnum.Report.ToString().ToLower(), StringComparison.OrdinalIgnoreCase))
                return CommandEnum.Report;
            else
                return CommandEnum.Unknow;
        }

        /// <summary>
        /// Convert a string into a Position.
        /// Format X,Y is expected.
        /// </summary>
        public static Position ConvertIntoPosition(this string input)
        {
            if (!string.IsNullOrEmpty(input) &&
                input.Count(x => (x == ',')) == 1)
            {
                var xInput = input.Substring(0, input.IndexOf(","));
                var isXValid = int.TryParse(xInput, out int positionX);

                var yInput = input.Substring(input.IndexOf(",") + 1);
                var isYValid = int.TryParse(yInput, out int positionY);
                if (isXValid && isYValid)
                    return (new Position(positionX, positionY));
            }
            return null;
        }

        /// <summary>
        /// Convert a string into a Direction.
        /// </summary>
        public static Direction ConvertIntoDirection(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (input.ToLower().Trim() == CardinalDirectionEnum.East.ToString().ToLower())
                    return new Direction(CardinalDirectionEnum.East);
                else if (input.ToLower().Trim() == CardinalDirectionEnum.West.ToString().ToLower())
                    return new Direction(CardinalDirectionEnum.West);
                else if (input.ToLower().Trim() == CardinalDirectionEnum.North.ToString().ToLower())
                    return new Direction(CardinalDirectionEnum.North);
                else if (input.ToLower().Trim() == CardinalDirectionEnum.South.ToString().ToLower())
                    return new Direction(CardinalDirectionEnum.South);
            }
            return null;
        }

        /// <summary>
        /// Converts a string into a PlaceDto
        /// Place format is expected: "Place x,y,cardinalDirection"
        /// </summary>
        public static PlaceDto ConvertIntoPlaceDto(this string input)
        {
            var dto = new PlaceDto();
            var inputContainsDirection = false;

            if (!IsValidPlaceInStructure(input))
                return dto;

            inputContainsDirection = input.Count(x => (x == ',')) == 2;

            #region GetPosition
            var positionInput = input.Substring(CommandEnum.Place.ToString().Length + 1);
            if (inputContainsDirection)
            {
                var positionInputLength = positionInput.Length - input.Substring(input.LastIndexOf(",")).Length;
                positionInput = input.Substring(CommandEnum.Place.ToString().Length + 1, positionInputLength);
            }   
             
            var position = positionInput.ConvertIntoPosition();
            if (position is null)
            {
                return dto;
            }
            #endregion

            #region GetDirection
            Direction outputDirection = null;
            if (inputContainsDirection)
            {
                var directionInput = input.Substring(input.LastIndexOf(",") + 1);
                outputDirection = directionInput.ConvertIntoDirection();
                if (outputDirection is null)
                    return dto;
            }           
            #endregion
           
            dto.Direction = outputDirection;
            dto.Position = position;
            dto.IsValid = true;
            return dto;
        }

        private static bool IsValidPlaceInStructure(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            else
            {               
                int numberOfCommas = input.Count(x => (x == ','));
                if (input.Length < CommandEnum.Place.ToString().Length + 4 ||
                    numberOfCommas < 1 ||
                    numberOfCommas > 2)
                    return false;
            }

            return true;
        }
    }
}
