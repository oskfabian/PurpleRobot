using System;
using System.Collections.Generic;
using System.Text;
using static ToyRobot.Core.Enums;

namespace ToyRobot.Dtos
{
    public class OutputDto
    {
        public bool IsPrintable
        {
            get
            {
                return !string.IsNullOrEmpty(Output);
            }
        }       
        public string Output { get; set; }
    }
}
