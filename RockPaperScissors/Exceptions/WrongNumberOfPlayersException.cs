﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    public class WrongNumberOfPlayersException : Exception
    {
        public WrongNumberOfPlayersException(string message)
        : base(message)
        {
        }
    }
}
