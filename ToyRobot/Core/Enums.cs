using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ToyRobot.Core
{
    public class Enums
    {
        public enum CardinalDirectionEnum
        {
            North,
            East,
            South,
            West
        }

        public enum CommandEnum
        {
            Place,
            Move,
            Left,
            Right,
            Report,
            Unknow
        }
    }
}
